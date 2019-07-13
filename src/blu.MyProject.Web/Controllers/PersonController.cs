using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using blu.MyProject.DTOModels;
using blu.MyProject.Web.Model;
using Microsoft.AspNetCore.Mvc;

namespace blu.MyProject.Web.Controllers
{
    public class PersonController : MyProjectControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [Route("People")]
        public async Task<ActionResult> Index(GetAllPeopleInput input)
        {
            var output = await _personService.GetAll(input);
            var model = new IndexViewModel(output.Items);
            return View(model);
        }

        [Route("api/people")]
        public async Task<ActionResult<IEnumerable<string>>> GetAll()
        {
            var result = await _personService.GetAll();
            return Ok(result);
        }

        [Route("api/people")]
        [HttpPost]
        public ActionResult<PersonListDto> Add([FromBody] PersonListDto person)
        {
            return _personService.Add(person);
        }
    }
}