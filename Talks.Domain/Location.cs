using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Talks.Domain
{
    [ExcludeFromCodeCoverage]
    public class Location
    {
        /// <summary>
        /// Location Reference Id
        /// </summary>
        [Key]
        public Guid LocationId { get; set; }
        /// <summary>
        /// Venue Name 
        /// </summary>
        public string? VenueName { get; set; } = string.Empty;
        /// <summary>
        /// Address 1
        /// </summary>
        public string? Address1 { get; set; } = string.Empty;
        /// <summary>
        /// Address 2
        /// </summary>
        public string? Address2 { get; set; } = string.Empty;
        /// <summary>
        /// Address 3
        /// </summary>
        public string? Address3 { get; set; } = string.Empty;
        /// <summary>
        /// City Town
        /// </summary>
        public string? CityTown { get; set; } = string.Empty;
        /// <summary>
        /// State Province
        /// </summary>
        public string? StateProvince { get; set; } = string.Empty;
        /// <summary>
        /// Postal Code
        /// </summary>
        public string? PostalCode { get; set; } = string.Empty;
        /// <summary>
        /// Country
        /// </summary>
        public string? Country { get; set; } = string.Empty;
    }
}