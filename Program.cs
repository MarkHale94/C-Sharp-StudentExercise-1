using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Data.Sqlite;

namespace StudentExercises {
    class Program {
        static void Main (string[] args) {

            SqliteConnection db = DatabaseInterface.Connection;

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
            Student Taylor = new Student ("Taylor", "Gulley", "Mark is a dummy", twentySeven);
            // Create 3, or more, instructors and assign them to one of the cohorts.
            Instructor Joe = new Instructor ("Joe", "Shepherd", "joes", twentyFive);
            Instructor Jisie = new Instructor ("Jisie", "David", "jisie", twentySix);
            Instructor Steve = new Instructor ("Steve", "Brownlee", "coach", twentySeven);
            // Have each instructor assign 2 exercises to each of the students.
            Joe.AssignExercise (loops, Sally);
            Joe.AssignExercise (objects, Sally);
            Jisie.AssignExercise (dictionaries, Bobby);
            Jisie.AssignExercise (lists, Bobby);
            Jisie.AssignExercise (lists, Chandler);
            Jisie.AssignExercise (dictionaries, Chandler);
            Steve.AssignExercise (loops, Mark);
            Steve.AssignExercise (objects, Mark);
            Steve.AssignExercise (lists, Mark);
            Steve.AssignExercise (dictionaries, Mark);
            Steve.AssignExercise (lists, Klaus);
            Steve.AssignExercise (dictionaries, Klaus);
            // Steve.AssignExercise (lists, Taylor);
            // Steve.AssignExercise (dictionaries, Taylor);
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
            // foreach (Exercise ex in exercises) {
            //     List<string> assignedStudents = new List<string> ();
            //     foreach (Student stu in students) {
            //         if (stu.Exercises.Contains (ex)) {
            //             assignedStudents.Add (stu.FirstName);
            //         }
            //     }
            //     Console.WriteLine ($"{ex.Name} is being worked on by {String.Join(", ", assignedStudents)}");
            // }

            // List exercises for the JavaScript language by using the Where() LINQ method.
            IEnumerable<Exercise> javascriptExercises = from exercise in exercises
            where exercise.ExerciseLanguage == "Javascript"
            select exercise;

            // foreach (Exercise exercise in javascriptExercises) {
            //     Console.WriteLine ($"Javascript Exercise: {exercise.Name}");
            // }

            //List students in a particular cohort by using the Where() LINQ method.
            IEnumerable<Student> studentsInCohort25 = from student in students
            where student.Cohort == twentyFive
            select student;

            // foreach (Student student in studentsInCohort25) {
            //     Console.WriteLine ($"Student in Cohort 25: {student.FirstName} {student.LastName}");
            // }

            IEnumerable<Student> studentsInCohort26 = from student in students
            where student.Cohort == twentySix
            select student;

            // foreach (Student student in studentsInCohort26) {
            //     Console.WriteLine ($"Student in Cohort 26: {student.FirstName} {student.LastName}");
            // }

            IEnumerable<Student> studentsInCohort27 = from student in students
            where student.Cohort == twentySeven
            select student;

            // foreach (Student student in studentsInCohort27) {
            //     Console.WriteLine ($"Student in Cohort 27: {student.FirstName} {student.LastName}");
            // }

            // List instructors in a particular cohort by using the Where() LINQ method.
            IEnumerable<Instructor> instructorsInCohort25 = from instructor in instructors
            where instructor.Cohort == twentyFive
            select instructor;

            // foreach (Instructor Instructor in instructorsInCohort25) {
            //     Console.WriteLine ($"Instructor for Cohort 25: {Instructor.FirstName} {Instructor.LastName}");
            // }

            IEnumerable<Instructor> instructorsInCohort26 = from instructor in instructors
            where instructor.Cohort == twentySix
            select instructor;

            // foreach (Instructor Instructor in instructorsInCohort26) {
            //     Console.WriteLine ($"Instructor for Cohort 26: {Instructor.FirstName} {Instructor.LastName}");
            // }

            IEnumerable<Instructor> instructorsInCohort27 = from instructor in instructors
            where instructor.Cohort == twentySeven
            select instructor;

            // foreach (Instructor Instructor in instructorsInCohort27) {
            //     Console.WriteLine ($"Instructor for Cohort 27: {Instructor.FirstName} {Instructor.LastName}");
            // }

            //Sort the students by their last name.

            IEnumerable<Student> studentLastNameSort = from student in students
            orderby student.LastName
            select student;

            // foreach (Student student in studentLastNameSort) {
            //     Console.WriteLine ($"{student.FirstName} {student.LastName}");
            // }

            // Display any students that aren't working on any exercises (Make sure one of your student instances don't have any exercises. Create a new student if you need to.)
            IEnumerable<Student> studentsWithNoExercises = from student in students
            where student.Exercises.Count == 0
            select student;

            // foreach(Student student in studentsWithNoExercises){
            //     Console.WriteLine($"{student.FirstName} {student.LastName}");
            // }

            //Which student is working on the most exercises? Make sure one of your students has more exercises than the others.
            var studentWithMostExercises = (from s in students
                    // select is like .map and generates a new thing and put it into the final collection
                    select new {
                        FirstName = s.FirstName,
                            Exercises = s.Exercises.Count ()
                    })
                // put in order of descending number of exercises
                .OrderByDescending (s => s.Exercises)
                // grab just the first one -> first or default if the list is empty
                .Take (1).ToList () [0];
            // Console.WriteLine($"Student working on most exercises: {studentWithMostExercises.FirstName} {studentWithMostExercises.Exercises}");

            // 7. How many students in each cohort?
            var numberOfStudentsInEachCohort = students.GroupBy (c => c.Cohort.Name);
            // looks at every group of students
            foreach (var studentGroup in numberOfStudentsInEachCohort) {
                // key is the thing you grouped by
                // Console.WriteLine($"{studentGroup.Key} has {studentGroup.Count()} students");
            }

            // SQL/QUERY WAY
            var totalStudents = from student in students
            group student by student.Cohort into sorted
            select new {
                Cohort = sorted.Key,
                Students = sorted.ToList ()
            };
            // foreach (var total in totalStudents) {
            //     Console.WriteLine ($"Cohort {total.Cohort.Name} has {total.Students.Count()} students");
            // }

            // Generate a report that displays which students are working on which exercises.
            foreach (Exercise ex in exercises) {
                List<string> assignedStudents = new List<string> ();

                foreach (Student stu in students) {
                    if (stu.Exercises.Contains (ex)) {
                        assignedStudents.Add (stu.FirstName);
                    }
                }
                // Console.WriteLine ($"{ex.Name} is being worked on by {String.Join(", ", assignedStudents)}");
            }

            //Query the database for all the Exercises.
            List<Exercise> AllExercises = db.Query<Exercise> (@"SELECT * FROM EXERCISES").ToList ();
            // AllExercises.ForEach(exercise => Console.WriteLine($"{exercise.ExerciseName}"));

            // Fnd all the exercises in the database where the language is JavaScript.
            // List<Exercise> AllJavaScriptExercises = db.Query<Exercise> (@"SELECT * FROM EXERCISES WHERE ExerciseLanguage=='Javascript'").ToList ();
            // AllJavaScriptExercises.ForEach (exercise => Console.WriteLine ($"{exercise.ExerciseName}"));

            //Insert a new exercise into the database.
            // db.Execute (@"INSERT INTO EXERCISES (ExerciseName, ExerciseLanguage) VALUES ('Planets', 'Javascript');");
            // List<Exercise> AllJavaScriptExercises = db.Query<Exercise> (@"SELECT * FROM EXERCISES WHERE ExerciseLanguage=='Javascript'").ToList ();
            // AllJavaScriptExercises.ForEach (exercise => Console.WriteLine ($"{exercise.ExerciseName}"));

            // Find all instructors in the database.Include each instructor's cohort.



            //Insert a new instructor into the database.Assign the instructor to an existing cohort.

            // Assign an existing exercise to an existing student.

            // Challenge - Find all the students in the database.Include each student's cohort AND each student's list of exercises.
        }
    }
}