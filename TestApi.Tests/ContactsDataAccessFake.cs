
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestApi.Models;
using TestApi.DataAccess;




namespace TestApi.Tests
{
    public class ContactsDataAccessFake : IContactsDataAccess
    {
        //TODO: Place data access code here

        public List<Contact> _contacts;
        private int _nextId = 5;
        public ContactsDataAccessFake()
        {
            _contacts = new List <Contact> {
                new Contact(){
                    Id = 1,
                    FirstName = "FakeName1",
                    LastName = "FakeLastName1",
                    Email = "fakename1@example.com"
                },
                new Contact(){
                    Id = 2,
                    FirstName = "FakeName2",
                    LastName = "FakeLastName2",
                    Email = "fakename2@example.com"
                },
                new Contact(){
                    Id = 3,
                    FirstName = "FakeName3",
                    LastName = "FakeLastName3",
                    Email = "fakename3@example.com"
                },
                new Contact(){
                    Id = 4,
                    FirstName = "FakeName4",
                    LastName = "FakeLastName4",
                    Email = "fakename4@example.com"
                },
                new Contact(){
                    Id = 5,
                    FirstName = "FakeName5",
                    LastName = "FakeLastName5",
                    Email = "fakename5@example.com"
                }

        };
        
              
        }
         public Contact Get(int id)
        {
            return _contacts.Find(c => c.Id == id);
        }
        public List <Contact> Add(Contact contact){
            if(contact == null)
            {
                throw new ArgumentNullException("contact");
            }
                contact.Id = ++_nextId;
                 _contacts.Add(contact);

                  return _contacts;
        }

        public IEnumerable <Contact> GetAllContacts(){
            return _contacts;
        }

         
    }
}
