using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Repository;
using NLayer.Service.Services;

namespace NLayer.API.Controllers
{
    [Authorize]
    public class PersonnelsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IPersonnelService _service;
        private readonly AppDbContext _context;


        public PersonnelsController (IService<Personnel> service, IMapper mapper, IPersonnelService personnelService)
        {
            _mapper = mapper;
            _service = personnelService;
        }

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetPersonnelsWithWatch()
        //{
        //    return CreateActionResult(await _service.GetPersonnelsWithWatch());
        //}


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var personnels = await _service.GetAllAsync();

            var personnelsDtos = _mapper.Map<List<PersonnelDto>>(personnels.ToList());

            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));

            return CreateActionResult(CustomResponseDto<List<PersonnelDto>>.Success(200, personnelsDtos));


        }


        [ServiceFilter(typeof(NotFoundFilter<Personnel>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var personnel = await _service.GetByIdAsync(id);

            var personnelsDto = _mapper.Map<PersonnelDto>(personnel);

            return CreateActionResult(CustomResponseDto<PersonnelDto>.Success(200, personnelsDto));


        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonnelDto personnelDto)
        {
            var personnel = await _service.AddAsync(_mapper.Map<Personnel>(personnelDto));

            var personnelsDto = _mapper.Map<PersonnelDto>(personnel);

            return CreateActionResult(CustomResponseDto<PersonnelDto>.Success(201, personnelsDto));


        }

        [HttpPut]
        public async Task<IActionResult> Update(PersonnelUpdateDto personnelDto)
        {
            await _service.UpdateAsync(_mapper.Map<Personnel>(personnelDto));

            return StatusCode(204);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var personnel = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(personnel);

            return StatusCode(204);


        }





    }
}
