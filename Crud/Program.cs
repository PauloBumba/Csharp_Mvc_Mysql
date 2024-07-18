using System;
using Crud.View;

class Program 
{
    static void Main()
    {
        bool continueRunning = true;

        while (continueRunning)
        {
            Console.WriteLine("**********************");
            Console.WriteLine("MEU PROGRAMA C# COM MYSQL");
            Console.WriteLine("**********************");
            Console.WriteLine();

            Console.WriteLine("1 - Clientes");
           
            Console.WriteLine("0 - SAIR");

            int menu = 0;

            try
            {
                menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                       CustumersView custumersView = new CustumersView();
                       
                        break;

                    case 2:
                        
                        break;

                    case 3:
                       
                        break;

                    case 0:
                        continueRunning = false;
                        Console.WriteLine("Obrigado e volte sempre!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Opção inválida. Erro: " + ex.Message);
            }
        }
    }
}
