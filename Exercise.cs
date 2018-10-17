namespace NSS
{

    public class Exercise {
        
        
         public Exercise(string Name, string ExerciseLanguage) {
             ExerciseName = Name ;
            Language = ExerciseLanguage;
        } 
        public Exercise()
        {
        
        }
        public string ExerciseName { get; set; }

        public string Language { get ; set; }

    }
}