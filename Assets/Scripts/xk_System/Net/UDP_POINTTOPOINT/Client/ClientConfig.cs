﻿using System.Collections;
using System.Collections.Generic;
using System;

namespace xk_System.Net.UDP.POINTTOPOINT.Client
{
	public class ClientConfig
	{
		public const bool IsLittleEndian = false;
		public const bool bNeedCheckPackage = true;

		//Udp Package OrderId
		public const UInt16 nUdpMinOrderId = 1;
		public const UInt16 nUdpMaxOrderId = UInt16.MaxValue;

		public const int nUdpCombinePackageFixedSize = 4096;
		public const int nUdpPackageFixedSize = 512;
		public const int nUdpPackageFixedHeadSize = 10;
		public const int nUdpPackageFixedBodySize = nUdpPackageFixedSize - nUdpPackageFixedHeadSize;
	}
}