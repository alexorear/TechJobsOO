using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobs.Data;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class NewJobViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Employer")]
        public int EmployerID { get; set; }

        // TODO #3 - Included other fields needed to create a job,
        // with correct validation attributes and display names.

        public int LocationID { get; set; }
        public int CoreCompetencyID { get; set; }
        public int PositionTypeID { get; set; }

        public List<SelectListItem> Employers { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Locations { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> CoreCompetencies { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> PositionTypes { get; set; } = new List<SelectListItem>();

        public NewJobViewModel()
        {

            JobData jobData = JobData.GetInstance();

            foreach (Employer employer in jobData.Employers.ToList())
            {
                Employers.Add(new SelectListItem {
                    Value = employer.ID.ToString(),
                    Text = employer.Value
                });
            }

            // TODO #4 - populate the other List<SelectListItem> 
            // collections needed in the view
            foreach (Location location in jobData.Locations.ToList())
            {
                Locations.Add(new SelectListItem
                {
                    Value = location.ID.ToString(),
                    Text = location.Value
                });
            }

            foreach (CoreCompetency coreCompetency in jobData.CoreCompetencies.ToList())
            {
                CoreCompetencies.Add(new SelectListItem
                {
                    Value = coreCompetency.ID.ToString(),
                    Text = coreCompetency.Value
                });
            }

            foreach (PositionType positionType in jobData.PositionTypes.ToList())
            {
                PositionTypes.Add(new SelectListItem
                {
                    Value = positionType.ID.ToString(),
                    Text = positionType.Value
                });
            }

        }
    }
}
