using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApi.Models;
using TestApi.DataAccess;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
     //    static readonly IContactsDataAccess dataAccess = new ContactsDataAccess();
        private readonly IContactsDataAccess _dataAccess = new ContactsDataAccess();
        public ContactsController(IContactsDataAccess dataAccess)

        {
                _dataAccess = dataAccess;
        }
        [HttpGet]
        //GET api/contacts
        public IEnumerable<Contact> GetContacts(){
            
            return _dataAccess.GetAllContacts().OrderBy(c => c.LastName).ThenBy(c => c.FirstName);
        
        }
        [HttpGet("DESC")]
        //GET api/contacts/desc
        public IEnumerable<Contact>GetContactsDesc(){
            return _dataAccess.GetAllContacts().OrderByDescending(c => c.LastName).ThenByDescending(c => c.FirstName);

        }
                
         
         [HttpGet("ID/{id}", Name = "GetContact")]
         //GET api/contacts/id/1
        public IActionResult GetContact(int id){
            var contact = _dataAccess.Get(id);
            if (contact == null){
               return NotFound(); 
            }
            return Ok(contact);


        }
         [HttpGet("LASTNAME/{lastname}")]
         //GET api/contacts/lastname/person's_lastname
         public IEnumerable <Contact> GetContactByLastName( string lastname){
            return _dataAccess.GetAllContacts().Where(
                 c => string.Equals(c.LastName, lastname, StringComparison.OrdinalIgnoreCase)).OrderBy(c => c.LastName);
             

         }

        [HttpPost]

        public Contact CreateContact([FromBody] Contact contact){
            
             _dataAccess.Add(contact);

            return contact;

        }


    }
}