using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPY.DB.Model
{
    public class LatestNews
    {
        [Key]
        public int Id { get; set; }
        public string NewsName { get; set; }
        public string NewsUrl { get; set; }
        public bool IsOpen { get; set; }
    }
}
