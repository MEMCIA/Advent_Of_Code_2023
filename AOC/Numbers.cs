namespace AOC
{
    public static class Numbers
    {
        public static List<Number> List = new()
        {
                new Number(1, "one"),
                new Number(2, "two"),
                new Number(3, "three"),
                new Number(4, "four"),
                new Number(5, "five"),
                new Number(6, "six"),
                new Number(7, "seven"),
                new Number(8, "eight"),
                new Number(9, "nine")
        };

        public static IEnumerable<Number> AllIndexesOf(this string line, string numberName, int number)
        {
            int numberNameIndex = line.IndexOf(numberName);
            while (numberNameIndex != -1)
            {
                yield return new Number(number, numberNameIndex);
                numberNameIndex = line.IndexOf(numberName, numberNameIndex + 1);
            }
        }
    }
}
