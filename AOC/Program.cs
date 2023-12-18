
//Exercise 1

using AOC;

string path = @"../../../Input_day_1.txt";
int sum1 = GetTotalSum(path, false);
Console.WriteLine("Sum ex.1: " + sum1);//54388

//Exercise 2

int sum2 = GetTotalSum(path, true);
Console.WriteLine("Sum ex.2: " + sum2);//53515

//https://stackoverflow.com/questions/55700352/index-and-range-operators-what-are-they

int GetTotalSum(string path, bool isNumberNameDigit)
{
    int sum = 0;

    using (StreamReader sr = File.OpenText(path))
    {
        string line;

        while ((line = sr.ReadLine()) != null)
        {
            AddNumerFromLine(line, ref sum, isNumberNameDigit);
        }
    }

    return sum;
}

void AddNumerFromLine(string line, ref int totalSum, bool isNumberNameDigit)
{
    List<Number> onlyDigits = [.. GetOnlyDigitsFromLine(line)];
    if (isNumberNameDigit) onlyDigits.AddRange(GetDigitsWrittenAsNamesFromLine(line));

    onlyDigits = onlyDigits
        .OrderBy(x => x.StartIndex)
        .Select(x => x)
        .ToList();

    totalSum += GetFinalNumberFromLine(onlyDigits);
}

int GetFinalNumberFromLine(IEnumerable<Number> onlyNumbers)
{
    if (!onlyNumbers.Any()) return 0;

    return onlyNumbers.First().Value * 10 + onlyNumbers.Last().Value;
}

IEnumerable<Number> GetOnlyDigitsFromLine(string line)
{
    int number = 0;

    return Enumerable.Range(0,line.Length)
        .Where(x => Int32.TryParse(line[x].ToString(), out number))
        .Select(x =>
        {
            return new Number(number, x);
        });
}

List<Number> GetDigitsWrittenAsNamesFromLine(string line)
{
    List<Number> numbersInLine = new List<Number>();

    foreach (var number in Numbers.List)
    {
        numbersInLine.AddRange(line.AllIndexesOf(number.Name, number.Value));
    }

    return numbersInLine;
}


