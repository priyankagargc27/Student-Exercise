using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Collections;
using Dapper;

namespace NSS.Data
{
    public class DatabaseInterface
    {
        public static SqliteConnection Connection
        {
            get
            {
                string connectionString = $"Data Source=./Studentexercise.db";
                return new SqliteConnection(connectionString);
            }
        }


        public static void CheckCohortTable()
        {
            SqliteConnection db = DatabaseInterface.Connection;

            try
            {
                List<Cohort> cohort = db.Query<Cohort>
                    ("SELECT Id FROM Cohort").ToList();
                    Console.WriteLine("cohort table select");

            }
            catch (System.Exception ex)
            {
                if (ex.Message.Contains("no such table"))
                {
                    db.Execute(@"CREATE TABLE `Cohort` (
                        `Id` INTEGER PRIMARY KEY AUTOINCREMENT,
                        `CohortName` TEXT NOT NULL
                    )");

                    db.Execute(@"
                    INSERT INTO Cohort (CohortName) VALUES ('Day Cohort 26');
                    INSERT INTO Cohort (CohortName) VALUES ('Day Cohort 27');
                    INSERT INTO Cohort (CohortName) VALUES ('Day Cohort 28');
                    INSERT INTO Cohort (CohortName) VALUES ('Day Cohort 29');

                    ");
                }
            }
        }

        public static void CheckInstructorTable()
        {
            SqliteConnection db = DatabaseInterface.Connection;

            try
            {
                List<Instructor> instructor = db.Query<Instructor>
                    ("SELECT Id FROM Instructor").ToList();
                    Console.WriteLine("Instructor table select");

            }
            catch (System.Exception ex)
            {
                if (ex.Message.Contains("no such table"))
                {
                    db.Execute($@"CREATE TABLE `Instructor` (
                        `Id`    INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        `FirstName`    TEXT NOT NULL,
                        `LastName`    TEXT NOT NULL,
                        `SlackHandle`    TEXT NOT NULL,
                        `CohortId` INTEGER NOT NULL,
                        FOREIGN KEY(`CohortId`) REFERENCES `Cohort`(`CohortId`)
                    )");

                   db.Execute($@"INSERT INTO Instructor
                        SELECT null,
                              'Steve',
                              'Brownlee',
                              '@coach',
                              c.Id
                        FROM Cohort c WHERE c.CohortName = 'Day Cohort 26';
                        INSERT INTO Instructor
                        SELECT null,
                              'Brenda',
                              'Lomg',
                              '@brenda',
                              c.Id
                        FROM Cohort c WHERE c.CohortName = 'Day Cohort 29';
                        INSERT INTO Instructor
                        SELECT null,
                              'Joe',
                              'Shepperd',
                              '@joe',
                              c.Id
                        FROM Cohort c WHERE c.CohortName = 'Day Cohort 28';
                        INSERT INTO Instructor
                        SELECT null,
                              'Andy',
                              'Collin',
                              '@andy',
                              c.Id
                        FROM Cohort c WHERE c.CohortName = 'Day Cohort 27';
                        INSERT INTO Instructor
                        SELECT null,
                              'Jessi',
                              'David',
                              '@jessi',
                              c.Id
                        FROM Cohort c WHERE c.CohortName = 'Day Cohort 29';
                    ");

                }
            }
        }
         public static void CheckExerciseTable()
        {
            SqliteConnection db = DatabaseInterface.Connection;

            try
            {
                List<Exercise> exercise = db.Query<Exercise>
                    ("SELECT Id FROM Exercise").ToList();
                    Console.WriteLine("exercise table select");

            }
            catch (System.Exception ex)
            {
                if (ex.Message.Contains("no such table"))
                {
                    db.Execute(@"CREATE TABLE `Exercise` (
                        `Id` INTEGER PRIMARY KEY AUTOINCREMENT,
                        `ExerciseName` TEXT NOT NULL,
                        `Language` TEXT NOT NULL
                    )");

                    db.Execute(@"
                    INSERT INTO Exercise (ExerciseName,Language) VALUES ('Yellow Brick','HTML');
                    INSERT INTO Exercise (ExerciseName,Language) VALUES ('Daily Journal','JS');
                    INSERT INTO Exercise (ExerciseName,Language) VALUES ('Kennel Company','REACT');
                    INSERT INTO Exercise (ExerciseName,Language) VALUES ('Student Exercise','C#');

                    ");
                }
            }
        }
         public static void CheckStudentTable()
        {
            SqliteConnection db = DatabaseInterface.Connection;

            try
            {
                List<Student> student = db.Query<Student>
                    ("SELECT Id FROM Student").ToList();
                Console.WriteLine("Student table select");

            }
            catch (System.Exception ex)
            {
                if (ex.Message.Contains("no such table"))
                {
                    db.Execute($@"CREATE TABLE `Student` (
                        `Id`    INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        `FirstName`    TEXT NOT NULL,
                        `LastName`    TEXT NOT NULL,
                        `SlackHandle`    TEXT NOT NULL,
                            `CohortId` INTEGER NOT NULL,

                        FOREIGN KEY(`CohortId`) REFERENCES `Cohort`(`CohortId`)
                    )");

                   db.Execute($@"INSERT INTO Student
                        SELECT null,
                              'Priyanka',
                              'Garg',
                              '@priya',
                              c.Id
                        FROM Cohort c WHERE c.CohortName = 'Day Cohort 27';
                        INSERT INTO Student
                        SELECT null,
                              'Dolly',
                              'Singla',
                              '@dolly',
                              c.Id
                        FROM Cohort c WHERE c.CohortName = 'Day Cohort 29';
                        INSERT INTO Student
                        SELECT null,
                              'Leah',
                              'Gevin',
                              '@leah',
                              c.Id
                        FROM Cohort c WHERE c.CohortName = 'Day Cohort 26';
                        INSERT INTO Student
                        SELECT null,
                              'Kelly',
                              'Cook',
                              '@kelly',
                              c.Id
                        FROM Cohort c WHERE c.CohortName = 'Day Cohort 27';
                        INSERT INTO Student
                        SELECT null,
                              'Madi',
                              'Pepper',
                              '@madi',
                              c.Id
                        FROM Cohort c WHERE c.CohortName = 'Day Cohort 27';
                    ");

                }
            }
        }
        public static void CheckStudentExerciseTable()
        {
            SqliteConnection db = DatabaseInterface.Connection;

            try
            {
                List<StudentExercise> studentExercise = db.Query<StudentExercise>
                    ("SELECT Id FROM StudentExercise").ToList();
            }
            catch (System.Exception ex)
            {
                if (ex.Message.Contains("no such table"))
                {
                    db.Execute(@"CREATE TABLE StudentExercise (
                        `Id`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                        `StudentId`	integer NOT NULL,
                        `ExerciseId`	integer NOT NULL,
                        `InstructorId`	integer NOT NULL,
                        FOREIGN KEY(`StudentId`) REFERENCES `Student`(`StudentId`),
                        FOREIGN KEY(`ExerciseId`) REFERENCES `Exercise`(`ExerciseId`),
                        FOREIGN KEY(`InstructorId`) REFERENCES `Instructor`(`InstructorId`)
                    )");

                    db.Execute(@"INSERT INTO StudentExercise
                        SELECT null,
                              s.Id,
                              e.Id,
                              i.Id
                        FROM Student s, Exercise e, Instructor i WHERE 
                        s.FirstName = 'Priyanka'
                        AND e.ExerciseName = 'Daily Journal'
                        AND i.FirstName = 'Brenda'
                    ");

                    db.Execute(@"INSERT INTO StudentExercise
                        SELECT null,
                              s.Id,
                              e.Id,
                              i.Id
                        FROM Student s, Exercise e, Instructor i WHERE
                         s.FirstName = 'Dolly'
                        AND e.ExerciseName = 'Yellow Brick'
                        AND i.FirstName = 'Jessi'
                    ");

                    db.Execute(@"INSERT INTO StudentExercise
                        SELECT null,
                              s.Id,
                              e.Id,
                              i.Id
                        FROM Student s, Exercise e, Instructor i WHERE 
                        s.FirstName = 'Kelly'
                        AND e.ExerciseName = 'Kennel Company'
                        AND i.FirstName = 'Steve'
                    ");
                }
            }
        }

                
            }
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        