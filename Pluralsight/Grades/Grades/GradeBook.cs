using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        // ctor
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook::ComputeStatistics");

            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades) {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            // try catch was not originally part of this lesson
            // but put it in there anywhere in case grades.Count = 0;
            try {
                stats.AverageGrade = sum / grades.Count;
            } catch (Exception e) {
                Console.WriteLine("Invalid except: {0}", e);
            }

            return stats;
        }

        // class members broadly fall into two classes:
        // 1. state
        // 2. behavior
        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

        // <> is generic type syntax
        protected List<float> grades;

        public override void WriteGrades(TextWriter destination)
        {   // gonna write in reverse
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i-1]);
            }
        }

        // if undeclared, private is default access modifier

        // access modifieers = public or private



        // STATIC
        // use static members of a class w/out creating an instance
        // static field or method is accessed without creating an instance

        // this is how Console.WriteLine works
        // console is a class but you dont need an instance of
        // console to use that class
        // aka dont have to write console x = new console();
    }
}