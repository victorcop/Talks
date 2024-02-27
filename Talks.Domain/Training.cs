using System.Diagnostics.CodeAnalysis;

namespace Talks.Domain
{
    [ExcludeFromCodeCoverage]
    public class Training
    {
        /// <summary>
        /// Training Id
        /// </summary>
        public int TrainingId { get; set; }
        /// <summary>
        /// Training Reference Id
        /// </summary>
        public Guid TrainingReferenceId { get; set; }
        /// <summary>
        /// Object of the type <see cref="Domain.Speaker"/>
        /// </summary>
        public Speaker? Speaker { get; set; } = null;
        /// <summary>
        /// Training name
        /// </summary>
        public string? Name { get; set; } = string.Empty;
        /// <summary>
        /// Training code
        /// </summary>
        public string? Code { get; set; } = string.Empty;
        /// <summary>
        /// Training location object of the type <see cref="Domain.Location"/>
        /// </summary>
        public Location? Location { get; set; } = null;
        /// <summary>
        /// Event Date
        /// </summary>
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        /// <summary>
        /// Training Length
        /// </summary>
        public int Length { get; set; } = 1;
    }
}