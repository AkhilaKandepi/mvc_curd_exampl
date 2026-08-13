using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Entities;
using Entities.dbcontext;
using ServiceContract.DTO;
using ServiceContract.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class PersonServices :IPerson
    {
        public  readonly CHILD_OF_DBCONTEXT db_tbl;

       
        public PersonServices(CHILD_OF_DBCONTEXT db)
        {

            this.db_tbl = db;

        }


        public async Task<PersonResponce> Addperson(PersonAddRequest personAddRequest)

        {
            if (personAddRequest == null)
            {
                throw new ArgumentNullException(nameof(personAddRequest) + "Your passing Null object DATA");

            }
            if (personAddRequest.PersonName==null)
            {
                throw new ArgumentException();


            }

            Person obj = new Person();

            obj.PersonName = personAddRequest.PersonName;

            obj.PersonEmail = personAddRequest.PersonEmail;

            obj.DateOfBirth = personAddRequest.DateOfBirth;

            obj.Gender = personAddRequest.Gender;

            obj.Country = personAddRequest.Country;

            obj.Address = personAddRequest.Address;

            obj.ReceiveNewsLetters = personAddRequest.ReceiveNewsLetters;

            obj.PersonId = Guid.NewGuid();

            obj.CountryId = Guid.NewGuid();

           // db_tbl.Tbl_person.Add(obj);


           await db_tbl.SaveChangesAsync();

            PersonResponce personResponseObj = new PersonResponce();

            personResponseObj.PersonId = obj.PersonId;

            personResponseObj.PersonName = obj.PersonName;

            personResponseObj.PersonEmail = obj.PersonEmail;

            personResponseObj.DateOfBirth = obj.DateOfBirth;

            personResponseObj.Gender = obj.Gender;

            personResponseObj.CountryId = obj.CountryId;

            personResponseObj.Country = obj.Country;

            personResponseObj.Address = obj.Address;

            personResponseObj.ReceiveNewsLetters = obj.ReceiveNewsLetters;

            return personResponseObj;

        }
        
        
        public async Task<List<PersonResponce>> GetAllPerson()
        {
            List<Person> listobj = await db_tbl.Getallperson();
            List<PersonResponce> personResponcesobj= new List<PersonResponce>();
            foreach (Person data in listobj)
            {
                PersonResponce obj = new PersonResponce();
                obj.PersonId = data.PersonId;
                obj.PersonName = data.PersonName;
                obj.PersonEmail = data.PersonEmail;
                obj.DateOfBirth=data.DateOfBirth;
                obj.Gender = data.Gender;
                obj.CountryId = data.CountryId;
                obj.Country = data.Country;
                obj.Address = data.Address;
                obj.ReceiveNewsLetters=data.ReceiveNewsLetters;
                personResponcesobj.Add(obj);


            }

          
            return  personResponcesobj;


        }


      public async Task<PersonResponce> GetPersonByPersonId(Guid PersonId)
        {
            // Check whether PersonId is null
            if (PersonId == null)
            {
                return null;
            }
            // Find the person from database
            Person? person1 = await db_tbl.Tbl_person .Where(p => p.PersonId == PersonId).FirstOrDefaultAsync();

            // Check whether person exists
            if (person1 == null)
            {
                return null;
            }

           // Person obj =db_tbl.Tbl_person.Where(s=>s.PersonId==PersonId).SingleOrDefault();

            PersonResponce personobj= new PersonResponce {PersonName= person1.PersonName,PersonId= person1.PersonId};

            return personobj;



        }

        


    }
}

