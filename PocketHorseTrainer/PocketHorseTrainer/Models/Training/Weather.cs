using System;
using System.Collections.Generic;
using System.Text;

namespace PocketHorseTrainer.Models.Training
{
    public enum Precipitation
    {
        None,
        Snow,
        Sleet,
        Hail,
        Rain
    }
    public enum Wind
    {
        None,
        Mild,
        Moderate,
        Severe,
        Extreme
    }
    public enum CloudCover
    {
        Clear,
        Partial,
        Overcast,
        Heavy
    }
    public enum Visibility
    {
        Low,
        Medium,
        High
    }
    public enum GroundCondition
    {
        Ice,
        Mud,
        Firm
    }

    public class Weather
    {
        public int Id { get; set; }
        public float TempF { get; set; }
        public Precipitation Precipitation { get; set; }
        public Wind Wind { get; set; }
        public CloudCover CloudCover { get; set; }
        public Visibility Visibility { get; set; }
        public GroundCondition GroundCondition { get; set; }

        public Weather()
        {
        }
    }
}
