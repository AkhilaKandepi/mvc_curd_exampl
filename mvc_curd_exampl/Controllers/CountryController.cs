using Microsoft.AspNetCore.Mvc;
using ServiceContract;
using ServiceContract.DTO;

namespace mvc_curd_exampl.Controllers
{
    public class CountryController : Controller
    {

       private  ICountry Country;

        public CountryController(ICountry country)
        {
            this.Country = country;
        }






        
        [HttpGet]

        [Route("/")]
        public ViewResult ADD()
        {
            return View();
        }



        [HttpPost]

        public IActionResult ADD(CountryAddRequst DataOfCountry)
        {

          CountryResponce DataOutput  =Country.AddCountry(DataOfCountry);


            return View("display",DataOutput);
        }

        public IActionResult GetAllcountrydata()
        {
           List<CountryResponce> countrydata =Country.Getallcountries();

            return View(countrydata);
        }

        [HttpGet]
        public IActionResult Getcountry()
        {

            return View();
        }


        [HttpPost]
        public object Getcountry(Guid Countyid)
        {

          CountryResponce obj   =Country.GetcountryById(Countyid);

            return obj;




        }



    }
}
