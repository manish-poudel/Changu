using UnityEngine;
public class Butterfly : Bug
{
    public Butterfly()
    {
        this.infectious = false;
        this.type = "Normal Butterfly";
        this.damgedLevel = 0;
    }
    public override void Infect()
    {
        if (infectious)
        {

        }
        else
        {
            Debug.Log("Can't get infected by butterfly");
        }
    }
}
