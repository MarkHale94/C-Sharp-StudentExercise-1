using System;
using System.Collections.Generic;

namespace StudentExercises
{
    public class Exercise
    {
        public string ExerciseName { get; set; }
        public string ExerciseLanguage { get; set; }

        // constructor
        public Exercise (string name, string language)
        {
            ExerciseName = name;
            ExerciseLanguage = language;
        }
        //Dapper needs a parameterless constructor for the query. This is the default constructor being reinstantiated for dapper to use since it passes no parameters
        public Exercise(){}
    }
}