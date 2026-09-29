
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
                    return "Division by zero is not allowed.";
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof (operation), $"Operation '{operation}' is not supported");      
        };
        return $"{operand1} {operation} {operand2} = {result}";
    }
}