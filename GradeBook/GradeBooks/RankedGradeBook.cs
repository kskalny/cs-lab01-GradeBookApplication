using System;
using GradeBook.Enums;
using System.Linq;

namespace GradeBook.GradeBooks{
    public class RankedGradeBook:BaseGradeBook{
        public RankedGradeBook(string name):base(name){
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade){
            if (this.Students.Count < 5) throw new InvalidOperationException();
            int studentsOverAvarage = 0;
            foreach (var student in this.Students)
            {   
                if (Queryable.Average(student.Grades.AsQueryable()) > averageGrade){
                    ++studentsOverAvarage;
                }
            }
            double avarage = studentsOverAvarage/(double)this.Students.Count;
            if (avarage < 0.2)
                return 'A';
            else if (avarage < 0.4)
                return 'B';
            else if (avarage < 0.6)
                return 'C';
            else if (avarage < 0.8)
                return 'D';
            else
                return 'F';
        }
        public override void CalculateStatistics()
        {
            if (this.Students.Count < 5){
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStatistics();
        }
    }
}