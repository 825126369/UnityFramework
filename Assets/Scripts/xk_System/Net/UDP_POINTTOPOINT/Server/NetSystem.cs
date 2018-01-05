﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using xk_System.Debug;
using System.Net.Sockets;
using xk_System.Net;
using System;
using xk_System.DataStructure;

namespace xk_System.Net.UDP.POINTTOPOINT.Server
{
	public class NetSystem :SocketSystem_UdpServer
	{
		public void initNet (string ip, int ServerPort)
		{
			base.InitNet (ip,ServerPort);
		}

		public void Update ()
		{
			foreach (var v in  ClientFactory.Instance.mClientPool) {
				v.Value.Update ();
			}
		}

		public void sendNetData (int clientId,int command, object data)
		{
			//byte[] stream = ProtobufUtility.Serialize (data);
			//ClientFactory.Instance.GetClient (clientId).SendNetData (command, stream);
		}

		public void addNetListenFun (int command, Action<NetPackage> func)
		{
			//mEventSystem.addNetListenFun (command, func);
		}

		public void closeNet ()
		{
			base.CloseNet ();
		}
	}
}


