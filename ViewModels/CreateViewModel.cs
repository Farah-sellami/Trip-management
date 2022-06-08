using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrip.ViewModels
{
    public class CreateViewModel
    {
        public string lieu { get; set; }
        public string description { get; set; }
        public int prix { get; set; }
        public IFormFile image { get; set; }
    }
}
