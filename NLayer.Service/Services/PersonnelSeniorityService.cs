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
    
        public class PersonnelSeniorityService : Service<PersonnelSeniority>, IPersonnelSeniorityService
    {
            private readonly IPersonnelSeniorityRepository _personnelSeniorityRepository;
            private readonly IMapper _mapper;
            public PersonnelSeniorityService(IGenericRepository<PersonnelSeniority> repository, IUnitOfWork unitOfWork,
                IPersonnelSeniorityRepository personnelSeniorityRepository, IMapper mapper) : base(repository, unitOfWork)
        {
                _mapper = mapper;
                _personnelSeniorityRepository = personnelSeniorityRepository;

            }

            public async Task<CustomResponseDto<PersonnelWithPersonnelSeniorityDto>> GetSinglePersonnelByIdWithProductSeniorityAsync(int seniorityId)
            {
                var personnelSeniority = await _personnelSeniorityRepository.GetSinglePersonnelByIdWithProductSeniorityAsync(seniorityId);

                var personnelSeniorityDto = _mapper.Map<PersonnelWithPersonnelSeniorityDto>(personnelSeniority);

                return CustomResponseDto<PersonnelWithPersonnelSeniorityDto>.Success(200, personnelSeniorityDto);
            }
        }
    
}
