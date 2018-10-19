using System;
using System.Collections.Generic;

namespace StudentExercises
{
    public class Cohort
    {
        public string CohortName { get; set; }
        public List<Student> Students { get; set; } 
        public List<Instructor> Instructors { get; set; } 

        // constructor
        public Cohort (string name) 
        {
            CohortName = name;
        }
        public Cohort () 
        {}


    }
}