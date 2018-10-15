using System;

namespace NSS
{
    public class Instructor {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get ; set; }
        
        
        
        //Constructor for geeting full name
        public string FullName
        {
            get
            {
                return string.Format($"{FirstName} {LastName}");
            }
        }
    
        public string SlackHandle { get; set; }

        public Cohort Cohort {get; set;}

// public Instructor (string firstName, string lastname, string slackHandle, Cohort cohort)
// {
//     FirstName = firstName ;
//     LastName = lastname ;
//     SlackHandle = slackHandle ;
//     Cohort = Cohort ;

// }
        // assign an exercise to student
        public void AssignExercise(Exercise exercise, Student student)
        {
            student.ExcerciseAssigned.Add(exercise);
 
        }




    }
}