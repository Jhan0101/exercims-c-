using System.IO.Pipelines;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        if(operation is null)
        {
            throw new ArgumentNullException(nameof(operation));
        }
        if(operation == string.Empty)
        {
            throw new ArgumentException("Operation cannot be an empty string.", nameof(operation));
        }
        int result;

        switch(operation)
        {
            case "+":
                  result = SimpleOperation.Addition(operand1, operand2);
                 break;
            case "*": 
                   result = SimpleOperation.Multiplication(operand1, operand2);
                break;
            case "/":
                try
                {
                    result = SimpleOperation.Division(operand1, operand2);
                }
                catch (DivideByZeroException)
                {
                    return "Division by zero is not allowed";
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof (operation), $"Operation '{operation}' is not supported");      
        };
        return $"{operand1} {operation} {operand2} = {result}";
    }
}
public static class SimpleOperation
{
    public static int Division(int operand1, int operand2)
    {
        return operand1 / operand2;
    }

    public static int Multiplication(int operand1, int operand2)
    {
        return operand1 * operand2;
    }

    public static int Addition(int operand1, int operand2)
    {
        return operand1 + operand2;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(SimpleCalculator.Calculate(16, 51, "+"));   // 16 + 51 = 67
        Console.WriteLine(SimpleCalculator.Calculate(32, 6, "*"));    // 32 * 6 = 192
        Console.WriteLine(SimpleCalculator.Calculate(512, 4, "/"));   // 512 / 4 = 128
        Console.WriteLine(SimpleCalculator.Calculate(512, 0, "/"));   // Division by zero is not allowed.

        try
        {
            SimpleCalculator.Calculate(100, 10, "-");
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine($"Error esperado: {e.Message}");
        }
    }
}