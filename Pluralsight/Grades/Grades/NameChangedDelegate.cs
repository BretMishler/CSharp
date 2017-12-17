using System;
namespace Grades
{
    //public delegate void NameChangedDelegate(string existingName, string newName);

    // convention in .NET where an event always passes 2 params
    // 1. sender of the event
    // 2. contains all of the args/needed info about that event

    //object param means you can pass anything
    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args);
}
