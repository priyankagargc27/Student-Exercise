
using System.Collections.Generic;

namespace NSS
{
    public class Student {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set;}

        public string Email { get; set; }

        public string SlackHandle { get; set; }

        public string Cohort { get ; set; }
    public List<Exercise> ExcerciseAssigned = new List<Exercise>();




    }
}