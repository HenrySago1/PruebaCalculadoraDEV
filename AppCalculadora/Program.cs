using System;

namespace AppCalculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("       BIENVENIDO A APPCALCULADORA       ");
            Console.WriteLine("========================================");

            Calculator calc = new Calculator();
            bool running = true;

            // Si se pasa un argumento, puede servir para automatización o ejecución rápida
            if (args.Length > 0 && args[0] == "--demo")
            {
                RunDemo(calc);
                return;
            }

            while (running)
            {
                Console.WriteLine("\nSeleccione una operación:");
                Console.WriteLine("1. Sumar (+)");
                Console.WriteLine("2. Restar (-)");
                Console.WriteLine("3. Multiplicar (*)");
                Console.WriteLine("4. Dividir (/)");
                Console.WriteLine("5. Salir");
                Console.Write("Opción (1-5): ");

                string? opcion = Console.ReadLine();

                if (opcion == "5")
                {
                    running = false;
                    Console.WriteLine("¡Gracias por usar AppCalculadora!");
                    break;
                }

                if (opcion != "1" && opcion != "2" && opcion != "3" && opcion != "4")
                {
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    continue;
                }

                try
                {
                    Console.Write("Ingrese el primer número: ");
                    double num1 = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Ingrese el segundo número: ");
                    double num2 = Convert.ToDouble(Console.ReadLine());

                    double resultado = 0;
                    string operacion = "";

                    switch (opcion)
                    {
                        case "1":
                            resultado = calc.Add(num1, num2);
                            operacion = "Suma";
                            break;
                        case "2":
                            resultado = calc.Subtract(num1, num2);
                            operacion = "Resta";
                            break;
                        case "3":
                            resultado = calc.Multiply(num1, num2);
                            operacion = "Multiplicación";
                            break;
                        case "4":
                            resultado = calc.Divide(num1, num2);
                            operacion = "División";
                            break;
                    }

                    Console.WriteLine($"\n--> Resultado de la {operacion}: {num1} y {num2} es: {resultado}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Por favor, ingrese un número válido.");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                }

                Console.WriteLine("----------------------------------------");
            }
        }

        static void RunDemo(Calculator calc)
        {
            Console.WriteLine("Ejecutando demostración automática...");
            Console.WriteLine($"Demo Suma: 5 + 3 = {calc.Add(5, 3)}");
            Console.WriteLine($"Demo Resta: 10 - 4 = {calc.Subtract(10, 4)}");
            Console.WriteLine($"Demo Multiplicación: 6 * 7 = {calc.Multiply(6, 7)}");
            try
            {
                Console.WriteLine($"Demo División: 20 / 4 = {calc.Divide(20, 4)}");
                Console.WriteLine("Demo División por cero...");
                calc.Divide(5, 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Excepción capturada con éxito: {ex.Message}");
            }
        }
    }
}
