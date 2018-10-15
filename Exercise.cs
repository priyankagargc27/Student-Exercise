namespace NSS
{

    public class Exercise {
        
        
         public Exercise(string ExerciseName, string ExerciseLanguage) {
            Name = ExerciseName;
            Language = ExerciseLanguage;
        } 
        public string Name { get; set; }

        public string Language { get ; set; }

    }
}