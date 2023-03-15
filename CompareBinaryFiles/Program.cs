internal class Program
{
    private static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            try
            {
                Console.WriteLine("Introduzca la dirección del primer archivo.");
                string dir1 = Console.ReadLine();
                Console.WriteLine("Introduzca la dirección del segundo archivo.");
                string dir2 = Console.ReadLine();

                if (dir1.Any() && dir2.Any())
                {
                    byte[]? file1 = File.ReadAllBytes(dir1);
                    byte[]? file2 = File.ReadAllBytes(dir2);

                    bool equals = file1.Length == file2.Length;

                    for (int i = 0; i < file1.Length; i++)
                    {
                        equals &= file1[i] == file2[i];
                    }

                    ShowMessage(equals);
                    CanContinue(ref continuar);
                }
                else
                {
                    Console.WriteLine($"Las direcciones no pueden estar vacías.");
                    CanContinue(ref continuar);
                }

            }
            catch (Exception ex)
            {
                continuar = false;
                Console.WriteLine($"Ha ocurrido el siguiente problema: {ex.ToString()}");
            }
        }
    }

    private static void ShowMessage(bool flag)
    {
        if (flag)
        {
            Console.WriteLine($"Los archivos son iguales.");
        }
        else
        {
            Console.WriteLine($"Los archivos no son iguales.");
        }
    }

    private static void CanContinue(ref bool continuar)
    {
        Console.WriteLine("Desea continuar. (S/N)");
        continuar = (Console.ReadLine().Equals('S') || Console.ReadLine().Equals('s'));
    }
}