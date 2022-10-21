
public interface Client
{
    public string UserName { get; set; }
    public string UserAuthString { get; set; }
    public bool HasAccess { get; set; }

    public string BuildAuthString();
}

public class User : Client
{
    public string UserName { get; set; }
    public string UserAuthString { get; set; }
    public bool HasAccess { get; set; } = false;

    public string BuildAuthString()
    {
        return UserAuthString;
    }
}

public class Manager : Client
{
    public string UserName { get; set; }
    public string UserAuthString { get; set; }
    public bool HasAccess { get; set; } = true;

    public string BuildAuthString()
    {
        return UserAuthString + "MAN";
    }
}

public class Admin : Client
{
    public string UserName { get; set; }
    public string UserAuthString { get; set; }
    public bool HasAccess { get; set; } = true;

    public string BuildAuthString()
    {
        return UserAuthString + "ADMIN";
    }
}

public interface AccessBehaviour
{
    public Client Client { get; set; }

    public bool HandleAccess();
}

public class CheckString : AccessBehaviour
{
    public Client Client { get; set;}

    public CheckString(Client client)
    {
        Client = client;
    }

    public bool HandleAccess()
    {
        if (Client.UserAuthString.Contains("MAN") || Client.UserAuthString.Contains("ADMIN"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class SwitchAuth : AccessBehaviour
{
    public Client Client { get; set; }

    public SwitchAuth(Client client)
    {
        Client = client;
    }

    public bool HandleAccess()
    {
        Client.HasAccess = !Client.HasAccess;
        return Client.HasAccess;
    }
}

public abstract class ClientFactory
{
    public Client createClient(string clientType, string userName)
    {
        Client client;

        client = createClient(clientType, userName);
        client.BuildAuthString();

        return client;
    }
}

public abstract class ClientHandler
{
    ClientFactory clientFactory;

    public abstract Client createClient(string clientType, string userName);
    public abstract boo
}