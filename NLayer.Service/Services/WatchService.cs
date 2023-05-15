using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class WatchService : Service<Watch>, IWatchService
    {
        private readonly IMapper _mapper;
        private readonly IWatchRepository _watchRepository;

        public WatchService(IGenericRepository<Watch> repository, IUnitOfWork unitOfWork, IWatchRepository watchRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _watchRepository = watchRepository;
        }

        public async Task<CustomResponseDto<WatchWithPersonnelsDto>> GetSingleWatchByIdWithPersonnelAsync(int watchId)
        {
            var watchs = await _watchRepository.GetSingleWatchByIdWithPersonnelAsync(watchId);

            var watchsDto = _mapper.Map<WatchWithPersonnelsDto>(watchs);

            return CustomResponseDto<WatchWithPersonnelsDto>.Success(200, watchsDto);
        }

    }
    
}
