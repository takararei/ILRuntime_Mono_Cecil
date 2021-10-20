namespace ILRuntime.Mono.Cecil.Metadata
{
	sealed class MUserStringHeap : UserStringHeap
	{

		public MUserStringHeap(byte[] data)
			: base(data)
		{
		}

		public MUserStringHeap(byte[] bytes, int offset, int length) : base(bytes, offset, length)
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
			int start = (int)index + Offset;

			uint length = (uint)(data.ReadCompressedUInt32(ref start) & ~1);
			if (length < 1)
				return string.Empty;

			var chars = new char[length / 2];

			for (int i = start, j = 0; i < start + length; i += 2)
				chars[j++] = (char)(data[i] | (data[i + 1] << 8));

			return new string(chars);
		}
	}
}
