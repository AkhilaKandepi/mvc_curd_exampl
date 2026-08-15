using Entities;
using Microsoft.AspNetCore.Mvc;
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

        public PersonController(IPerson ipersonobj)
        {
        this.iperson = ipersonobj;

        }


        [HttpGet]
        public IActionResult Add()
        {
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

            return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Person.Excel");

            // throw new NotImplementedException();

        }
    }
}
