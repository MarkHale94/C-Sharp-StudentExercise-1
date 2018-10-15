using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentExercises {
    class Program {
        static void Main (string[] args) {
            // Create 4, or more, exercises.
            Exercise loops = new Exercise ("loops", "Javascript");
            Exercise objects = new Exercise ("objects", "Javascript");
            Exercise dictionaries = new Exercise ("dictionaries", "C#");
            Exercise lists = new Exercise ("lists", "C#");
            // Create 3, or more, cohorts.
            Cohort twentyFive = new Cohort ("Day 25");
            Cohort twentySix = new Cohort ("Day 26");
            Cohort twentySeven = new Cohort ("Day 27");
            // Create 4, or more, students and assign them to one of the cohorts.
            Student Sally = new Student ("Sally", "Boucher", "keep it clean", twentyFive);
            Student Bobby = new Student ("Bobby", "Boucher", "Drink some water", twentySix);
            Student Chandler = new Student ("Chandler", "Bing", "could I be more ...", twentySix);
            Student Mark = new Student ("Mark", "Hale", "This is hard", twentySeven);
            Student Klaus = new Student ("Klaus", "Hardt", "Hi, guys", twentySeven);
            Student Taylor = new Student ("Taylor", "GUlley", "Mark is a dummy", twentySeven);
            // Create 3, or more, instructors and assign them to one of the cohorts.
            Instructor Joe = new Instructor ("Joe", "Shepherd", "joes", twentyFive);
            Instructor Jisie = new Instructor ("Jisie", "David", "jisie", twentySix);
            Instructor Steve = new Instructor ("Steve", "Brownlee", "coach", twentySeven);
            // Have each instructor assign 2 exercises to each of the students.
            Joe.AssignExercise (loops, Mark);
            Joe.AssignExercise (objects, Mark);
            Joe.AssignExercise (loops, Sally);
            Joe.AssignExercise (objects, Sally);
            Jisie.AssignExercise (dictionaries, Bobby);
            Jisie.AssignExercise (lists, Bobby);
            Jisie.AssignExercise (lists, Chandler);
            Jisie.AssignExercise (dictionaries, Chandler);
            Steve.AssignExercise (lists, Klaus);
            Steve.AssignExercise (dictionaries, Klaus);
            Steve.AssignExercise (lists, Taylor);
            Steve.AssignExercise (dictionaries, Taylor);
            // Create a list of students.
            List<Student> students = new List<Student> () {
                Mark,
                Sally,
                Bobby,
                Chandler,
                Klaus,
                Taylor
            };

            // Create a list of exercises.
            List<Exercise> exercises = new List<Exercise> () {
                loops,
                objects,
                dictionaries,
                lists
            };

            //Create a list of Cohorts
            List<Cohort> cohorts = new List<Cohort> () {
                twentyFive,
                twentySix,
                twentySeven
            };

            //Create a list of Instructors
            List<Instructor> instructors = new List<Instructor> () {
                Joe,
                Jisie,
                Steve
            };

            // Generate a report that displays which students are working on which exercises.
            foreach (Exercise ex in exercises) {
                List<string> assignedStudents = new List<string> ();
                foreach (Student stu in students) {
                    if (stu.Exercises.Contains (ex)) {
                        assignedStudents.Add (stu.FirstName);
                    }
                }
                Console.WriteLine ($"{ex.Name} is being worked on by {String.Join(", ", assignedStudents)}");
            }
            // List exercises for the JavaScript language by using the Where() LINQ method.
            IEnumerable<Exercise> javascriptExercises = from exercise in exercises
            where exercise.Language == "Javascript"
            select exercise;
            foreach (Exercise exercise in javascriptExercises) {
                Console.WriteLine ($"Javascript Exercise: {exercise.Name}");
            }
            //List students in a particular cohort by using the Where() LINQ method.
            IEnumerable<Student> studentsInCohort25 = from student in students
            where student.Cohort == twentyFive
            select student;
            foreach (Student student in studentsInCohort25) {
                Console.WriteLine ($"Student in Cohort 25: {student.FirstName} {student.LastName}");
            }

            IEnumerable<Student> studentsInCohort26 = from student in students
            where student.Cohort == twentySix
            select student;
            foreach (Student student in studentsInCohort26) {
                Console.WriteLine ($"Student in Cohort 26: {student.FirstName} {student.LastName}");
            }

            IEnumerable<Student> studentsInCohort27 = from student in students
            where student.Cohort == twentySeven
            select student;
            foreach (Student student in studentsInCohort27) {
                Console.WriteLine ($"Student in Cohort 27: {student.FirstName} {student.LastName}");
            }

            // List instructors in a particular cohort by using the Where() LINQ method.
            IEnumerable<Instructor> instructorsInCohort25 = from instructor in instructors
            where instructor.Cohort == twentyFive
            select instructor;
            foreach (Instructor Instructor in instructorsInCohort25) {
                Console.WriteLine ($"Instructor for Cohort 25: {Instructor.FirstName} {Instructor.LastName}");
            }

            IEnumerable<Instructor> instructorsInCohort26 = from instructor in instructors
            where instructor.Cohort == twentySix
            select instructor;
            foreach (Instructor Instructor in instructorsInCohort26) {
                Console.WriteLine ($"Instructor for Cohort 26: {Instructor.FirstName} {Instructor.LastName}");
            }

            IEnumerable<Instructor> instructorsInCohort27 = from instructor in instructors
            where instructor.Cohort == twentySeven
            select instructor;
            foreach (Instructor Instructor in instructorsInCohort27) {
                Console.WriteLine ($"Instructor for Cohort 27: {Instructor.FirstName} {Instructor.LastName}");
            }
        }
    }
}