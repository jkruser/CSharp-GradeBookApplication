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
    }
}
