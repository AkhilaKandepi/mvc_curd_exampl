using Entities.dbcontext;
using Microsoft.EntityFrameworkCore;
using ServiceContract.DTO;
using ServiceContract.Interface;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Xunit_testcases
{
    public class persontestcase
    {
        private  IPerson _personservice;

        public persontestcase()
        {
            _personservice = new PersonServices(new CHILD_OF_DBCONTEXT(new DbContextOptionsBuilder<CHILD_OF_DBCONTEXT>().Options));

            // Create obj for dbcontext 
            // akhilav write
            //DbContextOptionsBuilder<CHILD_OF_DBCONTEXT> obj = new DbContextOptionsBuilder<CHILD_OF_DBCONTEXT>().op;
            //CHILD_OF_DBCONTEXT onj = new CHILD_OF_DBCONTEXT(new DbContextOptionsBuilder<CHILD_OF_DBCONTEXT>().Options);
            //PersonServices personServices = new PersonServices(onj);
            //_personservice = personServices;
        }

       
        public void Addperson_null()
        {
            PersonAddRequest? personAddRequest = null;
            Assert.Throws<ArgumentNullException>(() =>
               {
                   _personservice.Addperson(personAddRequest);

               });

        }
       
        public  void AddPerson_PersonNameIsNull()
        {
            //Arrange
            PersonAddRequest? personAddRequest = new PersonAddRequest() { PersonName = null };

            //Act
            Assert.Throws<ArgumentException>( () => 
            {
                 _personservice.Addperson(personAddRequest);
            });
        }

        [Fact]
        public void AddPerson_ProperPersonDetails()
        {
            //Arrange
            PersonAddRequest personAddRequest = new PersonAddRequest() { PersonName = "Person name...",
                PersonEmail = "person@example.com", Address = "sample address",
                Country = "us", Gender = "Male", 
                DateOfBirth = DateTime.Parse("2000-01-01"), ReceiveNewsLetters = true };

            //Act
            PersonResponce person_response_from_add = _personservice.Addperson(personAddRequest);

            List<PersonResponce> persons_list = _personservice.GetAllPerson();

            //Assert
            Assert.True(person_response_from_add.PersonId != Guid.Empty);

            Assert.Contains(person_response_from_add, persons_list);
        }



      
        public void GetAllPersons_AddFewPersons()

        {

            // Arrange

            PersonAddRequest person_request_1 = new PersonAddRequest()

            {

                PersonName = "Smith",

                PersonEmail = "smith@example.com",

                Gender = "Male",

                Address = "Address of Smith",

                Country = "USA",

                DateOfBirth = DateTime.Parse("2002-05-06"),

                ReceiveNewsLetters = true

            };

            PersonAddRequest person_request_2 = new PersonAddRequest()

            {

                PersonName = "Mary",

                PersonEmail = "mary@example.com",

                Gender = "Female",

                Address = "Address of Mary",

                Country = "USA",

                DateOfBirth = DateTime.Parse("2000-02-02"),

                ReceiveNewsLetters = false

            };

            PersonAddRequest person_request_3 = new PersonAddRequest()

            {

                PersonName = "Rahman",

                PersonEmail = "rahman@example.com",

                Gender = "Male",

                Address = "Address of Rahman",

                Country = "India",

                DateOfBirth = DateTime.Parse("1999-03-03"),

                ReceiveNewsLetters = true

            };

            // Store all person requests in a list

            List<PersonAddRequest> person_requests = new List<PersonAddRequest>()

    {

        person_request_1,

        person_request_2,

        person_request_3

    };

            // Store the responses returned by AddPerson()

            List<PersonResponce> person_response_list_from_add =

                new List<PersonResponce>();

            // Add each person

            foreach (PersonAddRequest person_request in person_requests)

            {

                PersonResponce person_response =

                    _personservice.Addperson(person_request);

                person_response_list_from_add.Add(person_response);

            }

            // Act

            // Get all persons from the database

            List<PersonResponce> persons_list_from_get =

                _personservice.GetAllPerson();

            // Assert

            // Check whether every added person exists in the returned list

            foreach (PersonResponce person_response_from_add

                     in person_response_list_from_add)

            {

                Assert.Contains(person_response_from_add, persons_list_from_get);

            }

        }

        

        public void GetPersonById_NullPersonId()

        {

            // Arrange

            Guid? personId = null;

            // Act & Assert

            Assert.Throws<ArgumentNullException>(() =>

            {

                _personservice.GetPersonByPersonId(personId.Value);

            });

        }



    }

}




