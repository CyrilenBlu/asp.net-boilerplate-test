using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using AutoMapper;
using blu.MyProject.Domain;
using blu.MyProject.DTOModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blu.MyProject.Services
{
    public class PersonService : MyProjectAppServiceBase, IPersonService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public PersonListDto Add(PersonListDto person)
        {
            var eperson = Mapper.Map<PersonListDto, Person>(person);

            var created = _personRepository
                .Insert(eperson);

            Console.WriteLine(created.Name);

            var dtoPerson = Mapper.Map<Person, PersonListDto>(created);

            return dtoPerson;
        }

        public async Task<ListResultDto<PersonListDto>> GetAll(GetAllPeopleInput input)
        {
            var people = await _personRepository
                .GetAll()
                .WhereIf(input.State.HasValue, p => p.State == input.State.Value)
                .ToListAsync();

            return new ListResultDto<PersonListDto>(
                ObjectMapper.Map<List<PersonListDto>>(people)
                );
        }

        public async Task<ListResultDto<PersonListDto>> GetAll()
        {
            var people = await _personRepository
                .GetAll()
                .ToListAsync();

            return new ListResultDto<PersonListDto>(
                ObjectMapper.Map<List<PersonListDto>>(people)
                );
        }
    }
}
