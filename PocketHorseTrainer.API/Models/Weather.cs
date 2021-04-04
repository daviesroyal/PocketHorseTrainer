﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class Weather
    {
        public float TempF { get; set; }
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
        public Weather()
        {
        }
    }
}
