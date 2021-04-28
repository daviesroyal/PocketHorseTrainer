namespace PocketHorseTrainer.Models.Horses
{
    public class FaceMarking
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }

    public class LegMarking
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }

    public class Markings
    {
        public int Id { get; set; }

        public FaceMarking FaceMarking { get; set; }
        public LegMarking FrontLeft { get; set; }
        public LegMarking FrontRight { get; set; }
        public LegMarking BackLeft { get; set; }
        public LegMarking BackRight { get; set; }
    }
}
