
using System;
using System.Collections.Generic;

namespace NSS
{
    public class Student {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set;}
         public string FullName
        {
            get
            {
                return string.Format($"{FirstName} {LastName}");
            }
        }
    

        public string SlackHandle { get; set; }

        public Cohort Cohort {get; set;}
    public List<Exercise> ExcerciseAssigned = new List<Exercise>();

        internal object ToList()
        {
            throw new NotImplementedException();
        }
    }
}
