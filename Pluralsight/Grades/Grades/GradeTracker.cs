using System;
using System.IO;
using System.Collections;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        // we know that we need to add grades but dont yet know
        // how we'll do it, so leave it abstract
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
        public abstract IEnumerator GetEnumerator();

        public string Name
        {
            get
            {
                return _name; // could return a substring if we wanted
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }

                // here we make a delegate that will let us know when
                // the name is changed
                if (_name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }
                _name = value;
            }
        }

        public event NameChangedDelegate NameChanged;

        // we made this field because we wanted to edit the setter to make sure
        // that people couldnt make it null. But because we edited the setter,
        // the getter needs to explicitel pass back something
        protected string _name;
    }
}
