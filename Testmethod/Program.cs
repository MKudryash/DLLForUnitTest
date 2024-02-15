// See https://aka.ms/new-console-template for more information
using DLLForUnitTest;

ClassForTest classForTest = new ClassForTest();
string[] s1 = { "зарево", "зорька", "зарница", "озарение", "заря", "озарить", "озаряться", "лучезарный" };
string s2 = "";
foreach (string s in s1)
{
    int diff = classForTest.LevenshteinDistance(s, null);
    if (diff <= 3)
    {
        Console.WriteLine(s + "\n");
    }
}