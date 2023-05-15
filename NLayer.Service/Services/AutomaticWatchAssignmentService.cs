//using System;
//using System.Collections.Generic;
//using System.Linq;
//using NLayer.Core.Models;
//using NLayer.Core.Services;

//namespace NLayer.Service.Services
//{
//    public class AutomaticWatchAssignmentService : IAutomaticWatchAssignmentService
//    {
//        private readonly IPersonnelService _personnelService;
//        private readonly IWatchService _watchService;

//        public AutomaticWatchAssignmentService(IPersonnelService personnelService, IWatchService watchService)
//        {
//            _personnelService = personnelService;
//            _watchService = watchService;
//        }

//        public void AssignWatches(DateTime month, List<WatchExclusionDto> watchExclusions)
//        {
//            // Get all personnel
//            var personnel = _personnelService.GetPersonnel().ToList();

//            // Get all shifts for the given month
//            var shifts = _shiftService.GetShiftsByMonth(month).ToList();

//            // Calculate number of shifts for each personnel
//            int totalShifts = shifts.Count;
//            int shiftsPerPersonnel = totalShifts / personnel.Count;
//            int remainingShifts = totalShifts % personnel.Count;
//            int maxShiftsPerPersonnel = shiftsPerPersonnel + 1;

//            // Assign shifts to personnel
//            Random random = new Random();
//            int index = 0;
//            foreach (var shift in shifts)
//            {
//                // Exclude personnel who can't work on this day
//                var availablePersonnel = personnel.Where(p => p.ExcludedDays.All(d => d.Day != shift.Date.Day));

//                // Exclude personnel who have already been assigned the maximum number of shifts
//                var remainingPersonnel = availablePersonnel.Where(p => p.Shifts.Count(s => s.Date.Month == month.Month) < (remainingShifts > 0 ? maxShiftsPerPersonnel : shiftsPerPersonnel));

//                // Exclude personnel who have been excluded due to watch exclusion rules
//                var finalPersonnel = remainingPersonnel.Where(p => !watchExclusions.Any(w => w.PersonnelId == p.Id && w.ExcludedDates.Contains(shift.Date)));

//                // Assign the shift to a random person from the remaining personnel list
//                var randomIndex = random.Next(0, finalPersonnel.Count());
//                var assignedPersonnel = finalPersonnel.ElementAt(randomIndex);
//                assignedPersonnel.Shifts.Add(shift);

//                // Decrement remaining shifts
//                if (remainingShifts > 0) remainingShifts--;
//                index++;
//            }

//            // Save changes to the database
//            //_personnelService.SaveChanges();
//        }
//    }
//}
