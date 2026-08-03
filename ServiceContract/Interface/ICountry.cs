using ServiceContract.DTO;
using System;
using System.Collections.Generic;
using ServiceContract.DTO;  
using System.Linq;
using ServiceContract.DTO;      
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract
{
    public interface ICountry
    {
         CountryResponce AddCountry(CountryAddRequst countryAddRequst);

        List<CountryResponce> Getallcountries();
        CountryResponce GetcountryById(Guid Countyid);




    }
}
