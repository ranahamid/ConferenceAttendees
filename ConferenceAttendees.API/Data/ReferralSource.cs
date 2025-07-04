﻿using System.ComponentModel.DataAnnotations;

namespace ConferenceAttendees.API.Data
{
    public class ReferralSource : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; } = null!;
    }
}
