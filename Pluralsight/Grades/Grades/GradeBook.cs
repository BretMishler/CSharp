using System;
using System.Collections.Generic;

namespace Grades
{
    public class GradeBook
    {
        // ctor
        public GradeBook()
        {
            _name = "Empty";
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

        // we made this field because we wanted to edit the setter to make sure
        // that people couldnt make it null. But because we edited the setter,
        // the getter needs to explicitel pass back something
        private string _name;
        public string Name
        {
            get
            {
                return _name; // could return a substring if we wanted
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    // here we make a delegate that will let us know when
                    // the name is changed
                    if(_name != value)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.ExistingName = _name;
                        args.NewName = value;

                        NameChanged(this, args);
                    }
                    _name = value;
                }  
            }
        }

        public event NameChangedDelegate NameChanged;

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