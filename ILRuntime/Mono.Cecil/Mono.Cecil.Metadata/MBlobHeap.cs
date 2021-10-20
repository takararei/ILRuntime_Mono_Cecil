using System;

namespace ILRuntime.Mono.Cecil.Metadata
{

    sealed class MBlobHeap : BlobHeap
    {

        public MBlobHeap(byte[] data)
            : base(data)
        {
        }

        public MBlobHeap(byte[] bytes, int offset, int size) : base(bytes, offset, size)
        {
        }

        public override byte[] Read(uint index)
        {
            if (index == 0 || index > Length - 1)
            {
                return Empty<byte>.Array;
            }


            int position = (int)index + Offset;
            int length = (int)data.ReadCompressedUInt32(ref position);

            if (length > Length - index)
            {
                return Empty<byte>.Array;
            }

            var buffer = new byte[length];

            Buffer.BlockCopy(data, position, buffer, 0, length);
            return buffer;
        }

        public override void GetView(uint signature, out byte[] buffer, out int index, out int length)
        {
            if (signature == 0 || signature > Length - 1)
            {
                buffer = null;
                index = length = 0;
                return;
            }

            buffer = data;
            index = (int)signature + Offset;
            length = (int)buffer.ReadCompressedUInt32(ref index);
        }
    }
}
