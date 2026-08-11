using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract.DTO
{
   public partial class PersonResponce 
    {
        public Guid PersonId { get; set; }
        public string? PersonName { get; set; }
        public string? PersonEmail { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public Guid? CountryId { get; set; }

        public string? Country { get; set; }
        public string? Address { get; set; }
        public bool ReceiveNewsLetters { get; set; }


        public override bool Equals(object? obj)
        {

            if (obj == null) return false;

            if (obj.GetType() != typeof(PersonResponce)) return false;

            PersonResponce person = (PersonResponce)obj;
            return PersonId == person.PersonId && PersonName == person.PersonName && PersonEmail == person.PersonEmail && DateOfBirth == person.DateOfBirth && Gender == person.Gender && Country== person.Country && Address == person.Address && ReceiveNewsLetters == person.ReceiveNewsLetters;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public void Raju()
        { 
        
        }




        //public override string ToString()
        //{
        //    return $"Person ID: {PersonId}, Person Name: {PersonName}, Email: {PersonEmail}, Date of Birth: {DateOfBirth?.ToString("dd MMM yyyy")}, Gender: {Gender}, Country: {Country}, Country: {Country}, Address: {Address}, Receive News Letters: {ReceiveNewsLetters}";
        //}


      


    }


  public  partial class PersonResponce
    {

        public void Ramu()
        { 
        
        
        }

    }








}
