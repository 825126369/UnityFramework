﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xk_System.Net.Client
{
	public class NetObjectPool:Singleton<NetObjectPool>
	{
		public ArrayGCPool<byte> mStreamPool = new ArrayGCPool<byte>();
		public ObjectPool<NetPackage> mNetPackagePool = new ObjectPool<NetPackage> ();
	}
}