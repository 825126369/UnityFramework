﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using xk_System.Debug;
using xk_System.Net.Client;
using System.Net.Sockets;
using xk_System.Net.Client.TCP;
using xk_System.Net;
using System;
using xk_System.DataStructure;

namespace xk_System.Net.Client
{
	public class NetSystem:NetEventInterface
	{
		private NetSendSystem mNetSendSystem;
		private NetReceiveSystem mNetReceiveSystem;
		private SocketSystem mNetSocketSystem;

		public NetSystem ()
		{
			mNetSocketSystem = new SocketSystem_1 ();
			mNetSendSystem = new NetSendSystem (mNetSocketSystem);
			mNetReceiveSystem = new NetReceiveSystem (mNetSocketSystem);
		}

		public void initNet (string ServerAddr, int ServerPort)
		{
			mNetSocketSystem.init (ServerAddr, ServerPort);
		}

		public void sendNetData (int command, byte[] buffer)
		{
			mNetSendSystem.SendNetData (command, buffer);  
		}

		public void handleNetData ()
		{
			mNetSocketSystem.Update ();
			mNetSendSystem.HandleNetPackage ();
			mNetReceiveSystem.HandleNetPackage ();
		}

		public void addNetListenFun (Action<NetPackage> fun)
		{
			mNetReceiveSystem.addListenFun (fun);
		}

		public void removeNetListenFun (Action<NetPackage> fun)
		{
			mNetReceiveSystem.removeListenFun (fun);
		}

		public void closeNet ()
		{
			mNetSocketSystem.CloseNet ();
			mNetSendSystem.Destory ();
			mNetReceiveSystem.Destory ();
		}
	}

	public abstract class SocketSystem
	{
		protected const int receiveInfoPoolCapacity = 8192;
		protected const int sendInfoPoolCapacity = 8192;
		protected const int receiveTimeOut = 10000;
		protected const int sendTimeOut = 5000;
		protected NetReceiveSystem mNetReceiveSystem;

		protected Socket mSocket;

		public abstract void init (string ServerAddr, int ServerPort);

		public abstract void SendNetStream (byte[] msg);

		public abstract void Update ();

		public bool IsPrepare ()
		{
			return mSocket != null;
		}

		public void initSystem (NetReceiveSystem mNetReceiveSystem)
		{
			this.mNetReceiveSystem = mNetReceiveSystem;
		}

		public virtual void CloseNet ()
		{
			if (mSocket != null) {
				mSocket.Close ();
				mSocket = null;
			}
			DebugSystem.Log ("关闭客户端TCP连接");
		}
	}

	//begin~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~网络发送系统~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	public class  NetSendSystem
	{
		protected Queue<NetPackage> mNeedHandleNetPackageQueue;
		protected SocketSystem mSocketSystem;

		public NetSendSystem (SocketSystem socketSys)
		{
			this.mSocketSystem = socketSys;
			mNeedHandleNetPackageQueue = new Queue<NetPackage> ();
		}

		public virtual void SendNetData (int id, byte[] buffer)
		{
			NetPackage mNetPackage = new NetPackage ();
			mNetPackage.command = id;
			mNetPackage.buffer = buffer;
			HandleNetStream (mNetPackage);
		}

		public void HandleNetPackage ()
		{
			int handlePackageCount = 0;
			while (mNeedHandleNetPackageQueue.Count > 0) {
				var mPackage = mNeedHandleNetPackageQueue.Dequeue ();
				HandleNetStream (mPackage);
				handlePackageCount++;

				if (handlePackageCount > 3) {
					//DebugSystem.LogError ("客户端 发送包的数量： " + handlePackageCount);
				}
			}
		}

		public void HandleNetStream (NetPackage mPackage)
		{
			byte[] stream = NetEncryptionStream.Encryption (mPackage);
			mSocketSystem.SendNetStream (stream);
		}

		public virtual void Destory ()
		{
			lock (mNeedHandleNetPackageQueue) {
				mNeedHandleNetPackageQueue.Clear ();
			}
		}
	}

	//begin~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~网络接受系统~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	public class NetReceiveSystem
	{
		protected CircularBuffer<byte> mReceiveStreamList;
		protected CircularBuffer<byte> mParseStreamList;
		protected NetPackage mReceiveNetPackage = null;
		protected Action<NetPackage> mReceiveFun = null;

		public NetReceiveSystem (SocketSystem socketSys)
		{
			mReceiveStreamList = new CircularBuffer<byte> (1024);
			mParseStreamList = new CircularBuffer<byte> (1024);
			mReceiveNetPackage = new NetPackage ();
			socketSys.initSystem (this);
		}

		public void addListenFun (Action<NetPackage> fun)
		{
			if (mReceiveFun != null) {
				if (CheckDataBindFunIsExist (fun)) {
					DebugSystem.LogError ("添加监听方法重复");
					return;
				}
				mReceiveFun += fun;
			} else {
				mReceiveFun = fun;
			}              
		}

		private bool CheckDataBindFunIsExist (Action<NetPackage> fun)
		{
			return DelegateUtility.CheckFunIsExist<NetPackage> (mReceiveFun, fun);
		}

		public void removeListenFun (Action<NetPackage> fun)
		{
			mReceiveFun -= fun;
		}

		public void ReceiveSocketStream (byte[] data)
		{
			lock (mReceiveStreamList) {
				mReceiveStreamList.WriteFrom (data, 0, data.Length);
			}
		}

		public void HandleNetPackage ()
		{
			lock (mReceiveStreamList) {
				mParseStreamList.WriteFrom (mReceiveStreamList, mReceiveStreamList.Length);
			}

			int PackageCout = 0;
			while (GetPackage ()) {
				PackageCout++;

				if (PackageCout > 1000) {
					break;
				}
			}

			if (PackageCout > 3) {
				DebugSystem.LogError ("客户端 解析包的数量： " + PackageCout);
			}
		}

		private bool GetPackage ()
		{
			if (mParseStreamList.Length <= 0) {
				return false;
			}

			bool bSucccess = NetEncryptionStream.DeEncryption (mParseStreamList, mReceiveNetPackage);
			if (bSucccess) {
				if (mReceiveFun != null) {
					mReceiveFun (mReceiveNetPackage);
				}
			}
		
			return bSucccess;
		}

		public virtual void Destory ()
		{
			mReceiveNetPackage.reset ();
		}
	}
}


