using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi.Controllers;
using TestApi.Models;
using Xunit;
using TestApi.DataAccess;




namespace TestApi.Tests
{
    
    public class TestContactsController
    {
        [Fact]
        public void GetAllContacts_ShouldReturnAllContacts()
        {
            var testContacts = GetTestContacts();
            var controller = new ContactsController();

            var result = controller.GetContacts() as List<Contact>;
            Assert.Equal(testContacts, result);
        }


        private List<Contact> GetTestContacts()
        {
            var testContacts = new List<Contact>();
            testContacts.Add(new Contact { Id = 1, FirstName = "Joe", LastName="Smith" , Email = "joesmith@gmail.com" });
            testContacts.Add(new Contact { Id = 2, FirstName = "Mary", LastName="Strong" , Email = "joesmith@gmail.com" });
            testContacts.Add(new Contact { Id = 3, FirstName = "Bob", LastName="Williams" , Email = "joesmith@gmail.com" });
            testContacts.Add(new Contact { Id = 4, FirstName = "Harry", LastName="Porter" , Email = "joesmith@gmail.com" });

            return testContacts;
        }
    }
}