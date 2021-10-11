using GraphQLPoc.Api.Application.Entities.Enums;

namespace GraphQLPoc.Api.Application.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PlayerPosition Position { get; set; }
        public bool Captain { get; set; }

        public int ClubId { get; set; }
        public virtual Club Club { get; set; }
    }
}