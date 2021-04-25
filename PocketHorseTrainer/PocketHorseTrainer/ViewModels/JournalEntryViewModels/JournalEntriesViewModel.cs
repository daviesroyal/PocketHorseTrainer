using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketHorseTrainer.ViewModels.JournalEntryViewModels
{
    public class JournalEntriesViewModel
    {
        private static readonly ApiServices apiServices = new ApiServices();

        public Horse Horse { get; set; }

        public List<JournalEntry> Entries
        {
            get
            {
                return apiServices.GetAllJournalEntries(Horse.Id).Result;
            }
        }

        public JournalEntriesViewModel(Horse horse)
        {
            Horse = horse;
        }
    }
}
