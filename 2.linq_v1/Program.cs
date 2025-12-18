namespace MyProject;

class Program
{
    static void Main(string[] args)
    {
        string s1 = "bbab";
        string s2 = "bbbb";

        bool checkTrue= s1.Any(s => s != s1[0]);
        Console.WriteLine(checkTrue);

        bool checkFalse= s2.Any(s => s != s1[0]);
        Console.WriteLine(checkFalse);
    }
}
