using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }


            Students.Sort((x, y) => x.AverageGrade.CompareTo(y.AverageGrade));

            int numberOfStudentsPerGrade = Students.Count / 5;

            if (averageGrade >= Students[Students.Count - numberOfStudentsPerGrade].AverageGrade)
            {
                return 'A';
            } else if (averageGrade >= Students[Students.Count - numberOfStudentsPerGrade * 2].AverageGrade)
            {
                return 'B';
            } else if (averageGrade >= Students[Students.Count - numberOfStudentsPerGrade * 3].AverageGrade)
            {
                return 'C';
            } else if (averageGrade >= Students[Students.Count - numberOfStudentsPerGrade * 4].AverageGrade)
            {
                return 'D';
            }

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly"
                    + " calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            int numberOfGrades = 0;

            foreach (Student student in Students)
            {
                if (student.Grades.Count > 0)
                {
                    numberOfGrades += 1;
                }
            }

            if (numberOfGrades < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly"
                    + " calculate a student's overall grade.");
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
