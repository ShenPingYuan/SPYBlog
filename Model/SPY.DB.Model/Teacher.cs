namespace SPY.DB.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int SchoolID { get; set; }
        public School School { get; set; }
    }
}