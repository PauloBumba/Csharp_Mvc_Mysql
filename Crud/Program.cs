using System;
using Crud.Data;
using Crud.Models;
using Crud.Repository;

class Program 
{
    static void Main()
    {
        // Cria um novo cliente
        Customer customer = new Customer();
        customer.Name = "Paulo dotne Valente Bumba";
        customer.Email = "paulomvbumba@gmaoil.com";
        

        // Cria uma instância do repositório de clientes
        var customerRepository = new CustomerRepository();

        // Adiciona o novo cliente ao banco de dados
        customerRepository.CreateConstumer(customer);

        // Obtém todos os clientes do banco de dados
        var customers = customerRepository.GetAllCustomers();

        // Exibe os clientes
        Console.WriteLine("Lista de Clientes:");
        foreach (var cust in customers)
        {
            Console.WriteLine($"ID: {cust.Id}, Nome: {cust.Name}, Email: {cust.Email}");
        }
    }
}
