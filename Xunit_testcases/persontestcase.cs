using Entities;
using Entities.dbcontext;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using ServiceContract;
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
namespace Xunit_testcases
{
    public class persontestcase
    {
        private readonly IPerson _personservice;
        private readonly ICountry _countryservice;

        private readonly ITestOutputHelper _testOutputHelper;
      
        public persontestcase(ITestOutputHelper testOutputHelper)
        {
            List<Person> personsInitialData = new List<Person>() { };
            List<Country> countriesInitialData = new List<Country>() { };


            DbContextMock<CHILD_OF_DBCONTEXT> dbContextMock = new DbContextMock<CHILD_OF_DBCONTEXT>(
          new DbContextOptionsBuilder<CHILD_OF_DBCONTEXT>().Options
         );

            CHILD_OF_DBCONTEXT dbContext = dbContextMock.Object;

            dbContextMock.CreateDbSetMock(temp => temp.Tbl_person, personsInitialData);
            dbContextMock.CreateDbSetMock(temp => temp.Tbl_country, countriesInitialData);


           _personservice = new PersonServices(dbContext);
            _countryservice = new CountryServices(dbContext);



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
                //Country = "us",
                Gender = "Male", 
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

                //Country = "USA",

                DateOfBirth = DateTime.Parse("2002-05-06"),

                ReceiveNewsLetters = true

            };

            PersonAddRequest person_request_2 = new PersonAddRequest()

            {

                PersonName = "Mary",

                PersonEmail = "mary@example.com",

                Gender = "Female",

                Address = "Address of Mary",

                //Country = "USA",

                DateOfBirth = DateTime.Parse("2000-02-02"),

                ReceiveNewsLetters = false

            };

            PersonAddRequest person_request_3 = new PersonAddRequest()

            {

                PersonName = "Rahman",

                PersonEmail = "rahman@example.com",

                Gender = "Male",

                Address = "Address of Rahman",

                //Country = "India",

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



        //If you supply an invalid PersonID, it should return false
        [Fact]
        public async Task DeletePerson_InvalidPersonID()
        {
            //Act
            bool isDeleted = await _personservice.DeletePerson(Guid.NewGuid());

            //Assert
            Assert.False(isDeleted);
        }

        [Fact]
        public async Task DeletePerson_NullDATA()
        {
            
           Guid? personID  = null;

            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _personservice.DeletePerson(personID);

            });

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

        [Fact]
       public async Task DeletePerson_ValidPersonID()
       {
            CountryAddRequst country_add_request = new CountryAddRequst() 
            { 
                CountryName = "USA"
            };
            CountryResponce country_response_from_add = _countryservice.AddCountry(country_add_request);

            PersonAddRequest person_add_request = new PersonAddRequest()
            {
                PersonName = "Jones",
                Address = "address",
                CountryId = country_response_from_add.Countyid,
                DateOfBirth = Convert.ToDateTime("2010-01-01"),
                PersonEmail = "jones@example.com",
                Gender = "Male",
                ReceiveNewsLetters = true,
                BloodGroup = "B+"

            };
            PersonResponce person_response_from_add = await _personservice.Addperson(person_add_request);

            //Act
            bool isDeleted = await _personservice.DeletePerson(person_response_from_add.PersonId);
            Assert.True(isDeleted);

        }


        [Fact]
        public async Task GetFilteredPersons_EmptySearchText()
        {

            CountryAddRequst country_request_1 = new CountryAddRequst() { CountryName = "USA" };
            CountryAddRequst country_request_2 = new CountryAddRequst() { CountryName = "India" };



            CountryResponce country_response_1 =   _countryservice.AddCountry(country_request_1);
            CountryResponce country_response_2 =  _countryservice.AddCountry(country_request_2);

            PersonAddRequest person_request_1 = new PersonAddRequest() { PersonName = "Smith", PersonEmail= "smith@example.com", Gender ="Male", Address = "address of smith", CountryId= country_response_1.Countyid, DateOfBirth = DateTime.Parse("2002-05-06"), ReceiveNewsLetters = true };


            PersonAddRequest person_request_2 = new PersonAddRequest() { PersonName = "Rani", PersonEmail = "Rani@example.com", Gender = "Female", Address = "address ofRani", CountryId = country_response_2.Countyid, DateOfBirth = DateTime.Parse("2004-06-07"), ReceiveNewsLetters = true };



             PersonResponce Record1  = await  _personservice.Addperson(person_request_1);
             PersonResponce Record2 = await _personservice.Addperson(person_request_2);

            List<PersonResponce> TotalActualData= new List<PersonResponce> { Record1, Record2 };



            List<PersonResponce>   Filterdata  = await _personservice.GetFilteredPersons("PersonName", "");


            foreach (PersonResponce RecordswiseData in TotalActualData)
            {
                Assert.Contains(RecordswiseData, Filterdata);
            }


        }



    }

}




