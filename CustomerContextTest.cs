using System;
using Xunit;
using Moq;
using CustomerApp;
using Moq;
using CustomerApp.Models;
using CustomerApp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTestProject1
{
    public class CustomerRepositoryUnitTests
    {
        [Fact]
        public async Task InsertNewCustomer()
        {
            //arrange
            CustomerEntity cust = new CustomerEntity {
                CustomerAge = 10,
                CustomerId = Guid.NewGuid(),
                CustomerIncome = 10000,
                CustomerName = "Ritesh"
            };

            Mock<DbSet <CustomerEntity>> dbs = new Mock<DbSet<CustomerEntity>>();
            Mock<CustomerDbContext> context = new Mock<CustomerDbContext>();
            context.Setup(x => x.customers).Returns(dbs.Object);

            //Act
            ICustomerRepository _repo = new CustomerRepository(context.Object);
            CustomerEntity custResult =  await _repo.AddCustomer(cust);

            //Assert
            dbs.Verify(a => a.AddAsync(cust, CancellationToken.None), Times.Once);
            context.Verify(b => b.SaveChangesAsync(CancellationToken.None), Times.Once);
            Assert.Equal(10, custResult.CustomerAge);
            await Task.CompletedTask;
        }

        [Fact]
        public async Task GetAllCustomersTest()
        {
            //arrange
            var allcustomers = new List<CustomerEntity> {
                new CustomerEntity { CustomerAge= 10, CustomerId =Guid.NewGuid(), CustomerIncome = 10000, CustomerName= "ABC" },
                new CustomerEntity { CustomerAge= 20, CustomerId =Guid.NewGuid(), CustomerIncome = 20000, CustomerName= "ABCD" },
                new CustomerEntity { CustomerAge= 30, CustomerId =Guid.NewGuid(), CustomerIncome = 30000, CustomerName= "ABCDE" },
                new CustomerEntity { CustomerAge= 40, CustomerId =Guid.NewGuid(), CustomerIncome = 40000, CustomerName= "ABCDEF" }
            }.AsQueryable();

            Mock<DbSet<CustomerEntity>> dbs = new Mock<DbSet<CustomerEntity>>();
            //dbs.As<IQueryable<CustomerEntity>>().Setup(x => x.ElementType).Returns(allcustomers.ElementType);
            //dbs.As<IQueryable<CustomerEntity>>().Setup(x => x.Provider).Returns(allcustomers.Provider);
            //dbs.As<IQueryable<CustomerEntity>>().Setup(x => x.Expression).Returns(allcustomers.Expression);
            dbs.As<IQueryable<CustomerEntity>>().Setup(x => x.GetEnumerator()).Returns(allcustomers.GetEnumerator());

            Mock<CustomerDbContext> context = new Mock<CustomerDbContext>();
            context.Setup(x => x.customers).Returns(dbs.Object);

            //Act
            ICustomerRepository _repo = new CustomerRepository(context.Object);
            var custResult =  _repo.GetAllCustomers();

            Assert.Equal(4, custResult.Count());
            await Task.CompletedTask;
        }
    }
}
