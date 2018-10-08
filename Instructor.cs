using System;

namespace NSS
{
    public class Instructor {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get ; set; }
 public string FullName
        {
            get
            {
                return string.Format($"{FirstName} {LastName}");
            }
        }
    
        public string SlackHandle { get; set; }

        public int Cohort { get ; set; }

        public void AssignExercise(Exercise exercise, Student student)
        {
            student.ExcerciseAssigned.Add(exercise);
 
        }




    }
}