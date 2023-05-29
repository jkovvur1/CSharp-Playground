// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

// where
List<int> numbers = new List<int>(){ 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

var lowNums = from num in numbers
              where num < 5
              select num;

Console.WriteLine("Numbers < 5");
foreach(var x in lowNums)
{
    Console.WriteLine(x);
}


// Select
int[] numbersOne = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

var textNums = from n in numbersOne
               select strings[n];

Console.WriteLine("Number strings:");
foreach(var s in textNums)
{
    Console.WriteLine(s);
}

//Take
var first3Numbers = numbersOne.Take(3);

Console.WriteLine("First 3 Numbers:");
foreach(var n in first3Numbers)
{
    Console.WriteLine(n);

}

var firstNumbersLessThan6 = numbersOne.TakeWhile(n => n < 6);
Console.WriteLine("First Numbers Less Than 6:");
foreach (var n in firstNumbersLessThan6)
{
    Console.WriteLine(n);

}

// Sequence
var wordsA = new string[] { "cherry", "apple", "blueberry" };
var wordsB = new string[] { "cherry", "apple", "blueberry" };
bool match = wordsA.SequenceEqual(wordsB);

Console.WriteLine($"The sequence match: {match}");

// Combining Sequences with Zip
int[] vectorA = { 0, 2, 4, 5 ,6};
int[] vectorB = { 1, 3, 5, 7, 8 };


int dotProduct = vectorA.Zip(vectorB, (a, b) => a * b).Sum();

Console.WriteLine($"Dot product: {dotProduct}");


// Combining Multiple Input Sequences
int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
int[] numbersB = { 1, 3, 5, 7, 8 };

var pairs = from a in numbersA
            from b in numbersB
            where a < b
            select (a, b);

Console.WriteLine("Pairs where a < b");
foreach(var pair in pairs)
{
    Console.WriteLine($"{pair.a} is less than {pair.b}");
}

// Lazy Execution

int i = 0;
var q = from n in numbers
        select ++i;

foreach(var v in q)
{
    Console.WriteLine($"v = {v}, i = {i}");
}