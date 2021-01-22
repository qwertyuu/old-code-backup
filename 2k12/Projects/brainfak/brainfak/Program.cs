using System;

public class Program
{

    public static void Main()
    {
        int p = 0;
        char[] m = new char[32768];
        m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++;
        while (m[p] != 0)
        {
            p++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; p--; m[p]--;
        }
        p++; m[p]--; m[p]--; p++;
        m[p] = ConsoleChar();
        p++;
        m[p] = ConsoleChar();
        p--; p--;
        while (m[p] != 0)
        {
            p++; m[p]--; p--; m[p]--;
        }
        p--; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++;
        while (m[p] != 0)
        {
            p++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; p--; m[p]--;
        }
        p++; m[p]--; m[p]--;
        while (m[p] != 0)
        {
            p++; p++; m[p]--; m[p]--; p--; p--; m[p]--; m[p]--;
        }
        p--; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++;
        while (m[p] != 0)
        {
            p++; p++; p++; p++; m[p]++; p++; m[p]++; m[p]++; m[p]++; p++; m[p]++; p++; m[p]++; p--; p--; p--; p--; p--; p--; p--; m[p]--;
        }
        p++; p++; p++; p++; p++; p++; m[p]--; p--; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; p++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++; m[p]++;
        while (m[p] != 0)
        {
            p--;
            Console.Write(m[p]);
            p++; m[p]--;
        }
        p--; p--; p--; m[p]++;
        while (m[p] != 0)
        {
            p++; p++;
            Console.Write(m[p]);
            p--;
            Console.Write(m[p]);
            p++; p++; p++; m[p]--; p--; p--; p--; p--; m[p]--;
        }
        p++; p++;
        Console.Write(m[p]);
        m[p]--; m[p]--; m[p]--; p--; p--; p--;
        while (m[p] != 0)
        {
            p++; p++; p++;
            Console.Write(m[p]);

            Console.Write(m[p]);
            p--; p--; p--; m[p]--;
        }
        p++; p++; p++; m[p]++; m[p]++; m[p]++;
        Console.Write(m[p]);
        p--;
        Console.Write(m[p]);
        p++; p++; p++;
        while (m[p] != 0)
        {
            p--; p--;
            Console.Write(m[p]);
            p--;
            Console.Write(m[p]);
            p++; p++; p++; m[p]--;
        }
        Console.ReadKey(true);

    }

    private static char ConsoleChar()
    {
        string lel = Console.ReadLine();
        return lel[0];
    }

}