using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using CustomerApp.Controllers;
using CustomerApp.Models;
using CustomerApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;


namespace XUnitTestProject1
{
    public class CustomerControllerTests
    {
        private CustomerEntity GetSingleCustomer() {
            return new CustomerEntity {
                CustomerAge = 10,
                CustomerId = Guid.NewGuid(),
                CustomerIncome = 10000,
                CustomerName = "Ritesh"
            };
        }

        [Fact]
        public void InsertCustomerTestPost_Success() {

            CustomerEntity entity = GetSingleCustomer();

            Mock<ICustomerRepository> custRepoMock = new Mock<ICustomerRepository>();
            custRepoMock.Setup(x => x.AddCustomer(entity)).ReturnsAsync(entity);
            CustomerController controller = new CustomerController(custRepoMock.Object);
            controller.Post(entity);

            custRepoMock.Verify(a => a.AddCustomer(entity), Times.Once);

        }

        [Fact]
        public void InsertCustomerTestPost_CustomerAgelessthan10_exception()
        {

            CustomerEntity entity = GetSingleCustomer();
            entity.CustomerAge = 9;
            Mock<ICustomerRepository> custRepoMock = new Mock<ICustomerRepository>();
            custRepoMock.Setup(x => x.AddCustomer(entity)).ReturnsAsync(entity);
            CustomerController controller = new CustomerController(custRepoMock.Object);
           // controller.Post(entity);

            //custRepoMock.Verify(a => a.AddCustomer(entity), Times.Once);
            Assert.Throws<InvalidAgeException>(() => controller.Post(entity));
            
        }

        [Fact]
        public void InsertCustomerTestPost_CustomerAgeMorethan10_exception()
        {

            CustomerEntity entity = GetSingleCustomer();

            Mock<ICustomerRepository> custRepoMock = new Mock<ICustomerRepository>();
            custRepoMock.Setup(x => x.AddCustomer(entity)).ReturnsAsync(entity);
            CustomerController controller = new CustomerController(custRepoMock.Object);
            // controller.Post(entity);

            //custRepoMock.Verify(a => a.AddCustomer(entity), Times.Once);
        }
            [Fact]
        public void InsertCustomerTestPost_CustomerAgelessthan10_success()
        {

            CustomerEntity entity = GetSingleCustomer();
            Mock<ICustomerRepository> custRepoMock = new Mock<ICustomerRepository>();
            custRepoMock.Setup(x => x.AddCustomer(entity)).ReturnsAsync(entity);
            CustomerController controller = new CustomerController(custRepoMock.Object);
            var result = controller.Post(entity);

            Assert.IsType<OkResult>(result);
            Assert.IsAssignableFrom<IActionResult>(result);
            
        }

    }


    }

