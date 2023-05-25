using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Repository;
using NLayer.Service.Services;
using System.Linq;

namespace NLayer.API.Controllers
{
    public class DistributionController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IPersonnelService _personnelService;
        private readonly IWatchService _watchService;
        private readonly AppDbContext _context;


        public DistributionController(IService<Personnel> service, IService<Watch> service2, IMapper mapper, IPersonnelService personnelService, IWatchService watchService)
        {
            _mapper = mapper;
            _personnelService = personnelService;
            _watchService = watchService;
        }

        [HttpGet]
        public async Task<IActionResult> WatchDist(DateTime startDate, DateTime endDate)
        {
            var personnel = await _personnelService.GetAllAsync();
            var personnelsDtos = _mapper.Map<List<PersonnelDto>>(personnel.ToList());

            var dateRange = Enumerable.Range(0, (endDate - startDate).Days + 1)
                .Select(offset => startDate.AddDays(offset));

            var watchAssignments = new List<WatchDto>();
            var assignedPersonnels = new Dictionary<DateTime, int>();
            var random = new Random();

            var thursdays = dateRange.Where(date => date.DayOfWeek == DayOfWeek.Thursday).ToList();
            var personnelCount = personnelsDtos.Count;
            var thursdayIndex = 0;

            foreach (var date in dateRange)
            {
                var assignedPersonnelId = -1;

                if (date.DayOfWeek == DayOfWeek.Thursday)
                {
                    // Perşembe günleri için nöbet ataması
                    var thursdayPersonnelId = personnelsDtos[thursdayIndex].Id;
                    assignedPersonnelId = thursdayPersonnelId;
                    assignedPersonnels[date] = assignedPersonnelId;

                    thursdayIndex = (thursdayIndex + 1) % personnelCount; // Personel sırasını bir sonraki kişiye geçirme
                }
                else
                {
                    // Diğer günler için nöbet ataması
                    var previousDay = date.AddDays(-1);
                    var previousTwoDays = date.AddDays(-2);

                    var previousPersonnelId = assignedPersonnels.ContainsKey(previousDay) ? assignedPersonnels[previousDay] : -1;
                    var previousTwoPersonnelId = assignedPersonnels.ContainsKey(previousTwoDays) ? assignedPersonnels[previousTwoDays] : -1;

                    var availablePersonnels = personnelsDtos
                        .Where(p => p.Id != previousPersonnelId && p.Id != previousTwoPersonnelId)
                        .ToList();

                    if (availablePersonnels.Count > 0)
                    {
                        assignedPersonnelId = availablePersonnels[random.Next(availablePersonnels.Count)].Id;
                        assignedPersonnels[date] = assignedPersonnelId;
                    }
                    else
                    {
                        assignedPersonnelId = personnelsDtos[random.Next(personnelsDtos.Count)].Id;
                        assignedPersonnels[date] = assignedPersonnelId;
                    }
                }

                var assignedPersonnel = personnelsDtos.FirstOrDefault(p => p.Id == assignedPersonnelId);
                if (assignedPersonnel != null)
                {
                    var watchAssignment = new WatchDto
                    {
                        WatchDate = date,
                        PersonnelName = assignedPersonnel.Name,
                        PersonnelId = assignedPersonnel.Id
                    };

                    watchAssignments.Add(watchAssignment);
                }
            }

            // Perşembe günlerinden sonra ilk cumartesi ve ilk pazar nöbetlerini kaldırma
            watchAssignments.RemoveAll(w => w.WatchDate.DayOfWeek == DayOfWeek.Saturday && thursdays.Contains(w.WatchDate.AddDays(-1)));
            watchAssignments.RemoveAll(w => w.WatchDate.DayOfWeek == DayOfWeek.Sunday && thursdays.Contains(w.WatchDate.AddDays(-2)));

            return Ok(watchAssignments);
        }





        ////////// En kararlı sürüm.
        //[HttpGet]
        //public async Task<IActionResult> WatchDist(DateTime startDate, DateTime endDate)
        //{
        //    var personnel = await _personnelService.GetAllAsync();
        //    var personnelsDtos = _mapper.Map<List<PersonnelDto>>(personnel.ToList());

        //    var dateRange = Enumerable.Range(0, (endDate - startDate).Days + 1)
        //        .Select(offset => startDate.AddDays(offset));

        //    var watchAssignments = new List<WatchDto>();
        //    var assignedPersonnels = new Dictionary<DateTime, int>();
        //    var random = new Random();

        //    var thursdays = dateRange.Where(date => date.DayOfWeek == DayOfWeek.Thursday).ToList();
        //    var personnelCount = personnelsDtos.Count;
        //    var thursdayIndex = 0;

        //    foreach (var date in dateRange)
        //    {
        //        var assignedPersonnelId = -1;

        //        if (date.DayOfWeek == DayOfWeek.Thursday)
        //        {
        //            // Perşembe günleri için nöbet ataması
        //            var thursdayPersonnelId = personnelsDtos[thursdayIndex].Id;
        //            assignedPersonnelId = thursdayPersonnelId;
        //            assignedPersonnels[date] = assignedPersonnelId;

        //            thursdayIndex = (thursdayIndex + 1) % personnelCount; // Personel sırasını bir sonraki kişiye geçirme
        //        }
        //        else
        //        {
        //            // Diğer günler için nöbet ataması
        //            var previousDay = date.AddDays(-1);
        //            var previousTwoDays = date.AddDays(-2);

        //            var previousPersonnelId = assignedPersonnels.ContainsKey(previousDay) ? assignedPersonnels[previousDay] : -1;
        //            var previousTwoPersonnelId = assignedPersonnels.ContainsKey(previousTwoDays) ? assignedPersonnels[previousTwoDays] : -1;

        //            var availablePersonnels = personnelsDtos
        //                .Where(p => p.Id != previousPersonnelId && p.Id != previousTwoPersonnelId)
        //                .ToList();

        //            if (availablePersonnels.Count > 0)
        //            {
        //                assignedPersonnelId = availablePersonnels[random.Next(availablePersonnels.Count)].Id;
        //                assignedPersonnels[date] = assignedPersonnelId;
        //            }
        //            else
        //            {
        //                assignedPersonnelId = personnelsDtos[random.Next(personnelsDtos.Count)].Id;
        //                assignedPersonnels[date] = assignedPersonnelId;
        //            }
        //        }

        //        var assignedPersonnel = personnelsDtos.FirstOrDefault(p => p.Id == assignedPersonnelId);
        //        if (assignedPersonnel != null)
        //        {
        //            var watchAssignment = new WatchDto
        //            {
        //                WatchDate = date,
        //                PersonnelName = assignedPersonnel.Name,
        //                PersonnelId = assignedPersonnel.Id
        //            };

        //            watchAssignments.Add(watchAssignment);
        //        }
        //    }

        //    // Perşembe günlerinden sonra ilk cumartesi ve ilk pazar nöbetlerini kaldırma
        //    watchAssignments.RemoveAll(w => w.WatchDate.DayOfWeek == DayOfWeek.Saturday && thursdays.Contains(w.WatchDate.AddDays(-1)));
        //    watchAssignments.RemoveAll(w => w.WatchDate.DayOfWeek == DayOfWeek.Sunday && thursdays.Contains(w.WatchDate.AddDays(-2)));

        //    return Ok(watchAssignments);
        //}









        //[HttpGet]
        //public async Task<IActionResult> WatchDist(DateTime startDate, DateTime endDate)
        //{
        //    var personnel = await _personnelService.GetAllAsync();
        //    var personnelsDtos = _mapper.Map<List<PersonnelDto>>(personnel.ToList());

        //    var dateRange = Enumerable.Range(0, (endDate - startDate).Days + 1)
        //        .Select(offset => startDate.AddDays(offset));

        //    var watchAssignments = new List<WatchDto>();
        //    var assignedPersonnels = new Dictionary<DateTime, int>();
        //    var random = new Random();

        //    var perThursdayCount = dateRange.Count(d => d.DayOfWeek == DayOfWeek.Thursday);
        //    var personnelCount = personnelsDtos.Count;

        //    if (personnelCount == 0)
        //    {
        //        return NotFound("No personnel available.");
        //    }

        //    var perThursdayCountPerPerson = perThursdayCount / personnelCount;
        //    var perThursdayRemainder = perThursdayCount % personnelCount;

        //    var thursdayPersonnelIndices = new List<int>();
        //    for (int i = 0; i < personnelCount; i++)
        //    {
        //        thursdayPersonnelIndices.AddRange(Enumerable.Repeat(i, perThursdayCountPerPerson));
        //    }

        //    // Dağıtılamayan Perşembe günü nöbetlerini rastgele personellere atama
        //    var unassignedThursdays = perThursdayCount - (perThursdayCountPerPerson * personnelCount);
        //    if (unassignedThursdays > 0)
        //    {
        //        var remainingPersonnelIndices = Enumerable.Range(0, personnelCount).Except(thursdayPersonnelIndices).ToList();
        //        for (int i = 0; i < unassignedThursdays; i++)
        //        {
        //            var randomPersonnelIndex = remainingPersonnelIndices[random.Next(remainingPersonnelIndices.Count)];
        //            thursdayPersonnelIndices.Add(randomPersonnelIndex);
        //            remainingPersonnelIndices.Remove(randomPersonnelIndex);
        //        }
        //    }

        //    foreach (var date in dateRange)
        //    {
        //        var assignedPersonnelId = -1;

        //        if (date.DayOfWeek == DayOfWeek.Thursday)
        //        {
        //            var thursdayPersonnelIndex = thursdayPersonnelIndices[0];
        //            assignedPersonnelId = personnelsDtos[thursdayPersonnelIndex].Id;
        //            thursdayPersonnelIndices.RemoveAt(0);

        //            assignedPersonnels[date] = assignedPersonnelId;
        //        }
        //        else
        //        {
        //            // Diğer günler için nöbet ataması
        //            var previousDay = date.AddDays(-1);
        //            var previousPersonnelId = assignedPersonnels.ContainsKey(previousDay) ? assignedPersonnels[previousDay] : -1;

        //            var availablePersonnels = personnelsDtos
        //                .Where(p => p.Id != previousPersonnelId && !assignedPersonnels.ContainsValue(p.Id))
        //                .ToList();

        //            if (availablePersonnels.Count > 0)
        //            {
        //                assignedPersonnelId = availablePersonnels[random.Next(availablePersonnels.Count)].Id;
        //                assignedPersonnels[date] = assignedPersonnelId;
        //            }
        //            else
        //            {
        //                assignedPersonnelId = personnelsDtos[random.Next(personnelsDtos.Count)].Id;
        //                assignedPersonnels[date] = assignedPersonnelId;
        //            }
        //        }

        //        var assignedPersonnel = personnelsDtos.FirstOrDefault(p => p.Id == assignedPersonnelId);
        //        if (assignedPersonnel != null)
        //        {
        //            var watchAssignment = new WatchDto
        //            {
        //                WatchDate = date,
        //                PersonnelName = assignedPersonnel.Name,
        //                PersonnelId = assignedPersonnel.Id
        //            };

        //            watchAssignments.Add(watchAssignment);
        //        }
        //    }

        //    // Perşembe günleri sonrası cumartesi ve pazar nöbetlerini kaldırma
        //    var thursdays = watchAssignments.Where(w => w.WatchDate.DayOfWeek == DayOfWeek.Thursday).Select(w => w.WatchDate).ToList();
        //    watchAssignments.RemoveAll(w => w.WatchDate.DayOfWeek == DayOfWeek.Saturday && thursdays.Contains(w.WatchDate.AddDays(-1)));
        //    watchAssignments.RemoveAll(w => w.WatchDate.DayOfWeek == DayOfWeek.Sunday && thursdays.Contains(w.WatchDate.AddDays(-2)));

        //    return Ok(watchAssignments);
        //}










        //[HttpGet]
        //public async Task<IActionResult> WatchDist(DateTime startDate, DateTime endDate)
        //{
        //    var personnel = await _personnelService.GetAllAsync();
        //    var personnelsDtos = _mapper.Map<List<PersonnelDto>>(personnel.ToList());

        //    var dateRange = Enumerable.Range(0, (endDate - startDate).Days + 1)
        //        .Select(offset => startDate.AddDays(offset));

        //    var watchAssignments = new List<WatchDto>();
        //    var assignedPersonnels = new Dictionary<DateTime, int>();
        //    var random = new Random();

        //    var perThursdayCount = dateRange.Count(d => d.DayOfWeek == DayOfWeek.Thursday);
        //    var personnelCount = personnelsDtos.Count;

        //    if (personnelCount == 0)
        //    {
        //        return NotFound("No personnel available.");
        //    }

        //    var perThursdayCountPerPerson = perThursdayCount / personnelCount;
        //    var perThursdayRemainder = perThursdayCount % personnelCount;

        //    var thursdayPersonnelIndices = new List<int>();
        //    for (int i = 0; i < personnelCount; i++)
        //    {
        //        thursdayPersonnelIndices.AddRange(Enumerable.Repeat(i, perThursdayCountPerPerson));
        //    }

        //    // Dağıtılamayan Perşembe günü nöbetlerini rastgele personellere atama
        //    var unassignedThursdays = perThursdayCount - (perThursdayCountPerPerson * personnelCount);
        //    if (unassignedThursdays > 0)
        //    {
        //        var remainingPersonnelIndices = Enumerable.Range(0, personnelCount).Except(thursdayPersonnelIndices).ToList();
        //        for (int i = 0; i < unassignedThursdays; i++)
        //        {
        //            var randomPersonnelIndex = remainingPersonnelIndices[random.Next(remainingPersonnelIndices.Count)];
        //            thursdayPersonnelIndices.Add(randomPersonnelIndex);
        //            remainingPersonnelIndices.Remove(randomPersonnelIndex);
        //        }
        //    }

        //    foreach (var date in dateRange)
        //    {
        //        var assignedPersonnelId = -1;

        //        if (date.DayOfWeek == DayOfWeek.Thursday)
        //        {
        //            var thursdayPersonnelIndex = thursdayPersonnelIndices[0];
        //            assignedPersonnelId = personnelsDtos[thursdayPersonnelIndex].Id;
        //            thursdayPersonnelIndices.RemoveAt(0);

        //            assignedPersonnels[date] = assignedPersonnelId;
        //        }
        //        else
        //        {
        //            // Diğer günler için nöbet ataması
        //            var previousDay = date.AddDays(-1);
        //            var previousPersonnelId = assignedPersonnels.ContainsKey(previousDay) ? assignedPersonnels[previousDay] : -1;

        //            var availablePersonnels = personnelsDtos
        //                .Where(p => p.Id != previousPersonnelId && !assignedPersonnels.ContainsValue(p.Id))
        //                .ToList();

        //            if (availablePersonnels.Count > 0)
        //            {
        //                assignedPersonnelId = availablePersonnels[random.Next(availablePersonnels.Count)].Id;
        //                assignedPersonnels[date] = assignedPersonnelId;
        //            }
        //            else
        //            {
        //                assignedPersonnelId = personnelsDtos[random.Next(personnelsDtos.Count)].Id;
        //                assignedPersonnels[date] = assignedPersonnelId;
        //            }
        //        }

        //        var assignedPersonnel = personnelsDtos.FirstOrDefault(p => p.Id == assignedPersonnelId);
        //        if (assignedPersonnel != null)
        //        {
        //            var watchAssignment = new WatchDto
        //            {
        //                WatchDate = date,
        //                PersonnelName = assignedPersonnel.Name,
        //                PersonnelId = assignedPersonnel.Id
        //            };

        //            watchAssignments.Add(watchAssignment);
        //        }
        //    }

        //    return Ok(watchAssignments);
        //}













        //[HttpGet]
        //public async Task<IActionResult> WatchDist(DateTime startDate, DateTime endDate)
        //{
        //    var personnel = await _personnelService.GetAllAsync();
        //    var personnelsDtos = _mapper.Map<List<PersonnelDto>>(personnel.ToList());

        //    var dateRange = Enumerable.Range(0, (endDate - startDate).Days + 1)
        //        .Select(offset => startDate.AddDays(offset));

        //    var watchAssignments = new List<WatchDto>();
        //    var assignedPersonnels = new Dictionary<DateTime, int>();
        //    var random = new Random();

        //    var perThursdayCount = dateRange.Count(d => d.DayOfWeek == DayOfWeek.Thursday);
        //    var personnelCount = personnelsDtos.Count;

        //    if (personnelCount == 0)
        //    {
        //        return NotFound("No personnel available.");
        //    }

        //    var perThursdayCountPerPerson = perThursdayCount / personnelCount;
        //    var perThursdayRemainder = perThursdayCount % personnelCount;

        //    var thursdayPersonnelIndex = 0;
        //    var thursdayPersonnelIds = personnelsDtos.Select(p => p.Id).ToList();

        //    foreach (var date in dateRange)
        //    {
        //        var assignedPersonnelId = -1;

        //        if (date.DayOfWeek == DayOfWeek.Thursday)
        //        {
        //            assignedPersonnelId = thursdayPersonnelIds[thursdayPersonnelIndex];

        //            thursdayPersonnelIndex++;
        //            if (thursdayPersonnelIndex >= personnelCount)
        //            {
        //                thursdayPersonnelIndex = 0;
        //            }

        //            assignedPersonnels[date] = assignedPersonnelId;
        //        }
        //        else
        //        {
        //            // Diğer günler için nöbet ataması
        //            var previousDay = date.AddDays(-1);
        //            var previousPersonnelId = assignedPersonnels.ContainsKey(previousDay) ? assignedPersonnels[previousDay] : -1;

        //            var availablePersonnels = personnelsDtos
        //                .Where(p => p.Id != previousPersonnelId && !assignedPersonnels.ContainsValue(p.Id))
        //                .ToList();

        //            if (availablePersonnels.Count > 0)
        //            {
        //                assignedPersonnelId = availablePersonnels[random.Next(availablePersonnels.Count)].Id;
        //                assignedPersonnels[date] = assignedPersonnelId;
        //            }
        //            else
        //            {
        //                assignedPersonnelId = personnelsDtos[random.Next(personnelsDtos.Count)].Id;
        //                assignedPersonnels[date] = assignedPersonnelId;
        //            }
        //        }

        //        var assignedPersonnel = personnelsDtos.FirstOrDefault(p => p.Id == assignedPersonnelId);
        //        if (assignedPersonnel != null)
        //        {
        //            var watchAssignment = new WatchDto
        //            {
        //                WatchDate = date,
        //                PersonnelName = assignedPersonnel.Name,
        //                PersonnelId = assignedPersonnel.Id
        //            };

        //            watchAssignments.Add(watchAssignment);
        //        }
        //    }

        //    // Perşembe günlerine ek olarak nöbet ataması
        //    var thursdays = watchAssignments.Where(w => w.WatchDate.DayOfWeek == DayOfWeek.Thursday).Select(w => w.WatchDate).ToList();
        //    var saturdays = watchAssignments.Where(w => w.WatchDate.DayOfWeek == DayOfWeek.Saturday).Select(w => w.WatchDate).ToList();
        //    var sundays = watchAssignments.Where(w => w.WatchDate.DayOfWeek == DayOfWeek.Sunday).Select(w => w.WatchDate).ToList();

        //    foreach (var thursday in thursdays)
        //    {
        //        if (!saturdays.Contains(thursday.AddDays(1)) && !sundays.Contains(thursday.AddDays(2)))
        //        {
        //            var assignedPersonnelId = -1;
        //            var availablePersonnels = personnelsDtos
        //                .Where(p => !assignedPersonnels.ContainsValue(p.Id))
        //                .ToList();

        //            if (availablePersonnels.Count > 0)
        //            {
        //                assignedPersonnelId = availablePersonnels[random.Next(availablePersonnels.Count)].Id;
        //                assignedPersonnels[thursday.AddDays(1)] = assignedPersonnelId;
        //                assignedPersonnels[thursday.AddDays(2)] = assignedPersonnelId;

        //                var assignedPersonnel = personnelsDtos.FirstOrDefault(p => p.Id == assignedPersonnelId);
        //                if (assignedPersonnel != null)
        //                {
        //                    var saturdayAssignment = new WatchDto
        //                    {
        //                        WatchDate = thursday.AddDays(1),
        //                        PersonnelName = assignedPersonnel.Name,
        //                        PersonnelId = assignedPersonnel.Id
        //                    };

        //                    var sundayAssignment = new WatchDto
        //                    {
        //                        WatchDate = thursday.AddDays(2),
        //                        PersonnelName = assignedPersonnel.Name,
        //                        PersonnelId = assignedPersonnel.Id
        //                    };

        //                    watchAssignments.Add(saturdayAssignment);
        //                    watchAssignments.Add(sundayAssignment);
        //                }
        //            }
        //        }
        //    }

        //    return Ok(watchAssignments);
        //}













        //////////////     En tutarlısı 
        //[HttpGet]
        //public async Task<IActionResult> WatchDist(DateTime startDate, DateTime endDate)
        //{
        //    var personnel = await _personnelService.GetAllAsync();
        //    var personnelsDtos = _mapper.Map<List<PersonnelDto>>(personnel.ToList());

        //    var dateRange = Enumerable.Range(0, (endDate - startDate).Days + 1)
        //        .Select(offset => startDate.AddDays(offset));

        //    var watchAssignments = new List<WatchDto>();
        //    var assignedPersonnels = new Dictionary<DateTime, int>();
        //    var random = new Random();

        //    foreach (var date in dateRange)
        //    {
        //        var assignedPersonnelId = -1;

        //        if (date.DayOfWeek == DayOfWeek.Thursday)
        //        {
        //            // Perşembe günleri için nöbet ataması
        //            var availablePersonnels = personnelsDtos
        //                .Where(p => !assignedPersonnels.ContainsValue(p.Id))
        //                .ToList();

        //            if (availablePersonnels.Count > 0)
        //            {
        //                assignedPersonnelId = availablePersonnels[random.Next(availablePersonnels.Count)].Id;
        //                assignedPersonnels[date] = assignedPersonnelId;
        //            }
        //            else
        //            {
        //                assignedPersonnelId = personnelsDtos[random.Next(personnelsDtos.Count)].Id;
        //                assignedPersonnels[date] = assignedPersonnelId;
        //            }
        //        }
        //        else
        //        {
        //            // Diğer günler için nöbet ataması
        //            var previousDay = date.AddDays(-1);
        //            var previousPersonnelId = assignedPersonnels.ContainsKey(previousDay) ? assignedPersonnels[previousDay] : -1;

        //            var availablePersonnels = personnelsDtos
        //                .Where(p => p.Id != previousPersonnelId && !assignedPersonnels.ContainsValue(p.Id))
        //                .ToList();

        //            if (availablePersonnels.Count > 0)
        //            {
        //                assignedPersonnelId = availablePersonnels[random.Next(availablePersonnels.Count)].Id;
        //                assignedPersonnels[date] = assignedPersonnelId;
        //            }
        //            else
        //            {
        //                assignedPersonnelId = personnelsDtos[random.Next(personnelsDtos.Count)].Id;
        //                assignedPersonnels[date] = assignedPersonnelId;
        //            }
        //        }

        //        var assignedPersonnel = personnelsDtos.FirstOrDefault(p => p.Id == assignedPersonnelId);
        //        if (assignedPersonnel != null)
        //        {
        //            var watchAssignment = new WatchDto
        //            {
        //                WatchDate = date,
        //                PersonnelName = assignedPersonnel.Name,
        //                PersonnelId = assignedPersonnel.Id
        //            };

        //            watchAssignments.Add(watchAssignment);
        //        }
        //    }

        //    // Perşembe günlerine ek olarak nöbet ataması
        //    var thursdays = watchAssignments.Where(w => w.WatchDate.DayOfWeek == DayOfWeek.Thursday).Select(w => w.WatchDate).ToList();
        //    var saturdays = watchAssignments.Where(w => w.WatchDate.DayOfWeek == DayOfWeek.Saturday).Select(w => w.WatchDate).ToList();
        //    var sundays = watchAssignments.Where(w => w.WatchDate.DayOfWeek == DayOfWeek.Sunday).Select(w => w.WatchDate).ToList();

        //    foreach (var thursday in thursdays)
        //    {
        //        if (!saturdays.Contains(thursday.AddDays(1)) && !sundays.Contains(thursday.AddDays(2)))
        //        {
        //            var availablePersonnels = personnelsDtos
        //                .Where(p => !assignedPersonnels.ContainsValue(p.Id) && p.Id != assignedPersonnels[thursday])
        //                .ToList();

        //            if (availablePersonnels.Count > 0)
        //            {
        //                var assignedPersonnelId = availablePersonnels[random.Next(availablePersonnels.Count)].Id;
        //                assignedPersonnels[thursday.AddDays(1)] = assignedPersonnelId;
        //                assignedPersonnels[thursday.AddDays(2)] = assignedPersonnelId;

        //                var assignedPersonnel = personnelsDtos.FirstOrDefault(p => p.Id == assignedPersonnelId);
        //                if (assignedPersonnel != null)
        //                {
        //                    var saturdayAssignment = new WatchDto
        //                    {
        //                        WatchDate = thursday.AddDays(1),
        //                        PersonnelName = assignedPersonnel.Name,
        //                        PersonnelId = assignedPersonnel.Id
        //                    };

        //                    var sundayAssignment = new WatchDto
        //                    {
        //                        WatchDate = thursday.AddDays(2),
        //                        PersonnelName = assignedPersonnel.Name,
        //                        PersonnelId = assignedPersonnel.Id
        //                    };

        //                    watchAssignments.Add(saturdayAssignment);
        //                    watchAssignments.Add(sundayAssignment);
        //                }
        //            }
        //        }
        //    }

        //    return Ok(watchAssignments);
        //}







        //[HttpGet]
        //public async Task<IActionResult> WatchDist(DateTime startDate, DateTime endDate)
        //{
        //    var personnel = await _personnelService.GetAllAsync();
        //    var personnelsDtos = _mapper.Map<List<PersonnelDto>>(personnel.ToList());

        //    // Tarih aralığındaki tüm tarihleri elde etmek
        //    var dateRange = Enumerable.Range(0, (endDate - startDate).Days + 1)
        //        .Select(offset => startDate.AddDays(offset));

        //    var random = new Random();
        //    var watchAssignments = new List<WatchDto>();

        //    var thursdays = dateRange.Where(date => date.DayOfWeek == DayOfWeek.Thursday).ToList();

        //    // Her personelin nöbet sayısını takip etmek için bir sözlük oluşturma
        //    var personWatchCounts = personnelsDtos.ToDictionary(p => p.Id, p => 0);

        //    foreach (var date in dateRange)
        //    {
        //        // Personel seçimini kontrol etmek için geçerli personelin nöbet sayısını al
        //        var currentPersonnelId = personnelsDtos[random.Next(personnelsDtos.Count)].Id;
        //        var currentPersonnelWatchCount = personWatchCounts[currentPersonnelId];

        //        // Nöbet ataması oluşturma
        //        var watchAssignment = new WatchDto
        //        {
        //            WatchDate = date,
        //            PersonnelName = personnelsDtos.First(p => p.Id == currentPersonnelId).Name,
        //            PersonnelId = currentPersonnelId
        //        };

        //        // Perşembe günleri eşit dağıtım
        //        if (date.DayOfWeek == DayOfWeek.Thursday)
        //        {
        //            var remainingPersonnels = personnelsDtos.Where(p => p.Id != currentPersonnelId).ToList();
        //            var remainingThursdays = thursdays.Except(watchAssignments.Select(w => w.WatchDate)).ToList();

        //            foreach (var thursday in remainingThursdays)
        //            {
        //                // Rastgele kalan personeli seçme
        //                var randomRemainingPersonnel = remainingPersonnels[random.Next(remainingPersonnels.Count)];
        //                var randomRemainingPersonnelId = randomRemainingPersonnel.Id;

        //                // Geçerli personelin nöbet sayısını kontrol et
        //                 {
        //                    randomRemainingPersonnel = remainingPersonnels[random.Next(remainingPersonnels.Count)];
        //                    randomRemainingPersonnelId = randomRemainingPersonnel.Id;
        //                }

        //                // Nöbet ataması oluşturma
        //                var watchAssignmentThursday = new WatchDto
        //                {
        //                    WatchDate = thursday,
        //                    PersonnelName = randomRemainingPersonnel.Name,
        //                    PersonnelId = randomRemainingPersonnelId
        //                };

        //                watchAssignments.Add(watchAssignmentThursday);
        //                personWatchCounts[randomRemainingPersonnelId]++;
        //            }
        //        }

        //        watchAssignments.Add(watchAssignment);
        //        personWatchCounts[currentPersonnelId]++;
        //    }

        //    // Perşembe günleri sonrası cumartesi ve pazar nöbetlerini kaldırma
        //    watchAssignments.RemoveAll(w => w.WatchDate.DayOfWeek == DayOfWeek.Saturday && thursdays.Contains(w.WatchDate.AddDays(-1)));
        //    watchAssignments.RemoveAll(w => w.WatchDate.DayOfWeek == DayOfWeek.Sunday && thursdays.Contains(w.WatchDate.AddDays(-2)));

        //    return Ok(watchAssignments);
        //}


        //[HttpGet]
        //public async Task<IActionResult> WatchDist(DateTime startDate, DateTime endDate)
        //{
        //    var personnel = await _personnelService.GetAllAsync();
        //    var personnelsDtos = _mapper.Map<List<PersonnelDto>>(personnel.ToList());

        //    // Tarih aralığındaki tüm tarihleri elde etmek
        //    var dateRange = Enumerable.Range(0, (endDate - startDate).Days + 1)
        //        .Select(offset => startDate.AddDays(offset));

        //    var random = new Random();
        //    var watchAssignments = new List<WatchDto>();

        //    var thursdays = dateRange.Where(date => date.DayOfWeek == DayOfWeek.Thursday).ToList();

        //    foreach (var date in dateRange)
        //    {
        //        // Rastgele personel seçimi
        //        var randomPersonnel = personnelsDtos[random.Next(personnelsDtos.Count)];

        //        // Nöbet ataması oluşturma
        //        var watchAssignment = new WatchDto
        //        {
        //            WatchDate = date,
        //            PersonnelName = randomPersonnel.Name,
        //            PersonnelId = randomPersonnel.Id
        //        };

        //        // Perşembe günleri eşit dağıtım
        //        if (date.DayOfWeek == DayOfWeek.Thursday)
        //        {
        //            var remainingPersonnels = personnelsDtos.Where(p => p.Id != randomPersonnel.Id).ToList();
        //            var remainingThursdays = thursdays.Except(watchAssignments.Select(w => w.WatchDate)).ToList();

        //            foreach (var thursday in remainingThursdays)
        //            {
        //                var randomRemainingPersonnel = remainingPersonnels[random.Next(remainingPersonnels.Count)];

        //                var watchAssignmentThursday = new WatchDto
        //                {
        //                    WatchDate = thursday,
        //                    PersonnelName = randomRemainingPersonnel.Name,
        //                    PersonnelId = randomRemainingPersonnel.Id
        //                };

        //                watchAssignments.Add(watchAssignmentThursday);
        //          }
        //        }

        //        watchAssignments.Add(watchAssignment);
        //    }

        //    // Perşembe günleri sonrası cumartesi ve pazar nöbetlerini kaldırma
        //    watchAssignments.RemoveAll(w => w.WatchDate.DayOfWeek == DayOfWeek.Saturday && thursdays.Contains(w.WatchDate.AddDays(-1)));
        //    watchAssignments.RemoveAll(w => w.WatchDate.DayOfWeek == DayOfWeek.Sunday && thursdays.Contains(w.WatchDate.AddDays(-2)));

        //   return Ok(watchAssignments);
        //}


        //[HttpGet]
        //public async Task<IActionResult> WatchDist(DateTime startDate, DateTime endDate)
        //{
        //    var personnel = await _personnelService.GetAllAsync();
        //    var personnelsDtos = _mapper.Map<List<PersonnelDto>>(personnel.ToList());

        //    // Tarih aralığındaki tüm tarihleri elde etmek
        //    var dateRange = Enumerable.Range(0, (endDate - startDate).Days + 1)
        //        .Select(offset => startDate.AddDays(offset));

        //    var random = new Random();
        //    var watchAssignments = new List<WatchDto>();

        //    foreach (var date in dateRange)
        //    {
        //        // Rastgele personel seçimi
        //        var randomPersonnel = personnelsDtos[random.Next(personnelsDtos.Count)];

        //        // Nöbet ataması oluşturma
        //        var watchAssignment = new WatchDto
        //        {
        //            WatchDate = date,
        //            PersonnelName = randomPersonnel.Name,
        //            PersonnelId = randomPersonnel.Id,
        //        };

        //        watchAssignments.Add(watchAssignment);
        //    }

        //    return Ok(watchAssignments);
        //}

















        //[HttpGet]
        //public async Task<IActionResult> WatchDist()
        //{
        //    var personnels = await _personnelService.GetAllAsync();
        //    var personnelsDtos = _mapper.Map<List<PersonnelDto>>(personnels.ToList());

        //    var watchs = await _watchService.GetAllAsync();
        //    var watchsDto = _mapper.Map<List<WatchDto>>(watchs.ToList());

        //    List<string> nobetListesi = NöbetOluştur(personnelsDtos, watchsDto, 3);

        //    // Nöbet listesini isteğe bağlı olarak döndürebilirsiniz
        //    return Ok(nobetListesi);
        //}

        //private List<string> NöbetOluştur(List<PersonnelDto> personnels, List<WatchDto> watchs, int periyot)
        //{
        //    List<string> nobetListesi = new List<string>();

        //    if (personnels.Count == 0 || watchs.Count == 0 || periyot <= 0)
        //    {
        //        return nobetListesi;
        //    }

        //    int toplamNobetSayisi = personnels.Count * periyot;

        //    for (int i = 0; i < toplamNobetSayisi; i++)
        //    {
        //        int personnelIndex = i % personnels.Count;
        //        int watchIndex = i % watchs.Count;

        //        string nobet = personnels[personnelIndex].Name + " - " + watchs[watchIndex].WatchStartTime;
        //        nobetListesi.Add(nobet);
        //    }

        //    return nobetListesi;
        //}

    }
}
