using System;
using System.Collections.Generic;

namespace Grades
{
    public class GradeBook
    {
        // ctor
        public GradeBook()
        {
            grades = new List<float>();
        }

        public GradeStatistics ComputeStatistics()
        {
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
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        // <> is generic type syntax
        private List<float> grades;

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