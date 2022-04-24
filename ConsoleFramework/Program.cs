using System.Text;

public class Program 
{
    public static void Main()
    {
        Console.WriteLine("Enter example in a + b format and then press Enter");
        int firstNum = FirstNumInput();
        char op = OperatorInput();
        int secondNum = SecondNumInput();
        PrintResult(firstNum, secondNum, op);    

    }

    public static void Backspace()
    {
        Console.Write("\b \b");
    }

    public static int FirstNumInput() 
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
            else if (consoleKeyInfo.Key == ConsoleKey.Spacebar && stringBuilder.Length > 0) 
            {
                Console.Write(consoleKeyInfo.KeyChar);
                return Convert.ToInt32(stringBuilder.ToString());
            }
            else if (consoleKeyInfo.Key == ConsoleKey.Backspace)
            {
                Backspace();
                stringBuilder.Length--;
            }
            
        }
    }
    public static int SecondNumInput()
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
            else if (consoleKeyInfo.Key == ConsoleKey.Spacebar || consoleKeyInfo.Key == ConsoleKey.Enter && stringBuilder.Length > 0)
            {
                return Convert.ToInt32(stringBuilder.ToString());
            }
            else if (consoleKeyInfo.Key == ConsoleKey.Backspace)
            {
                Backspace();
                stringBuilder.Length--;
                
            }
        }
    }

    public static char OperatorInput() 
    {
        StringBuilder stringBuilder = new StringBuilder();
        List<char> opList = new List<char>();
        opList.Add('+');
        opList.Add('-');
        opList.Add('/');
        opList.Add('*');
        
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
                Backspace();
                stringBuilder.Clear();
            }
        }
    }

    public static int ExecuteMath(int num1, int num2, char op) 
    {
        switch (op) 
        {
            case '+': return num1 + num2;
            case '-': return num1 - num2;
            case '*': return num1 * num2;
            case '/': 
                if (num2 != 0) 
                    return num1 / num2;
                else 
                    Console.WriteLine("\nYou cannot divide by zero!");
                    return 0;
            default: return 0;
        }       
    }

    public static void PrintResult(int num1, int num2, char op) 
    {
        int result = ExecuteMath(num1, num2, op);
        if (op != '/' && num2 != 0)
        {
            Console.WriteLine($"\nResult is: {result}");
        }
    }
}