using System;

namespace ILRuntime.Mono.Cecil.Metadata
{

    sealed class MGuidHeap : GuidHeap
    {

        public MGuidHeap(byte[] data)
            : base(data)
        {
        }

        public MGuidHeap(byte[] bytes, int offset, int length) : base(bytes, offset, length)
        {
        }

        public override Guid Read(uint index)
        {
            const int guid_size = 16;

            if (index == 0 || ((index - 1) + guid_size) > Length)
                return new Guid();
          
            var buffer = new byte[guid_size];

            Buffer.BlockCopy(this.data, (int)((index - 1) * guid_size) + Offset, buffer, 0, guid_size);
            return new Guid(buffer);
        }
    }
}
