using GraphQLPoc.Api.Application.Entities.Enums;
using System;
using System.Collections.Generic;

namespace GraphQLPoc.Api.Application.Entities
{
    public class Competition
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<Club> Clubs { get; set; }
    }
}