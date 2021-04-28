namespace PocketHorseTrainer.Models.Horses
{
    public class Barn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Address: {Address}";
        }
    }
}
