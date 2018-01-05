﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using xk_System.Debug;
using xk_System.Net.UDP.POINTTOPOINT.Server;
using UdpPointtopointProtocols;
using xk_System.Net.UDP.POINTTOPOINT.Protocol;

namespace xk_System.Net.UDP.POINTTOPOINT.Test
{
	public class UDPServerTest : MonoBehaviour
	{
		NetServer mNetSystem = null;

		private void Start ()
		{
			gameObject.AddComponent<LogManager> ();
			mNetSystem = gameObject.AddComponent<NetServer> ();

			mNetSystem.Init ();
			StartCoroutine (StartTest ());
		}

		private IEnumerator StartTest ()
		{
			mNetSystem.addNetListenFun (UdpNetCommand.COMMAND_TESTCHAT, Receive_ServerSenddata);
			yield return Run ();
		}

		IEnumerator Run ()
		{    
			for (int i = 0; i < 20; i++) {
				GameObject obj = new GameObject ();
				obj.AddComponent<UDPClientTest> ();
				yield return new WaitForSeconds (1f);
			}
		}

		public static int nReceiveCount = 0;

		private void Receive_ServerSenddata (NetPackage package)
		{
			csChatData mServerSendData = Protocol3Utility.getData<csChatData> (package.buffer, 0, package.buffer.Length);
			DebugSystem.Log ("Server: " + mServerSendData.TalkMsg);
			nReceiveCount++;
		}
	}
}