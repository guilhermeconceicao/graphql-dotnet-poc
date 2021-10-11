using System.Collections.Generic;

namespace GraphQLPoc.Api.Application.Entities
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Manager { get; set; }

        public int CompetitionId { get; set; }
        public virtual Competition Competition { get; set; }

        public int GroundId { get; set; }
        public virtual Ground Ground { get; set; }

        public int? RivalId { get; set; }
        public virtual Club Rival { get; set; }

        public virtual ICollection<Player> Squad { get; set; }
    }
}