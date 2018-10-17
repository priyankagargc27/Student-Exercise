CREATE TABLE Cohort (
    CohortId	INTEGER NOT NULL PRIMARY KEY IDENTITY,
    CohortName	varchar(80) NOT NULL UNIQUE
);

CREATE TABLE Instructor (
    InstructorId	INTEGER NOT NULL PRIMARY KEY IDENTITY,
    FirstName	varchar(80) NOT NULL,
    LastName	varchar(80) NOT NULL,
    SlackHandle	varchar(80) NOT NULL,
    CohortId	INTEGER NOT NULL,
     FOREIGN KEY(CohortId) REFERENCES Cohort(CohortId)
);

CREATE TABLE Exercise (
ExerciseId	INTEGER NOT NULL PRIMARY KEY ,
    ExerciseName	VARCHAR(80) NOT NULL,
    Language VARCHAR(80) NOT NULL
);


CREATE TABLE Student (
    StudentId	integer NOT NULL PRIMARY KEY ,
    FirstName	varchar(80) NOT NULL,
    LastName	varchar(80) NOT NULL,
    SlackHandle	varchar(80) NOT NULL,
    CohortId	integer NOT NULL,
     FOREIGN KEY(CohortId) REFERENCES Cohort(CohortId)
);

CREATE TABLE StudentExercise (
    Id	        INTEGER NOT NULL PRIMARY KEY IDENTITY,
    ExerciseId	INTEGER NOT NULL,
    StudentId 	INTEGER NOT NULL,
    InstructorId 	INTEGER NOT NULL,
    FOREIGN KEY(ExerciseId) REFERENCES Exercise(ExerciseId),
     FOREIGN KEY(StudentId) REFERENCES Student(StudentId),
FOREIGN KEY(InstructorId) REFERENCES Instructor(INstructorId)
);

INSERT INTO Cohort (CohortName) VALUES ('Day Cohort 26');
INSERT INTO Cohort (CohortName) VALUES ('Day Cohort 27');
INSERT INTO Cohort (CohortName) VALUES ('Day Cohort 28');





Insert into Instructor 
(FirstName,LastName,SlackHandle,CohortId) values
 ("Jenna","Solis","@jenna",3);
 select * from Instructor;
 Insert into Instructor 
(FirstName,LastName,SlackHandle,CohortId) values
 ("Brenda","Long","@brenda",4);


insert into Exercise
(ExerciseName,Language) Values ("Yellow Brick","HTML");
insert into Exercise
(ExerciseName,Language) Values ("Daily Journal","JavaScript");
insert into Exercise
(ExerciseName,Language) Values ("React Component","React");
insert into Exercise
(ExerciseName,Language) Values ("Student Exercise","CSharp");



Insert into Student 
(FirstName,LastName,SlackHandle,CohortId,ExerciseId) values
 ("Priyanka","Garg","priya",2);
 Insert into Student 
(FirstName,LastName,SlackHandle,CohortId) values
 ("John","Nathan","@john",3);
 Insert into Student 
(FirstName,LastName,SlackHandle,CohortId) values
 ("Dolly","Singla","@dolly",4);






INSERT INTO StudentExercise
(StudentId,ExerciseId,InstructorId)
                        SELECT
                              s.StudentId,
                              e.ExerciseId,
                              i.InstructorId
                        FROM Student s, Exercise e, Instructor i 
						WHERE
						s.FirstName = 'Kelly'
                        AND e.ExerciseName = 'ReactComponent'
                        AND i.FirstName = 'Meg' ;