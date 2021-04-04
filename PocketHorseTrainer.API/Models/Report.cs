﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class Report
    {
        public int Id { get; set; }
        public TimeLength TimeSpan { get; set; }
        public float TimeHandling { get; set; }
        public float TimeRiding { get; set; }
        public List<TargetAreas> Issues { get; set; }
        public List<TargetAreas> Strengths { get; set; }

        public Report()
        {
        }

        public void CalculateTimes(List<JournalEntry> entries)
        {
            foreach (JournalEntry entry in entries)
            {
                TimeHandling += entry.TimeHandling;
                TimeRiding += entry.TimeRiding;
            }
        }
    }
}
