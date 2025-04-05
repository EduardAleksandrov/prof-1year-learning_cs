using System;
using System.Threading.Tasks;
internal class Program
{
    static async Task Main(string[] args)
    {
        await MainAsync();
        
        // polymorfizm start
        One th = new Two();
        th.Start();
        Two? thnew = th as Two; 
        thnew?.Start_new();

        Three three= new Four();
        three.Start();
        Four? threenew = three as Four;
        threenew?.Start_new();
        // end
    }

    static async void PrintAsync(string message) // void позволяет запускать поток в detache режиме не дожидаясь окончания
    {
        await Task.Delay(1000);     // имитация продолжительной работы
        Console.WriteLine(message);
    }
    static void Print(ref int x)
    {
        Thread.Sleep(3000);     // имитация продолжительной работы
        Console.WriteLine("Hello from Print");
        x++;
    }
    static async Task MainAsync()
    {
        int x = 0;
        PrintAsync("Hello World");
        PrintAsync("Hello METANIT.COM");
        await Task.Run(() => Print(ref x));
        Console.WriteLine(x);
        
        Console.WriteLine("Main End");
        await Task.Delay(3000);
    }
    
}

public abstract class One
{
    public abstract void Start();
}

public class Two: One
{
    public override void Start()
    {
        Console.WriteLine("Hello from start two");
    }
    public void Start_new()
    {
        Console.WriteLine("Hello from start_new two");
    }
}

interface Three
{
    public void Start();
}

class Four : Three
{
    public void Start()
    {
        Console.WriteLine("Hello from start four");
    }

    public void Start_new()
    {
        Console.WriteLine("Hello from start_new four");
    }
}
