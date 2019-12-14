using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPY.DB.Model
{
    public class Desk
    {
        public int Id { get; set; }
        [MaxLength(512)]
        public string Name { get; set; }

        public Student Student { get; set; }
    }
}
