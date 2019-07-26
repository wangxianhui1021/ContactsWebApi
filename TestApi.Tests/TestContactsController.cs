using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Controllers;
using TestApi.Models;
using System.Linq;
using Xunit;
using TestApi.DataAccess;
using TestApi.Tests;




namespace TestApi.Tests
{
    
    public class TestContactsController
    {
        ContactsController _controller;
        IContactsDataAccess _dataAccess;
        public TestContactsController()
        {
            _dataAccess = new ContactsDataAccessFake();
            _controller = new ContactsController(_dataAccess);
            
        }
        [Fact]
        public void GetAllContacts_ShouldReturnAllContacts()
        {
            var items= _dataAccess.GetAllContacts();
            var results = _controller.GetContacts();
            Assert.Equal(items, results);
        }


        
    }
}