using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp;
using CustomerApp.Models;

namespace CustomerApp.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerDbContext _context;
        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }
        public CustomerRepository()
        {

        }
        public async Task<CustomerEntity> AddCustomer(CustomerEntity customer)
        {
            await _context.customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteCustomer(Guid CustomerID)
        {
            CustomerEntity cust = GetCustomerByID(CustomerID);
            if (cust != null)
            {
                _context.customers.Remove(cust);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public IEnumerable<CustomerEntity> GetAllCustomers()
        {
           var aa = _context.customers.ToList();
            return aa;
        }

        public CustomerEntity GetCustomerByID(Guid CustomerID)
        {
            CustomerEntity cust = _context.customers.Where(a => a.CustomerId == CustomerID).FirstOrDefault();
            return cust;
        }

        public async Task<CustomerEntity> UpdateCustomer(CustomerEntity customer)
        {
            CustomerEntity cust = GetCustomerByID(customer.CustomerId);
            if (cust != null) {
                _context.customers.Update(customer);
                await _context.SaveChangesAsync();
            }

            return customer;
        }
    }
}
