using UnityEngine;
public class Worm : Bug
{
    public Worm()
    {
        this.infectious = true;
        this.type = "Worm";
        this.damgedLevel = 0;
    }
    public override void Infect()
    {
        if (infectious)
        {
            Debug.Log("Infecting the plant...");
            damgedLevel++;
        }
        else
        {

        }
    }
}

