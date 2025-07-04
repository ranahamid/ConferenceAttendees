﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConferenceAttendees.API.Data.Configurations
{
    public class ReferralSourceConfiguration : IEntityTypeConfiguration<ReferralSource>
    {
        public void Configure(EntityTypeBuilder<ReferralSource> builder)
        {
            builder.HasData(
                    new ReferralSource
                    {
                        Id = new Guid("2930ec25-e259-49d6-be38-930b0c5a07dc"),
                        Name = "Internet Advertisement",
                    },
                    new ReferralSource
                    {
                        Id = new Guid("5295ecec-bb38-48f0-b6ab-f51ad57d38bd"),
                        Name = "Television",
                    },


                    new ReferralSource
                    {
                        Id = new Guid("1dbdadbb-3175-44bb-a3aa-fc95b6bfd44f"),
                        Name = "Newspaper Article",
                    },
                    new ReferralSource
                    {
                        Id = new Guid("f2118fcd-7413-42f7-b4cc-a2f6089145c4"),
                        Name = "Other",
                    }
                );

        }
    }
}
