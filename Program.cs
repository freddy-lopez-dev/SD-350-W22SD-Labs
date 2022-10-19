public abstract class Client
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int? Age { get; set; }
    public bool accessDisabled { get; set; }

    public AccessHandler AccessHandler { get; set; }

    public virtual void HandleAccess()
    {
        AccessHandler.getAccess();
    }
}

public class User : Client
{
    public int Reputation { get; set; }
    public AccessHandler AccessHandler { get; set; }

    public User(int reputation)
    {
        AccessHandler = new HasReputation();
        AccessHandler.getAccess(reputation);
    }

    
}

public class Manager : Client
{
    public AccessHandler AccessHandler { get; set; }
    public Manager()
    {
        this.AccessHandler = new HasAccessAutomatic();
    }
}
public class Admin : Client
{
    public Admin()
    {
        this.AccessHandler = new HasAccessAutomatic();
    }
}

public interface AccessHandler
{
    public bool getAccess(int? Reputation = 0, bool accessDisabled = false);
}

public class HasReputation : AccessHandler
{
    public bool getAccess(int? Reputation = 0, bool accessDisabled = false)
    {
        if(Reputation > 20)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class HasAccessAutomatic : AccessHandler
{
    public bool getAccess(int? Reputation = 0, bool accessDisabled = false)
    {
        if(accessDisabled == false)
        {
            return true;
        } else
        {
            return false;
        }
    }
}