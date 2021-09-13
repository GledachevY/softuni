namespace FootballArenas.Web.ViewModels.SportComplexViewModels
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    using FootballArenas.Data.Models.CustomModels;
    using FootballArenas.Services.Mapping;

    public class SportComplexInputViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "City")]
        public string AddressCity { get; set; }

        [Display(Name = "Street")]
        public string AddressStreet { get; set; }

        [Display(Name = "Number of street")]
        public string AddressNumberOfStreet { get; set; }

        [Display(Name = "User")]
        public string Username { get; set; }

        public IFormFileCollection Images { get; set; }

        public IEnumerable<FootballArenasUser> Users { get; set; }

        public List<FootballField> FootballFields { get; set; }
    }
}
