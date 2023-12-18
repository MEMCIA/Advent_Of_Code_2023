namespace AOC
{
    public class Number
    {
        public Number()
        {

        }

        public Number(int value, string name)
        {
            Name = name;
            Value = value;
            NameLength = name.Length;
        }

        public Number(int value,int startIndex)
        {
            Value = value;
            StartIndex = startIndex;
        }

        public int Value { get; set; }
        public string Name { get; set; }
        public int NameLength { get; set; }
        public int StartIndex { get; set; }
    }
}
