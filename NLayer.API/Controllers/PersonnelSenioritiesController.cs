using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Service.Services;

namespace NLayer.API.Controllers
{
    public class PersonnelSenioritiesController : CustomBaseController
    {
        private readonly IPersonnelSeniorityService _personnelSeniorityService;

        public PersonnelSenioritiesController(IPersonnelSeniorityService personnelSeniorityService)
        {
            _personnelSeniorityService = personnelSeniorityService;
        }

        [HttpGet("[action]/{seniorityId}")]
        public async Task<IActionResult> GetSinglePersonnelByIdWithProductSeniorityAsync(int seniorityId)
        {
            return CreateActionResult(await _personnelSeniorityService.GetSinglePersonnelByIdWithProductSeniorityAsync(seniorityId));
        }

    }
}
