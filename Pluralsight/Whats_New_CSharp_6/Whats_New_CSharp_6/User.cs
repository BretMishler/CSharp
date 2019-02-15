using System;

public class User
{

    //dont have to write 'set' with this auto prop init syntax
    public Guid Id { get; } = Guid.NewGuid();

    public string Username { get; protected set; } = String.Empty;

    /** OLD WAY
    public Guid Id
    {
        // readonly since only a getter
        get { return _id; }

    }

    public string Username
    {
        get { return _username; }
        protected set { _username = value; }
    }

    // BACKING FIELDS //

    //since readonly, can only be assigned during initialization
    private readonly Guid _id = Guid.NewGuid();
    private string _username = String.Empty;
    **/
}