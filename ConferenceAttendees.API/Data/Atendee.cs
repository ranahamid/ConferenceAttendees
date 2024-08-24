using System.ComponentModel.DataAnnotations;

namespace ConferenceAttendees.API.Data
{
    public class Atendee : BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;
        [MaxLength(50)]
        public string LastName { get; set; } = null!;
        [MaxLength(150)]
        public string EmailAddress { get; set; } = null!;
        [MaxLength(14)]
        public string PhoneNumber { get; set; } = null!;
        [MaxLength(150)]
        public string CompanyName { get; set; } = null!;
     //   public ReferralSource? ReferralSource { get; set; } = null!;
        public Guid ReferralSourceId { get; set; }
      //  public JobRole? JobRole { get; set; } = null!;
        public Guid JobRoleId { get; set; }
      //  public Gender? Gender { get; set; } = null!;    
        public Guid GenderId { get; set; }
    }
}
