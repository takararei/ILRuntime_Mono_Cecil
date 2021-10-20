using System.IO;

namespace ILRuntime.Mono.Cecil
{
    public class MonoMemoryStream : MemoryStream
    {
        public byte[] Buffer => bytes;
        private byte[] bytes;
        public int OriOffset => oriOffset;
        private int oriOffset;

        public int OriLength => oriLength;
        private int oriLength;

        public MonoMemoryStream(byte[] buffer, int offset, int length) : base(buffer, offset, length, true)
        {
            bytes = buffer;
            oriOffset = offset;
            oriLength = length;
        }

    }
}
