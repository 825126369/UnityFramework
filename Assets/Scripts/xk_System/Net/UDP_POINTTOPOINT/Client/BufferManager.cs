﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;

namespace xk_System.Net.UDP.POINTTOPOINT.Client
{
	public class BufferManager:Singleton<BufferManager>
	{
		private int Length;
		private byte[] m_buffer;
		private Stack<int> m_freeIndexPool;
		private int nReadIndex = 0;
		private int nBufferSize = 0;

		public BufferManager()
		{
			this.Init (ClientConfig.nMaxBufferSize * 128, ClientConfig.nMaxBufferSize);
		}

		public void Init (int totalBytes,int nBufferSize)
		{
			this.Length = totalBytes;
			this.nReadIndex = 0;
			this.m_freeIndexPool = new Stack<int> ();
			this.m_buffer = new byte[Length];
			this.nBufferSize = nBufferSize;
		}
			
		public bool SetBuffer (SocketAsyncEventArgs args)
		{
			if (m_freeIndexPool.Count > 0) {
				args.SetBuffer (m_buffer, m_freeIndexPool.Pop (), nBufferSize);
			} else {
				if (nReadIndex + nBufferSize > Length) {
					return false;
				}
				args.SetBuffer (m_buffer, nReadIndex, nBufferSize);
				nReadIndex += nBufferSize;
			}
			return true;
		}

		public void FreeBuffer (SocketAsyncEventArgs args)
		{
			m_freeIndexPool.Push (args.Offset);
			args.SetBuffer (null, 0, 0);
		}

		public bool SetBuffer (out ArraySegment<byte> args)
		{
			if (m_freeIndexPool.Count > 0) 
			{
				args = new ArraySegment<byte> (m_buffer, m_freeIndexPool.Pop (), nBufferSize);
				return true;
			}
			else 
			{
				if (nReadIndex + nBufferSize > Length) {
					return false;
				}
				var result = new ArraySegment<byte> (m_buffer, nReadIndex, nBufferSize);
				nReadIndex += nBufferSize;

				return  true;
			}

			return false;
		}

		public void FreeBuffer (ArraySegment<byte> args)
		{
			m_freeIndexPool.Push (args.Offset);
		}

	}
}