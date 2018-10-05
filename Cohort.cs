using System.Collections.Generic;


namespace NSS
{
    public class Cohort {
        public int Id { get; set; }


        public string CohortName { get; set; }

    public List<Student> StuCollection = new List<Student>();
        public List<Instructor> Instructors = new List<Instructor>();



    }
}