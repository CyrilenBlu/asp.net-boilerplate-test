using blu.MyProject.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blu.MyProject.Web.Model
{
    public class IndexViewModel
    {
        public IReadOnlyList<PersonListDto> People { get; }

        public IndexViewModel(IReadOnlyList<PersonListDto> people)
        {
            People = people;
        }

        public string GetPersonLabel(PersonListDto person)
        {
            switch (person.State)
            {
                case Domain.Person.PersonState.Open:
                    return "label-success";
                default:
                    return "label-default";
            }
        }
    }
}
