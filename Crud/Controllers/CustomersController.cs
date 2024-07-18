using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.Data;
using Crud.Repository;
using Crud.Models;

namespace Crud.Controllers
{
    public class CustomersController
    {
        private CustomerRepository customerRepository;
        
        private Customer customer;
        public CustomersController()
        {
            customerRepository = new CustomerRepository();

            customer = new Customer();
        }
        public void Insert (Customer customer)
        {
           customerRepository.CreateConstumer(customer);
        }
        public void Save (int id , Customer customer)
        {
            customerRepository.UpdateCustomers(id,customer);
        }
        public List<Customer> Retrive()
        {
            return customerRepository.GetAllCustomers();
        }
        public List<Customer> RetriveName(Customer costumer)
        {
            return  customerRepository.GetByNameCustomers(costumer);
        }
        public void Delete(int id)
        {
            customerRepository.DeleteCustomeres(id);
        }
    }
} 