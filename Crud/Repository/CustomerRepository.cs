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
        private Customer customer;
        private Dataset dataset;
        public CustomerRepository()
        {
            dataset = new Dataset();
            customer = new Customer();
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
                            // Cria um novo objeto Customer e preenche os dados

                            var customer = new Customer
                            {
                                Id = reader.GetInt32(0), // ID

                                Name = reader.GetString(1), // Nome

                                Email = reader.GetString(2) // Email
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
        public List<Customer> GetByNameCustomers(Customer customer)
{
    var customers = new List<Customer>();

    try
    {
        dataset.OpenConnecting();

        string query = "SELECT * FROM CUSTOMERS WHERE NOME LIKE @NOME";

        using (var command = new MySqlCommand(query, dataset.Connection))
        {
            // Adiciona o parâmetro de consulta
            command.Parameters.AddWithValue("@NOME", "%" + customer.Name + "%");

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Cria um novo objeto Customer e preenche os dados
                    var cust = new Customer
                    {
                        Id = reader.GetInt32(0), // ID
                        Name = reader.GetString(1), // Nome
                        Email = reader.GetString(2), // Email
                        // Adicionando o telefone ao modelo Customer, se aplicável
                        // Phone = reader.GetString(3)
                    };

                    // Adiciona o cliente à lista
                    customers.Add(cust);
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

        public void UpdateCustomers(int Id, Customer customer)
        {
            try
            {
                dataset.OpenConnecting();

                string query = "UPDATE CUSTOMERS SET NOME= @NOME , EMAIL=@EMAIL WHERE ID=@ID";

                using (var command= new MySqlCommand(query, dataset.Connection))
                {
                    command.Parameters.AddWithValue("@NOME",customer.Name );

                    command.Parameters.AddWithValue("@EMAIL",customer.Email );

                    command.Parameters.AddWithValue("@ID",Id);

                    var fect = command.ExecuteNonQuery();

                    string Message = fect > 0 ?  "Valores atualizado com sucesso": "erro ao fazer atualização dos valores";

                    Console.WriteLine(Message);
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("Font do erro " + ex.Source);

                Console.WriteLine("Mensagem do erro " + ex.Message);

                Console.WriteLine("Numero do erro " + ex.Number);
            }  
            finally{
                dataset.CloseConnecting();
            } 

        }
        public void DeleteCustomeres(int id){
            try
            {
                dataset.OpenConnecting();

                string query = "DELETE FROM CUSTOMERS WHERE ID=@ID";

                using(var command = new MySqlCommand(query, dataset.Connection))
                {
                    command.Parameters.AddWithValue("@ID",id);

                    var fect = command.ExecuteNonQuery();

                    string Message = fect > 0 ? $"Deletado a coluna {customer.Id} com sucesso" : $"Erro ao deletar a coluna  {customer.Id} do banco de dados";
                }
            }
            catch(MySqlException   ex)
            {
                Console.WriteLine("Font do erro " + ex.Source);

                Console.WriteLine("Mensagem do erro " + ex.Message);

                Console.WriteLine("Numero do erro " + ex.Number);
            }  
            
            finally
            {
                dataset.CloseConnecting();
            }
        }

        }
    }