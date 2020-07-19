// class to provide user information
public class User
{
    private string _name;

    public User(string name)
    {
        _name = name;
    }

    public string name
    {
        get { return _name; }
    }
}
