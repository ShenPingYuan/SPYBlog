using System.ComponentModel.DataAnnotations;

namespace SPY.DB.Model
{
    public class Student
    {
        public int Id { get; set; }
        [MaxLength(512)]
        public string Name { get; set; }

        public int DeskID { get; set; }

        public Desk Desk { get; set; }
    }
}