﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    //TODO: restrict permissions so admins-only can edit
    public class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
