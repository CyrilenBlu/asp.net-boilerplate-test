using blu.MyProject.DTOModels;
using blu.MyProject.Services;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace blu.MyProject.Tests.Services
{
    public class PersonServiceTests : MyProjectTestBase
    {
        private readonly IPersonService _personService;

        public PersonServiceTests()
        {
            _personService = Resolve<IPersonService>();
        }

        [Fact]
        public async Task Should_Get_All_Tasks()
        {
            //Act
            var output = await _personService.GetAll(new GetAllPeopleInput());

            //Assert
            output.Items.Count.ShouldBe(2);
        }

        [Fact]
        public async Task Should_Get_Filtered_Tasks()
        {
            //Act
            var output = await _personService.GetAll(new GetAllPeopleInput { State = Domain.Person.PersonState.Open });

            //Assert
            output.Items.ShouldAllBe(p => p.State == Domain.Person.PersonState.Open);
        }
    }
}
