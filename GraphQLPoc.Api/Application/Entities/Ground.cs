namespace GraphQLPoc.Api.Application.Entities
{
    public class Ground
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //sorry, should be int
        public double Capacity { get; set; }
    }
}