using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using blu.MyProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using static blu.MyProject.Domain.Person;

namespace blu.MyProject.DTOModels
{
    [AutoMapFrom(typeof(Person))]
    public class PersonListDto : EntityDto
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public PersonState State { get; set; }

    }

    public class GetAllPeopleInput
    {
        public PersonState? State { get; set; }
    }
}
