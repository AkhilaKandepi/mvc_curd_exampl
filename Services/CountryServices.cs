using Entities;
using Entities.dbcontext;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ServiceContract;
using ServiceContract.DTO;
using ServiceContract.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CountryServices : ICountry
    {
        private List<Country> _countries;
        private readonly CHILD_OF_DBCONTEXT db_obj;

        public CountryServices(CHILD_OF_DBCONTEXT db)
        {
            db_obj = db;


        }

        public CountryResponce AddCountry(CountryAddRequst countryAddRequst)
        {

            Country countryobj = new Country();
            countryobj.CountryName = countryAddRequst.CountryName;
            /* countryobj.Countyid = Guid.Parse("DE597AC1-EB7B-4642-A706-CA9E75D351FF");*//*Guid.NewGuid()*/
            countryobj.Countyid = Guid.NewGuid();
            //_countries = new List<Country>();
            //_countries.Add(countryobj);


            try
            {
                db_obj.Tbl_country.Add(countryobj);
                int rows = db_obj.SaveChanges();
                Console.WriteLine(rows);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }

            CountryResponce countryResponceobj = new CountryResponce();

            countryResponceobj.Countyid = countryobj.Countyid;
            countryResponceobj.CountryName = countryobj.CountryName;


            return countryResponceobj;


        }
       


        public  List<CountryResponce> Getallcountries()
        {

            //List<CountryResponce> countryResponces=new List<CountryResponce>();


            //CountryResponce countryResponceobj1 = new CountryResponce();

            //countryResponceobj1.Countyid = Guid.Parse("BBE604D6-235D-43DC-B05B-24C8F2889824");

            //countryResponceobj1.CountryName = "jarmany";

            //CountryResponce countryResponceobj2 = new CountryResponce();

            //countryResponceobj2.Countyid = Guid.Parse("11BB840C-44A0-4D78-859F-FE197433EE31");

            //countryResponceobj2.CountryName = "chaina";

            //CountryResponce countryResponceobj3= new CountryResponce();

            //countryResponceobj3.Countyid = Guid.Parse("F35245F2-CBCF-4F3C-9C6F-76745FF27350");

            //countryResponceobj3.CountryName = "Nepal";





            //countryResponces.Add(countryResponceobj1);
            //countryResponces.Add(countryResponceobj2 );
            //countryResponces.Add(countryResponceobj3 );





            //return countryResponces;

            List<Country> countries = db_obj.Tbl_country.ToList();

            List<CountryResponce> countryresponceobj = new List<CountryResponce>();
            foreach (Country data in countries)
            {
                CountryResponce countryResponceobj = new CountryResponce();

                countryResponceobj.Countyid = data.Countyid;
                countryResponceobj.CountryName=data.CountryName;

                countryresponceobj.Add(countryResponceobj); 
            }
        



            return countryresponceobj;
                  


            //List<CountryResponce> countryResponcesobj = new List<CountryResponce>();
            //foreach (Country country in countries)
            //{

            //    CountryResponce countryResponce = new CountryResponce();
            //    countryResponce.Countyid = country.Countyid;
            //    countryResponce.CountryName = country.CountryName;

            //}

            //return countryResponcesobj;






        }

        public CountryResponce GetcountryById(Guid Countyid)
        {
            Country countries = db_obj.Tbl_country.Where(temp => temp.Countyid == Countyid).SingleOrDefault() ;


            CountryResponce obj = new CountryResponce { CountryName = countries.CountryName, Countyid = countries.Countyid };
            return obj;

        }
    }
}