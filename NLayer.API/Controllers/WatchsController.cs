using Autofac.Core;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Service.Services;

namespace NLayer.API.Controllers
{

    [Authorize]
    public class WatchsController : CustomBaseController
    {
        private readonly IWatchService _watchService;
        private readonly IMapper _mapper;

        public WatchsController(IService<Watch> service, IMapper mapper, IWatchService watchService)
        {
            _watchService = watchService;
            _mapper = mapper;
        }

        [HttpGet("[action]/{watchId}")]
        public async Task<IActionResult> GetSingleWatchByIdWithPersonnelAsync(int watchId)
        {
            return CreateActionResult(await _watchService.GetSingleWatchByIdWithPersonnelAsync(watchId));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var wathches = await _watchService.GetAllAsync();

            var wathchesDtos = _mapper.Map<List<WatchDto>>(wathches.ToList());

            //return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));

            return CreateActionResult(CustomResponseDto<List<WatchDto>>.Success(200, wathchesDtos));


        }
    }
}
