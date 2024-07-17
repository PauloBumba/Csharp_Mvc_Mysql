using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Crud.Data;
using Crud.Models;

namespace Crud.Repository
{
    public class CustomerRepository
    {
        private Customer customer1;
        private Dataset dataset;
        public CustomerRepository()
        {
            dataset = new Dataset();
            customer1 = new Customer();
        }
       
        public void CreateConstumer(Customer customer)
        {
            try
            {
                dataset.OpenConnecting();
                string query = "INSERT INTO CUSTOMERS (NOME , EMAIL) VALUES(@NOME, @EMAIL)";

                using (var command = new MySqlCommand (query , dataset.Connection))
                {
                    command.Parameters.AddWithValue("@NOME", customer.Name);
                    command.Parameters.AddWithValue("@EMAIL", customer.Email);

                  
                    var  Infect = command.ExecuteNonQuery ();
                    if (Infect >0){
                       
                        Console.WriteLine("Valores inserido com sucesso");
                    }
                    else{
                        throw new Exception("Erro ao inserir valores no banco de dados ");
                    }
                    
                }
            }
            catch(MySqlException   ex )
            {
                    Console.WriteLine($"errro number : {ex.Number}");
                    Console.WriteLine($"erro fonte : {ex.Source}");
                    Console.WriteLine(ex.Message);
            } 
            finally
            {
                dataset.CloseConnecting();
            }          
        }
        public List<Customer> GetAllCustomers()
{
    var customers = new List<Customer>();

    try
    {
        dataset.OpenConnecting();
        string query = "SELECT Id, Nome, Email FROM Customers";

        using (var command = new MySqlCommand(query, dataset.Connection))
        {
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Cria um vetor de strings para armazenar os dados da linha atual
                    string[] row = {
                        reader.GetInt32(0).ToString(), // ID
                        reader.GetString(1), // Nome
                        reader.GetString(2), // Email
                        // Telefone
                    };

                    // Cria um novo objeto Customer e preenche os dados
                    var customer = new Customer
                    {
                        Id = Convert.ToInt32(row[0]),
                        Name = row[1],
                        Email = row[2],
                         // Adicionando o telefone ao modelo Customer, se aplicável
                    };

                    // Adiciona o cliente à lista
                    customers.Add(customer);
                }
            }
        }
    }
    catch (MySqlException ex)
    {
        Console.WriteLine($"Erro MySQL: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro geral: {ex.Message}");
    }
    finally
    {
        dataset.CloseConnecting();
    }

    return customers;
}

    }
}