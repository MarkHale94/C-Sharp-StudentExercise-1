CREATE TABLE Student (
Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
FirstName TEXT NOT NULL,
LastName TEXT NOT NULL,
CohortId INTEGER NOT NULL,
SlackHandle TEXT NOT NULL,
FOREIGN KEY(CohortId) REFERENCES Cohort(Id)
);
CREATE TABLE INSTRUCTOR (
Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
FirstName TEXT NOT NULL,
LastName TEXT NOT NULL,
CohortId INTEGER NOT NULL,
SlackHandle TEXT NOT NULL,
FOREIGN KEY(CohortId) REFERENCES Cohort(Id)
);
CREATE TABLE Cohort (
Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
CohortName TEXT NOT NULL
);

CREATE TABLE EXERCISES (
Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
ExerciseName TEXT NOT NULL,
ExerciseLanguage TEXT NOT NULL
);

INSERT INTO Cohort 
(CohortName)VALUES ('Day Cohort 25');
INSERT INTO Cohort
(CohortName) VALUES ('Day Cohort 26');
INSERT INTO Cohort
(CohortName) VALUES ('Day Cohort 27');

SELECT * FROM Cohort;

INSERT INTO Student 
(FirstName, LastName, CohortId, SlackHandle) VALUES ('Sally', 'Boucher', 1, 'keep it clean');
INSERT INTO Student 
(FirstName, LastName, CohortId, SlackHandle) VALUES ('Bobby', 'Boucher', 1, 'Drink some water');
INSERT INTO Student 
(FirstName, LastName, CohortId, SlackHandle) VALUES ('Chandler', 'Bing', 2, 'could I be more ...');
INSERT INTO Student 
(FirstName, LastName, CohortId, SlackHandle) VALUES ('Mark', 'Hale', 3, 'This is hard');
INSERT INTO Student 
(FirstName, LastName, CohortId, SlackHandle) VALUES ('Klaus', 'Hardt', 3, 'Hi, guys');
INSERT INTO Student 
(FirstName, LastName, CohortId, SlackHandle) VALUES ('Taylor', 'Gulley', 3, 'Mark is a dummy');

SELECT * FROM Student;

INSERT INTO INSTRUCTOR 
(FirstName, LastName, CohortId, SlackHandle) VALUES ('Joe', 'Shepherd', 1, 'joes');
INSERT INTO INSTRUCTOR 
(FirstName, LastName, CohortId, SlackHandle) VALUES ('Jisie', 'David', 2, "jisie");
INSERT INTO INSTRUCTOR 
(FirstName, LastName, CohortId, SlackHandle) VALUES ('Steve', 'Brownlee', 3, 'coach');

SELECT * FROM Instructor;

INSERT INTO EXERCISES
(ExerciseName, ExerciseLanguage) VALUES ('loops', 'Javascript');
INSERT INTO EXERCISES
(ExerciseName, ExerciseLanguage) VALUES ('objects', 'Javascript');
INSERT INTO EXERCISES
(ExerciseName, ExerciseLanguage) VALUES ('dictionaries', 'C#');
INSERT INTO EXERCISES
(ExerciseName, ExerciseLanguage) VALUES ('lists', 'C#');

SELECT * FROM Exercises;



