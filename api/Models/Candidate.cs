using System;
using System.Collections.Generic;
using api.Models.Base;

namespace api.Models
{
    public class Candidate : BaseEntity
    {
        public int SubTitle { get; set; }

        public string FullName { get; set; }

        public string ViceFullName { get; set; }

        public List<Vote> Votes { get; set; }

        public static Candidate Create(string fullName, string viceFullName, int subTitle)
        {
            return new()
            {
                FullName = fullName,
                ViceFullName = viceFullName,
                SubTitle = subTitle,
                CreationDate = DateTime.Now
            };
        }

    }
}