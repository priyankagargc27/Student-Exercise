using System;
using System.Collections.Generic;

namespace NSS
{
    class Program
    {
        static void Main(string[] args)
        {

            /*Create 4, or more, exercises.
             */

            Exercise Ex1 = new Exercise("Yellow Brick", "Html");
            Exercise Ex2 = new Exercise("Daily Journal", "Browserfy");
            Exercise Ex3 = new Exercise("React Components", "React");
            Exercise Ex4 = new Exercise("Library", "C#");


            // Create 3, or more, cohorts.
            Cohort C26 = new Cohort();
            Cohort C27 = new Cohort();
            Cohort C28 = new Cohort();


// Create 4, or more, students and assign them to one of the cohorts.

            Student Priyanka = new Student()
            {
                FirstName = "Priyanka",
                LastName = "Garg",
                SlackHandle = "priyanka123",
                Cohort = "C27"
        };

        Student Dolly = new Student()
        {
            FirstName = "Dolly",
            LastName = "Singla",
            SlackHandle = "dollyabc",
            Cohort = "C28"
        };

        Student Aryan = new Student()
        {
            FirstName = "Aryan",
            LastName = "Goyal",
            SlackHandle = "aryanxyz",
            Cohort = "C26"
        };
     C27.StuCollection.Add(Priyanka);
     C28.StuCollection.Add(Dolly);
    C26.StuCollection.Add(Aryan);


// Create 3, or more, instructors and assign them to one of the cohorts.

        Instructor Steve = new Instructor()
        {
            FirstName = "Steve",
            LastName = "Brownlee",
            SlackHandle = "steve",
            Cohort = 27
            };
            Instructor Jessi = new Instructor()
        {
            FirstName = "Jessi",
            LastName = "Coliin",
            SlackHandle = "andy",
            Cohort = 28
            };
            Instructor Meg = new Instructor()
        {
            FirstName = "Meg",
            LastName = "Ducharme",
            SlackHandle = "meg",
            Cohort = 26
            };

    C27.InstCollection.Add(Steve);
     C28.InstCollection.Add(Jessi);
    C26.InstCollection.Add(Meg);
           

           // Have each instructor assign 2 exercises to each of the students.
            Steve.AssignExercise ( Ex1,Priyanka);
            Steve.AssignExercise ( Ex2,Priyanka);

             Jessi.AssignExercise ( Ex3,Dolly);
            Jessi.AssignExercise ( Ex4,Dolly);

             Meg.AssignExercise ( Ex1,Aryan);
            Meg.AssignExercise ( Ex2,Aryan);


    //    Create a list of students. Add all of the student instances to it.
    List<Student> students = new List<Student>();
    students.Add(Priyanka);
    students.Add(Dolly);
    students.Add(Aryan);

    // Create a list of exercises. Add all of the exercise instances to it.
List<Exercise> exercises = new List<Exercise>();

exercises.Add(Ex1);
exercises.Add(Ex2);
exercises.Add(Ex3);
exercises.Add(Ex4);

    }
}
}
