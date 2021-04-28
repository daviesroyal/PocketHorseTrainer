using PocketHorseTrainer.Models.Horses;
using PocketHorseTrainer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PocketHorseTrainer.Models
{
    public static class SupportData
    {
        private static readonly ApiServices apiServices = new ApiServices();

        public static IList<Barn> Barns { get; }
        public static IList<Breed> Breeds { get; }
        public static IList<CoatColor> Colors { get; }
        public static IList<FaceMarking> FaceMarkings { get; }
        public static IList<LegMarking> LegMarkings { get; }

        static SupportData()
        {
            Barns = apiServices.GetBarns().Result;
            Breeds = apiServices.GetBreeds().Result;
            Colors = apiServices.GetColors().Result;
            FaceMarkings = apiServices.GetFaceMarkings().Result;
            LegMarkings = apiServices.GetLegMarkings().Result;
        }
    }
}
