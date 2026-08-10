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
using Xunit.Abstractions;
using Moq;
using EntityFrameworkCoreMock;
using Entities;
namespace Xunit_testcases
{
    public class persontestcase
    {
        private readonly IPerson _personservice;
        private readonly ITestOutputHelper _testOutputHelper;
      
        public persontestcase(ITestOutputHelper testOutputHelper)
        {
            List<Person> personsInitialData = new List<Person>() { };
            DbContextMock<CHILD_OF_DBCONTEXT> dbContextMock = new DbContextMock<CHILD_OF_DBCONTEXT>(
    new DbContextOptionsBuilder<CHILD_OF_DBCONTEXT>().Options
   );

            CHILD_OF_DBCONTEXT dbContext = dbContextMock.Object;

            dbContextMock.CreateDbSetMock(temp => temp.Tbl_person, personsInitialData);

            _personservice = new PersonServices(dbContext);


            //this._personservice = new PersonServices(new CHILD_OF_DBCONTEXT(new DbContextOptionsBuilder<CHILD_OF_DBCONTEXT>().Options));
           this._testOutputHelper=testOutputHelper;
            // Create obj for dbcontext 
            // akhilav write
            //DbContextOptionsBuilder<CHILD_OF_DBCONTEXT> obj = new DbContextOptionsBuilder<CHILD_OF_DBCONTEXT>().op;
            //CHILD_OF_DBCONTEXT onj = new CHILD_OF_DBCONTEXT(new DbContextOptionsBuilder<CHILD_OF_DBCONTEXT>().Options);
            //PersonServices personServices = new PersonServices(onj);
            //_personservice = personServices;
        }


        [Fact]
        public async Task Addperson_null()
        {
            PersonAddRequest? personAddRequest = null;
            await Assert.ThrowsAsync<ArgumentNullException>(async() =>
               {
                   await _personservice.Addperson(personAddRequest);

               });

        }

        [Fact]
        public async Task AddPerson_PersonNameIsNull()
        {
            //Arrange
            PersonAddRequest? personAddRequest = new PersonAddRequest() { PersonName = null };

            //Act
           await Assert.ThrowsAsync<ArgumentException>( async() =>
            {
               await _personservice.Addperson(personAddRequest);
            });
        }

        [Fact]
        public async Task AddPerson_ProperPersonDetails()
        {
            //Arrange
            PersonAddRequest? personAddRequest = new PersonAddRequest() { PersonName = "SRINU",
                PersonEmail = "person@example.com", Address = "sample address",
                Country = "us", Gender = "Male", 
                DateOfBirth = DateTime.Parse("2002-01-01"), ReceiveNewsLetters = true };

            //Act
            PersonResponce? person_response_from_add =  await _personservice.Addperson(personAddRequest);

            List<PersonResponce> persons_list = await _personservice.GetAllPerson();

            //Assert
            Assert.True(person_response_from_add.PersonId != Guid.Empty);

            Assert.Contains(person_response_from_add, persons_list);
        }



        [Fact]
        public async Task GetAllPersons_AddFewPersons()

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

            List<PersonAddRequest> person_requests = new List<PersonAddRequest>(){  person_request_1, person_request_2,  person_request_3 };

            // Store the responses returned by AddPerson()

            List<PersonResponce> person_response_list_from_add =new List<PersonResponce>();

            // Add each person

            foreach (PersonAddRequest person_request in person_requests)

            {

                PersonResponce person_response = await _personservice.Addperson(person_request);

                person_response_list_from_add.Add(person_response);

            }

            // Act

            // Get all persons from the database

            List<PersonResponce> persons_list_from_get = await _personservice.GetAllPerson();

            // Assert

            // Check whether every added person exists in the returned list

            foreach (PersonResponce person_response_from_add

                     in person_response_list_from_add)

            {

                Assert.Contains(person_response_from_add, persons_list_from_get);

            }

        }



        //public void GetPersonById_NullPersonId()

        //{

        //    // Arrange

        //    Guid? personId = null;

        //    // Act & Assert

        //    Assert.Throws<ArgumentNullException>(() =>

        //    {

        //        _personservice.GetPersonByPersonId(personId.Value);

        //    });

        //}



    }

}




