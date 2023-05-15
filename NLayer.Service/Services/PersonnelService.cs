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
    public class PersonnelService : Service<Personnel>, IPersonnelService
    {
        private readonly IPersonnelRepository _personnelRepository;
        private readonly IMapper _mapper;

        public PersonnelService(IGenericRepository<Personnel> repository, IUnitOfWork unitOfWork, IMapper mapper, IPersonnelRepository personnelRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _personnelRepository = personnelRepository;
        }

        //public async Task<CustomResponseDto<PersonnelWithPersonnelSeniorityDto>> GetPersonnelsWithPersonnelSeniority(int personnelSeniorityId)
        //{
        //    var personnels = await _personnelRepository.GetPersonnelsWithPersonnelSeniority(personnelSeniorityId);

        //    var personnelsDto = _mapper.Map<PersonnelWithPersonnelSeniorityDto>(personnels);

        //    return CustomResponseDto<PersonnelWithPersonnelSeniorityDto>.Success(200, personnelsDto);
        //}

        //public async Task<CustomResponseDto<List<PersonnelWithWatchDto>>> GetPersonnelsWithWatch()
        //{
        //    var personnels = await _personnelRepository.GetPersonnelsWithWatch();

        //    var personnelsDto = _mapper.Map<List<PersonnelWithWatchDto>>(personnels);

        //    return CustomResponseDto<List<PersonnelWithWatchDto>>.Success(200, personnelsDto);
        //}

        //public async Task<CustomResponseDto<List<WatchWithPersonnelsDto>>> GetPersonnelsByWatchStartTime(int watchId)
        //{
        //    var personnels = await _personnelRepository.GetPersonnelsByWatchStartTime(watchId);

        //    var personnelsDto = _mapper.Map<List<WatchWithPersonnelsDto>>(personnels);

        //    return CustomResponseDto<List<WatchWithPersonnelsDto>>.Success(200, personnelsDto);
        //}
    }
}
