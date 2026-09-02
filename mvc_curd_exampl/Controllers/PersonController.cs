using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.SqlServer.Server;
using Rotativa.AspNetCore;
using ServiceContract;
using ServiceContract.DTO;
using ServiceContract.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace mvc_curd_exampl.Controllers
{
    
    
    public class PersonController : Controller
    {
        private IPerson iperson;
        private ICountry icountry;

        public PersonController(IPerson ipersonobj, ICountry icountryObj)
        {
            this.iperson = ipersonobj;
            this.icountry = icountryObj;

        }


        [HttpGet]
        public IActionResult Add()
        {
            List<CountryResponce> ALLcountriesObj =  icountry.Getallcountries();

            List<SelectListItem> selectListItems = new List<SelectListItem>();


            foreach (var SingleObj in ALLcountriesObj)
            {
                SelectListItem Obj1 = new SelectListItem();

                Obj1.Text= SingleObj.CountryName;
                Obj1.Value= Convert.ToString( SingleObj.Countyid);

                selectListItems.Add(Obj1);
            }

            //SelectListItem Obj1 = new SelectListItem();
            //Obj1.Text = "Turkey";
            //Obj1.Value = "E2D353CB-563C-4D3F-5776-08DEFD2EDDDE";


            //SelectListItem Obj2 = new SelectListItem();
            //Obj2.Text = "Turkmenistan";
            //Obj2.Value = "74A2077B-68CB-454D-5777-08DEFD2EDDDE";

            //selectListItems.Add(Obj1);
            //selectListItems.Add(Obj2);

            ViewBag.ALLCountryData_viewbag = selectListItems;
           // ViewData["ALLCountryData_Viewdata"]= selectListItems;
           // TempData["ALLCountryData_TempData"] = selectListItems;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(PersonAddRequest personAddRequest)
        {
            PersonResponce data = await iperson.Addperson(personAddRequest);


            PersonResponce personResponce = new PersonResponce();
            personResponce.Rajani(10);

            return View("display",data);

        }

        [HttpGet]
        public async Task<IActionResult> Getallperson()
        {

            List<PersonResponce> obj = await iperson.GetAllPerson();
            return View(obj);
        }

        [HttpGet]
        public IActionResult Getperson()
        {
            return View();
        }

        [HttpPost]
        public async Task<PersonResponce> Getperson(Guid PersonId)
        {
           PersonResponce obj = await iperson.GetPersonByPersonId(PersonId);
            return obj;

        }

        //public async Task<IActionResult> PersonPDF()
        //{
        //    List<PersonResponce> obj = await iperson.GetAllPerson();

        //    return new ViewAsPdf("displayPDF", obj)
        //    {
        //        FileName = "PersonDetails.pdf"
        //    };
        //}

        public async Task<IActionResult> personPDF()
        {
            List<PersonResponce> obj = await iperson.GetAllPerson();

            ViewAsPdf pdfobj = new ViewAsPdf("displayinPDF",obj);
            return pdfobj;



        }

        public  async Task<IActionResult> PersonCSV()
        {
            // MemoryStream value= await iperson.GetpersonCSV();

           MemoryStream data=  await iperson.GetCSV();

            return File(data, "application/octet-stream", "Person.CSV");

           // throw new NotImplementedException();

        }

        public async Task<IActionResult> PersonExcel()
        {
            // MemoryStream value= await iperson.GetpersonCSV();

            MemoryStream data = await iperson.GetExcel();

            return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Person.xlsx");

            // throw new NotImplementedException();

        }
    }
}
