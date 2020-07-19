using System.Collections.Generic;

public class StrawBerryCondition : Condition
{
    private int _stage;

    private string _tag;
    private string _lastWateredAt;
    private List<Bug> _attacks;

    public StrawBerryCondition()
    {
        _stage = 1;
        _lastWateredAt = "12/12/2020";
        _attacks = new List<Bug>();
        _tag = "Strawberry";
    }

    public string lastWateredAt
    {
        get { return _lastWateredAt; }
        set { _lastWateredAt = value; }
    }

       public string tag
    {
        get { return _tag; }
    }


    public void AddBug(Bug bug)
    {
        _attacks.Add(bug);
    }

    public List<Bug> attacks
    {
        get { return _attacks; }
    }

    public int stage
    {
        get { return _stage; }
    }

    public override string analyse()
    {
        string currentCondition = "NORMAL";
        foreach (Bug bug in _attacks)
        {
            if(bug is Worm && bug.damgedLevel > 0)
            {
                currentCondition = "DANGER"; 
                break;
            }
        }
        return currentCondition;
    }
}
