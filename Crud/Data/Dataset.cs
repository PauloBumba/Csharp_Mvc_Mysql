using MySql.Data.MySqlClient;
using System;

namespace Crud.Data
{
    public class Dataset
    {
        private MySqlConnection connection;

        public Dataset()
        {
            string ConnectionString = "server=localhost; uid=root; database=CustomerDB;password=root;";

            connection = new MySqlConnection(ConnectionString);
        }

        public void OpenConnecting()
        {
            try
            {
                if (connection != null)
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        connection.Open();
                        Console.WriteLine("Conexão aberta");
                    }
                    else
                    {
                        Console.WriteLine("A conexão já está aberta");
                    }
                }
                else
                {
                    Console.WriteLine("A conexão é nula");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao abrir a conexão: " + ex.Message);
            }
        }

        public void CloseConnecting()
        {
            try
            {
                if (connection != null)
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                        Console.WriteLine("Conexão fechada");
                    }
                    else
                    {
                        Console.WriteLine("A conexão já está fechada ou não foi aberta");
                    }
                }
                else
                {
                    Console.WriteLine("A conexão é nula");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao fechar a conexão: " + ex.Message);
            }
        }
    }
}
