// Abstract class of Bug
public abstract class Bug : IBug
{
    public string type;
    public bool infectious;


    public int damgedLevel;

    public abstract void Infect();
}
