using ServiceContract.Interface;
using ServiceContract.DTO;
using Microsoft.AspNetCore.Mvc;

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
        public Object Getperson(Guid PersonId)
        {
           PersonResponce obj = iperson.GetPersonByPersonId(PersonId);
            return obj;

        }
    }
}
