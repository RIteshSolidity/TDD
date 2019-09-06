using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.Models;

namespace CustomerApp.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerEntity> GetAllCustomers();
        Task<CustomerEntity> AddCustomer(CustomerEntity customer);

        Task<CustomerEntity> UpdateCustomer(CustomerEntity customer);

        Task<bool> DeleteCustomer(Guid CustomerID);

        CustomerEntity GetCustomerByID(Guid CustomerID);

    }
}
