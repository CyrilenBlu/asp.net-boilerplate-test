using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using AutoMapper;
using blu.MyProject.Domain;
using blu.MyProject.DTOModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
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

            var createdId = _personRepository
                .InsertAndGetId(eperson);

            var createdPerson = new Person()
            {
                Id = createdId,
                Name = eperson.Name,
                Age = eperson.Age
            };

            var dtoPerson = Mapper.Map<Person, PersonListDto>(createdPerson);

            return dtoPerson;
        }

        public string Delete(int id)
        {
            
            try {
                var person = _personRepository.Get(id);
                _personRepository.Delete(person);
            } catch (EntityNotFoundException e)
            {
                return e.Message;
            }
            return "Successfully Deleted id: " + id;
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
