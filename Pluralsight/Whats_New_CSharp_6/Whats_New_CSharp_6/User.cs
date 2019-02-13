using System;

public static class User
{
    public Guid Id
    {
        get { return _id; }
    }

    public string Username
    {
        get { return _username; }
        protected set { _username = value; }
    }

	// backing fields
    private readonly Guid _id;
    private string _username = String.Empty;
}