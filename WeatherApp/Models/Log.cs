using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }

        public string UserIPAddress { get; set; }

        public DateTime UserRequestTime { get; set; }
    }
}
