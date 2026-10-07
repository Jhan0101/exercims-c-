using System;

class Calculadora
{

    public void MostrarMenu()
    {
        int opc;
        do
        {
            Console.Clear();
            Console.WriteLine(".:MENU:.");
            Console.WriteLine("1. SUMA.");
            Console.WriteLine("2. RESTA.");
            Console.WriteLine("3. MULTIPLICACION.");
            Console.WriteLine("4. DIVISION.");
            Console.WriteLine("5. RAIZ CUADRADA.");
            Console.WriteLine("6. SALIR.");
            while (!int.TryParse(Console.ReadLine(), out opc))
            {
                Console.WriteLine("Tipo de dato invalido");
            }
            EjecutarOpcion(opc);

            if (opc != 6)
            {
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }

        } while (opc != 6);
    }

    private void EjecutarOpcion(int opc)
    {

        switch (opc)
        {
            case 1:
                EjecutarSuma();
                break;

            case 2:
                EjecutarResta();
                break;

            case 3:
                EjecutarMult();
                break;

            case 4:
                EjecutarDivision();
                break;

            case 5:
                EjecutarRaiz();
                break;

            case 6:
                Console.WriteLine("Saliendo...");
                break;

            default:
                Console.WriteLine("Opcion invalida");
                break;
        }
    }

    private double PedirNumero()
    {
        double numero;
        Console.WriteLine("");
        Console.WriteLine("Digite un numero");

        while (!double.TryParse(Console.ReadLine(), out numero))
        {
            Console.WriteLine("Tipo de dato invalido");
        }

        return numero;
    }

    private double Sumar(double a, double b)
    {
        return a + b;
    }

    private void EjecutarSuma()
    {
        double a = PedirNumero();
        double b = PedirNumero();

        Console.WriteLine($"{a} + {b} = {Sumar(a, b)}");
    }

    private double Restar(double a, double b)
    {
        return a - b;
    }
    private void EjecutarResta()
    {
        double a = PedirNumero();
        double b = PedirNumero();

        Console.WriteLine($"{a} - {b} = {Restar(a, b)}");
    }

    private double Multiplicar(double a, double b)
    {
        return a * b;
    }
    private void EjecutarMult()
    {
        double a = PedirNumero();
        double b = PedirNumero();

        Console.WriteLine($"{a} x {b} = {Multiplicar(a, b)}");
    }

    private double Dividir(double a, double b)
    {
        return a / b;
    }
    private void EjecutarDivision()
    {
        double a = PedirNumero();
        double b = PedirNumero();
        while (b == 0)
        {
            Console.WriteLine("El divisor no puede ser 0.");
            b = PedirNumero();
        }

        Console.WriteLine($"{a} / {b} = {Dividir(a, b)}");
    }

    private double Raiz(double a)
    {
        return Math.Sqrt(a);
    }
    private void EjecutarRaiz()
    {
        double a = PedirNumero();
        {
            while (a < 0)
            {
                Console.WriteLine("No se puede sacar raiz cuadrada de un numero negativo.");
                a = PedirNumero();
            }



            Console.WriteLine($"La raiz cuadrada de {a} es {Raiz(a)}");
        }
    }
}
class Program
{
    public static void Main()
    {
        Calculadora calculadora = new Calculadora();

        calculadora.MostrarMenu();
    }
}

