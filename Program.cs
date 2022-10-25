using System.Text;
using System.Text.Json;

SecuritySystem newSystem = new TwoFactorRequired();

newSystem.DeserializeUser("MOCKDATA.json");


public abstract class SecuritySystem
{
    public User DeserializeUser(string fileName)
    {
        User user;
        Deserializer deserializer = new Deserializer();

        deserializer.DeserializedJSON(fileName);

        
        user = CreateUser(deserializer);

        return user;
    }
    protected abstract User CreateUser(Deserializer Deserializer);

}

public class TwoFactorRequired : SecuritySystem
{
    protected override User CreateUser(Deserializer Deserializer)
    {
        User newUser;

        if(Deserializer.TwoFactorAuthentication == true || Deserializer.IsAdmin == true)
        {
            newUser = new Administrator();
        } else
        {
            throw new Exception("Invalid JSON properties");
        }

        return newUser;

    }
}

public class TwoFactorNotRequired : SecuritySystem
{
    protected override User CreateUser(Deserializer Deserializer)
    {
        User newUser;

        if (Deserializer.TwoFactorAuthentication == true || Deserializer.IsAdmin == true)
        {
            newUser = new Administrator();
        }
        else
        {
            newUser = new AuthorizedUser();
        }

        return newUser;
    }
}



public abstract class User
{
    public string Password { get; set; }

    public abstract string PasswordHash();

}

public class Deserializer
{
    public bool TwoFactorAuthentication { get; set; }
    public bool IsAdmin { get; set; }
    public List<StringTags> incoming { get; set; } = new List<StringTags>();

    public void DeserializedJSON(string fileName)
    {
        using (StreamReader r = new StreamReader(fileName))
        {
            string json = r.ReadToEnd();
            incoming = JsonSerializer.Deserialize<List<StringTags>>(json);

            foreach (var data in incoming)
            {
                TwoFactorAuthentication = data.TwoFactorAuthentication;
                IsAdmin = data.IsAdmin;
            }
        }
    }
}
public record struct StringTags (
    bool TwoFactorAuthentication,
    bool IsAdmin
    );

public class Administrator : User
{
    public override string PasswordHash()
    {
        throw new NotImplementedException();
    }
}

public class AuthorizedUser : User
{
    public override string PasswordHash()
    {
        throw new NotImplementedException();
    }
}