using System;
using System.Collections.Generic;
using System.Text;

namespace SPY.DB.Model
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
