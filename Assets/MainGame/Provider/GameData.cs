using System.Collections.Generic;

/// Singleton class to access all game data
public sealed class GameData
{

    private int _level;
    private List<Condition> _conditions;
    private User _user;

    GameData()
    {

    }

    public void Init()
    {
        SetLevel();
        SetCondition();
        SetUser();
    }

    private static readonly object padlock = new object();
    private static GameData instance = null;
    public static GameData Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new GameData();
                }
                return instance;
            }
        }
    }

    /// Set our current game level
    private void SetLevel()
    {
        _level = 1;
    }

    /// Set our game conditions
    private void SetCondition()
    {
        _conditions = new List<Condition>();
        _conditions.Add(new StrawBerryCondition());
    }

    /// Set our game user
    private void SetUser()
    {
        _user = new User("John Doe");
    }

    /// Get game level
    public int level
    {
        get { return _level; }
    }

    // Get game condition
    public List<Condition> condition
    {
        get { return _conditions; }
    }

    // Get game user
    public User user
    {
        get { return _user; }
    }


}
