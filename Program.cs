using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using NSS.Data;
using Dapper;
using System.Text;


namespace NSS
{
    class Program
    {

         static void Main(string[] args)
        {
            SqliteConnection db = DatabaseInterface.Connection;
            DatabaseInterface.CheckCohortTable();
            DatabaseInterface.CheckInstructorTable();
            DatabaseInterface.CheckStudentTable();
             DatabaseInterface.CheckExerciseTable();
            DatabaseInterface.CheckStudentExerciseTable();
 /*
                1. Query database
                2. Convert result to list
                3. Use ForEach to iterate the collection
            */

            //List All the database
            List<Cohort> cohort = db.
                Query<Cohort>(@"SELECT * FROM Cohort")
                 .ToList();
            cohort.ForEach(c => Console.WriteLine($"{c.CohortName}"));

            List<Exercise> exercises = db.
                Query<Exercise>(@"SELECT * FROM Exercise")
                 .ToList();
            exercises.ForEach(ex => Console.WriteLine($"{ex.ExerciseName} {ex.Language}"));
            
            List<Student> student = db.
                Query<Student>(@"SELECT * FROM Student")
                 .ToList();
                 Console.WriteLine($"{student.Count}");
            student.ForEach(st => Console.WriteLine($"{st.FirstName} {st.LastName}{st.SlackHandle}!!"));
             
             List<Instructor> instructor = db.
                Query<Instructor>(@"SELECT * FROM Instructor")
                 .ToList();
            instructor.ForEach(ins => Console.WriteLine($"{ins.FirstName} {ins.LastName}{ins.SlackHandle}!!"));

            
             //Fnd all the exercises in the database where the language is JavaScript.
List<Exercise> JSexercise = db.
                Query<Exercise>(@"SELECT * FROM Exercise where language = 'JS'")
                 .ToList();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("All JAvascript exercises in excercise table");
                 Console.WriteLine("--------------------------------------------");
            JSexercise.ForEach(ex => Console.WriteLine($"{ex.ExerciseName} {ex.Language}"));

            
            
            //Find all instructors in the database. Include each instructor's cohort.



        }
    }
}












































        //Student Exercise 1,2 and 3 are commented out
//         static void Main(string[] args)
//         {

//             /*Create 4, or more, exercises.
//              */

//             Exercise YelloBrick = new Exercise("Yellow-Brick", "Html");
//             Exercise DailyJournal = new Exercise("Daily Journal", "JavaScript");
//             Exercise ReactComponent = new Exercise("React Components", "React");
//             Exercise Library = new Exercise("Library", "C#");


//             // Create 3, or more, cohorts.
//             Cohort C26 = new Cohort() { CohortName = "Cohort 26" };
//             Cohort C27 = new Cohort(){ CohortName = "Cohort 27" };
//             Cohort C28 = new Cohort(){ CohortName = "Cohort 28" };


// // Create 4, or more, students and assign them to one of the cohorts.

//             Student Priyanka = new Student()
//             {
//                 FirstName = "Priyanka",
//                 LastName = "Garg",
//                 SlackHandle = "priyanka123",
//                 Cohort = C27
//         };

//         Student Dolly = new Student()
//         {
//             FirstName = "Dolly",
//             LastName = "Singla",
//             SlackHandle = "dollyabc",
//             Cohort = C28
//         };

//         Student Aryan = new Student()
//         {
//             FirstName = "Aryan",
//             LastName = "Goyal",
//             SlackHandle = "aryanxyz",
//             Cohort = C26
//         };
//          Student Kelly = new Student()
//         {
//             FirstName = "Kelly",
//             LastName = "Cook",
//             SlackHandle = "kelly",
//             Cohort = C27
//         };
//      C27.StuCollection.Add(Priyanka);
//      C28.StuCollection.Add(Dolly);
//     C26.StuCollection.Add(Aryan);
//         C27.StuCollection.Add(Kelly);



// // Create 3, or more, instructors and assign them to one of the cohorts.

//         Instructor Steve = new Instructor()
//         {
//             FirstName = "Steve",
//             LastName = "Brownlee",
//             SlackHandle = "steve",
//             Cohort = C27
//             };
//             Instructor Jessi = new Instructor()
//         {
//             FirstName = "Jessi",
//             LastName = "Coliin",
//             SlackHandle = "andy",
//             Cohort = C28
//             };
//             Instructor Meg = new Instructor()
//         {
//             FirstName = "Meg",
//             LastName = "Ducharme",
//             SlackHandle = "meg",
//             Cohort = C26
//             };
//              Instructor Brenda = new Instructor()
//         {
//             FirstName = "Brenda",
//             LastName = "Long",
//             SlackHandle = "brenda",
//             Cohort = C27
//             };

//     C27.InstCollection.Add(Steve);
//      C28.InstCollection.Add(Jessi);
//     C26.InstCollection.Add(Meg);
           

//            // Have each instructor assign 2 exercises to each of the students.
//             Steve.AssignExercise ( YelloBrick,Priyanka);
//             Steve.AssignExercise ( DailyJournal,Priyanka);

//              Jessi.AssignExercise (ReactComponent ,Dolly);
//             Jessi.AssignExercise ( Library,Dolly);

//              Meg.AssignExercise ( YelloBrick,Aryan);
//             Meg.AssignExercise ( DailyJournal,Aryan);
//             Jessi.AssignExercise(ReactComponent,Priyanka);
//             Jessi.AssignExercise(Library,Priyanka);


//     //    Create a list of students. Add all of the student instances to it.
//     // List<Student> students = new List<Student>();
//     // students.Add(Priyanka);
//     // students.Add(Dolly);
//     // students.Add(Aryan);

//     // Create a list of exercises. Add all of the exercise instances to it.
// // List<Exercise> exercises = new List<Exercise>();

// // exercises.Add(YelloBrick);
// // exercises.Add(DailyJournal);
// // exercises.Add(ReactComponent);
// // exercises.Add(Library);
// // Create a list of students. Add all of the student instances to it.
//             List<Student> students = new List<Student> () {
//                Priyanka,
//                Dolly,
//                Aryan,
//                Kelly
//             };

//             // Create a list of exercises.Add all of the exercise instances to it.
//             List<Exercise> exercises = new List<Exercise> () {
//                 YelloBrick,
//                DailyJournal,                
//                ReactComponent,
//                 Library
//             };

//             // Create a list of instructors. Add all of the instructor instances to it.
//             List<Instructor> instructors = new List<Instructor> () {
//                 Steve,
//                 Meg,
//                 Jessi,
//                 Brenda
//             };

//             // Create a list of cohorts. Add all of the cohort instances to it.
//             List<Cohort> cohorts = new List<Cohort> () {
//                 C26,
//                 C27,
//                 C28
//             };


//             //  foreach (Student student in students) {
             
//             //  Console.WriteLine($"{student.FullName} working on {student.ExcerciseAssigned}");
//             //  }

//              foreach(Student student in students)
//             {
//                 foreach(Exercise exercise in exercises)
//                 {
//                     /*
//                     */
//                     if(student.ExcerciseAssigned.Contains(exercise))
//                     {
//                         Console.WriteLine($"{student.FullName} is currently working on {exercise.Name}");
//                     }

//                 }
//             }
   
   
   
//     // List exercises for the JavaScript language by using the Where() LINQ method.
//             List<Exercise> JavaScriptExercises =
//                 (from js in exercises where js.Language == "JavaScript"
//                     select js).ToList ();

//             Console.WriteLine ("----- JS Exercises -----");
//             foreach (Exercise ex in JavaScriptExercises) {
//                 Console.WriteLine (ex.Name);
//             }
   
//    //List students in a particular cohort by using the Where() LINQ method.
//         List<Student> CohortStudent = 
//         (from student in students where student.Cohort.CohortName == "Day Cohort 27"
//         select student).ToList();
//          Console.WriteLine ("----- Cohort 27 Students -----");
//             foreach (Student st in CohortStudent) {
//                 Console.WriteLine (st.FirstName);
//             }
   
//    //List instructors in a particular cohort by using the Where() LINQ method.


//     List<Instructor> CohortInstructor = 
//         (from instructor in instructors where instructor.Cohort.CohortName == "Cohort 27"
//         select instructor).ToList();
//          Console.WriteLine ("----- Cohort 27 Instructors -----");
//             foreach (Instructor inst in CohortInstructor) {
//             Console.WriteLine (inst.LastName);

//                 Console.WriteLine (inst.FirstName);
//             }
   
   
//    //Sort the students by their last name.

//     List<Student> StudentsLastName =
//                 (from student in students
//                 orderby student.LastName
//                 select student).ToList();
//     Console.WriteLine("---------------------------------------------");

//             Console.WriteLine ("----- Students By their Last Name -----");
            
//             foreach (Student stu in StudentsLastName) {
//                 Console.WriteLine ($"{stu.FirstName} {stu.LastName}");
//                     Console.WriteLine("---------------------------------------------");

//             }

// //Display any students that aren't working on any exercises (Make sure one of your student instances don't have any exercises. 
// //Create a new student if you need to.)

// List<Student> stunotworking = 
// (from st in students
// where st.ExcerciseAssigned.Count==0
// select st).ToList();

// foreach(Student st in stunotworking){
//     Console.WriteLine("---------------------------------------------");
//     Console.WriteLine($"{st.FirstName} is not working on any exercise");
//         Console.WriteLine("---------------------------------------------");
// }


// //Which student is working on the most exercises? Make sure one of your students has more exercises than the others.
// List<Student>stumostexercise=
// (from stu in students 
// where stu.ExcerciseAssigned.Count > 2
// select stu).ToList();
// foreach(Student stu in stumostexercise){
//     Console.WriteLine("---------------------------------------------");
//     Console.WriteLine($"{stu.FirstName} worked on most exercises");
//         Console.WriteLine("---------------------------------------------");

// }

   
//     // How many students in each cohort?
//             // Console.WriteLine ("----Student number in each cohort-");
//             // foreach (Cohort cohort in cohorts) {
//             //     Console.WriteLine ($"{cohort.CohortName} has {cohort.StuCollection.Count} students");
//             // }
//    var numberofstudentsineachcohort = students.GroupBy(c => c.Cohort.CohortName);
//    foreach(var studentgroup in numberofstudentsineachcohort)
//    {
//        Console.WriteLine($"{studentgroup.Key} has {studentgroup.Count()} students");
//    }
   
//     }

