using Abp.Application.Services;
using Abp.Application.Services.Dto;
using blu.MyProject.DTOModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace blu.MyProject
{
    public interface IPersonService : IApplicationService
    {
        Task<ListResultDto<PersonListDto>> GetAll(GetAllPeopleInput input);

        Task<ListResultDto<PersonListDto>> GetAll();
    }
}
