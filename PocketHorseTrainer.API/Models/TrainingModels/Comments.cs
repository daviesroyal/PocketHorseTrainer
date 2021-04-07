using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketHorseTrainer.API.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Comments()
        {

        }
    }
}
