//
// Author:
//   Jb Evain (jbevain@gmail.com)
//
// Copyright (c) 2008 - 2015 Jb Evain
// Copyright (c) 2008 - 2011 Novell, Inc.
//
// Licensed under the MIT/X11 license.
//

namespace ILRuntime.Mono.Cecil.Metadata {

	abstract class Heap {
		public int Offset;
		public int Length;
		public int IndexSize;

		readonly internal byte [] data;

		protected Heap (byte [] data)
		{
			this.data = data;
			this.Offset = 0;
			this.Length = data.Length;
		}

		protected Heap(byte[] data, int offset,int length)
		{
			this.data = data;
			this.Offset = offset;
			this.Length = length;
		}
	}
}
