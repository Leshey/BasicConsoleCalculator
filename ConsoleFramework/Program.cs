using System.Text;

public class Program 
{
    public static void Main()
    {
        Console.WriteLine("Enter example in a + b format and then press Enter\n" +
            "Press E before or after any operation to Exit");
        RunCalculator();
    }

    public static void RunCalculator() 
    {
        while(true) 
        {
        ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
            if (consoleKeyInfo.Key == ConsoleKey.E) 
            {
                long firstNum = GetNumInput();
                char op = OperatorInput();
                long secondNum = GetNumInput();
                PrintResult(firstNum, secondNum, op);
            }
            else 
            {
                break;
            }
        }
    }

    public static long GetNumInput() 
    {
        StringBuilder stringBuilder = new StringBuilder();
        while (true)
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
            if (char.IsDigit(consoleKeyInfo.KeyChar))
            {
                stringBuilder.Append(consoleKeyInfo.KeyChar);
                Console.Write(consoleKeyInfo.KeyChar);
            }
            else if ((consoleKeyInfo.Key == ConsoleKey.Spacebar || consoleKeyInfo.Key == ConsoleKey.Enter) && stringBuilder.Length > 0) 
            {
                if (consoleKeyInfo.Key == ConsoleKey.Enter) 
                {
                    Console.Write((char)ConsoleKey.Spacebar);
                }
                else 
                {
                    Console.Write(consoleKeyInfo.KeyChar);
                }
                return Convert.ToInt64(stringBuilder.ToString());
            }
            else if (consoleKeyInfo.Key == ConsoleKey.Backspace && stringBuilder.Length > 0)
            {
                Backspace(stringBuilder.Length);
                stringBuilder.Length--;
            }
        }
    }
  
    public static char OperatorInput() 
    {
        StringBuilder stringBuilder = new StringBuilder();
        List<char> opList = new List<char>() {'+', '-', '/', '*'};
        
        while (true) 
        {
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
            if (opList.Contains(consoleKeyInfo.KeyChar) && stringBuilder.Length < 1)
            {
                stringBuilder.Append(consoleKeyInfo.KeyChar);
                Console.Write(consoleKeyInfo.KeyChar);
            }
            else if (consoleKeyInfo.Key == ConsoleKey.Spacebar && stringBuilder.Length > 0) 
            {
                Console.Write(consoleKeyInfo.KeyChar);
                return Convert.ToChar(stringBuilder.ToString());
            }
            else if (consoleKeyInfo.Key == ConsoleKey.Backspace)
            {
                Backspace(stringBuilder.Length);
                stringBuilder.Clear();
            }
        }
    }

    public static long ExecuteMath(long num1, long num2, char op) 
    {
        switch (op) 
        {
            case '+': return num1 + num2;
            case '-': return num1 - num2;
            case '*': return num1 * num2;
            case '/':
                try 
                {    
                if (num2 != 0)
                        return num1 / num2;
                    else
                        throw new DivideByZeroException("You cannot divide by zero!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                default: return 0;
        }       
    }

    public static void PrintResult(long num1, long num2, char op) 
    {
        long result = ExecuteMath(num1, num2, op);
        Console.WriteLine($"= {result}");
    }

    public static void Backspace(int strLength)
    {
        if (strLength > 0)
            Console.Write("\b \b");
    }
}