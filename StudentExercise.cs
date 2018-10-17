using System.Collections.Generic;

namespace NSS
{
    public class StudentExercise
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Exercise Exercise { get; set; }
        public Instructor Instructor { get; set; }
    }
}