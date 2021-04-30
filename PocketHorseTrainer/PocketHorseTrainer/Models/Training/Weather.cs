using PocketHorseTrainer.Models.Enums;

namespace PocketHorseTrainer.Models.Training
{

    public class Weather
    {
        public int Id { get; set; }
        public float TempF { get; set; }
        public Precipitation Precipitation { get; set; }
        public Wind Wind { get; set; }
        public CloudCover CloudCover { get; set; }
        public Visibility Visibility { get; set; }
        public GroundCondition GroundCondition { get; set; }
    }
}
