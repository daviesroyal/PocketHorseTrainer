using System;
using System.Collections.Generic;
using System.Text;

namespace PocketHorseTrainer.Models.Enums
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
}
