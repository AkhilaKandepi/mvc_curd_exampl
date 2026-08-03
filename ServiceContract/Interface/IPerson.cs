using ServiceContract.Enum;
using ServiceContract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract.Interface
{
    public interface IPerson
    {
        //insert into person_tbl values();
        PersonResponce Addperson(PersonAddRequest personAddRequest);

      //Selector*from person
        List<PersonResponce> GetAllPerson();

        //update person set person_name="ram" where person_id=1;
        PersonResponce UpdatePerson(PersonUpdateRequest personUpdateRequest);

        //delete person_tbl person_id=4;
        bool DeletePerson(Guid PersonId);

        //select*from person_tbl where person_id=1
         PersonResponce GetPersonByPersonId(Guid GetPersonid);
        

        //select*from person_tbl where person_name=%s%;
        
        List<PersonResponce> GetFilterPersons(string SearchBy,string Searchstring);

        //select*from person_tbl where person_gender asc;
        List<PersonResponce> GetSortedPerson(List<PersonResponce> PersonResponce,string sortBy,SortOrderOptions sortOrderOptions);



    }
}
