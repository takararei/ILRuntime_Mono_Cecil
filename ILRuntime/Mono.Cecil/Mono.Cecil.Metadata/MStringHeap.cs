using System.Text;

namespace ILRuntime.Mono.Cecil.Metadata
{
    class MStringHeap : StringHeap
    {
        public MStringHeap(byte[] data)
            : base(data)
        {
        }

        public MStringHeap(byte[] bytes, int offset, int size) : base(bytes, offset, size)
        {
        }

        public override string Read(uint index)
        {
            if (index == 0)
                return string.Empty;

            string @string;
            if (strings.TryGetValue(index, out @string))
                return @string;

            if (index > Length - 1)
                return string.Empty;

            @string = ReadStringAt(index);
            if (@string.Length != 0)
                strings.Add(index, @string);

            return @string;
        }
        protected override string ReadStringAt(uint index)
        {
            int length = 0;
            int start = (int)index + Offset;

            for (int i = start; ; i++)
            {
                if (data[i] == 0)
                    break;

                length++;
                if (length >= Length)
                    break;
            }

            return Encoding.UTF8.GetString(data, start, length);
        }
    }
}
