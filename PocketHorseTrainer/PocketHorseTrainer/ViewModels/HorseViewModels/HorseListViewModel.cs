using PocketHorseTrainer.Models;
using PocketHorseTrainer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketHorseTrainer.ViewModels.HorseViewModels
{
    public class HorseListViewModel : BaseViewModel
    {
        private readonly static ApiServices apiServices = new ApiServices();

        public List<Horse> Horses = apiServices.GetAllHorses().Result;

        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasMessage));
            }
        }

        public bool HasMessage => string.IsNullOrEmpty(Message);
    }
}
