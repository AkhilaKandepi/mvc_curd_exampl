using ServiceContract.DTO;
using System;
using System.Collections.Generic;
using ServiceContract.DTO;  
using System.Linq;
using ServiceContract.DTO;      
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ServiceContract
{
    public interface ICountry
    {
         CountryResponce AddCountry(CountryAddRequst countryAddRequst);

        List<CountryResponce> Getallcountries();
        CountryResponce GetcountryById(Guid Countyid);


        Task<int> ExcelToDtabase(IFormFile Excelfile);


    }
}
