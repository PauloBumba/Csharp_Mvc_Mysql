using System;
using System.Collections.Generic;
using Crud.Controllers;
using Crud.Models;

namespace Crud.View
{
    public class CustumersView
    {
        private CustomersController customersController;
        private Customer customer;

        public CustumersView()
        {
            customersController = new CustomersController();
            customer = new Customer();
            Init();
        }

        private void Init()
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.WriteLine("**********************");
                Console.WriteLine("MEU PROGRAMA CONSUMIDOR");
                Console.WriteLine("**********************");
                Console.WriteLine();
                Console.WriteLine("1 - Inserir Cliente");
                Console.WriteLine("2 - Atualizar Cliente");
                Console.WriteLine("3 - Listar Todos os Clientes");
                Console.WriteLine("4 - Buscar Cliente por Nome");
                Console.WriteLine("5 - Deletar Cliente");
                Console.WriteLine("0 - SAIR");

                int menu = 0;

                try
                {
                    menu = Convert.ToInt32(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            InsertCustomer();
                            break;

                        case 2:
                            UpdateCustomer();
                            break;

                        case 3:
                            ListAllCustomers();
                            break;

                        case 4:
                            SearchCustomerByName();
                            break;

                        case 5:
                            DeleteCustomer();
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

        private void InsertCustomer()
        {
            Console.WriteLine("Inserir Cliente");
            Console.Write("Nome: ");
            customer.Name = Console.ReadLine();
            Console.Write("Email: ");
            customer.Email = Console.ReadLine();
            customersController.Insert(customer);
            Console.WriteLine("Cliente inserido com sucesso!");
            Console.WriteLine(new string('-', 80));

        }

        private void UpdateCustomer()
        {
            Console.WriteLine("Atualizar Cliente");
            Console.Write("ID do Cliente: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            customer = new Customer
            {
                Name = name,
                Email = email
            };

            customersController.Save(id, customer);
            Console.WriteLine("Cliente atualizado com sucesso!");
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("");

        }

        private void ListAllCustomers()
        {
            var customers = customersController.Retrive();
            Console.WriteLine("{0,-5} {1,-30} {2,-30}", "ID", "Nome", "Email");
             Console.WriteLine(new string('-', 80));

            foreach (var cust in customers)
            {
                Console.WriteLine("{0,-5} {1,-30} {2,-30}", cust.Id, cust.Name, cust.Email);
            }
            Console.WriteLine();
        }

        private void SearchCustomerByName()
        {
            Console.WriteLine("Buscar Cliente por Nome");
            Console.Write("Nome: ");
            string name = Console.ReadLine();

            customer.Name = name;
            var customers = customersController.RetriveName(customer);

            Console.WriteLine("{0,-5} {1,-30} {2,-30}", "ID", "Nome", "Email");
            Console.WriteLine(new string('-', 80));

            foreach (var cust in customers)
            {
                Console.WriteLine("{0,-5} {1,-30} {2,-30}", cust.Id, cust.Name, cust.Email);
            }
            Console.WriteLine();
        }

        private void DeleteCustomer()
        {
            Console.WriteLine("Deletar Cliente");
            Console.Write("ID do Cliente: ");
            int id = Convert.ToInt32(Console.ReadLine());

            customersController.Delete(id);
            Console.WriteLine("Cliente deletado com sucesso!");
            Console.WriteLine(new string('-', 80));

        }
    }
}
