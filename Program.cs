/*Application with Users and Bandges
 * Design:
 * Client will be an abstract class with normal props like username, email and a Description {get; set;} that will use the virtual method of GetDescription().
 * User will be a child class which inherits client. Upon instantiate should have a description that says Base-Level User.
 * Decorator called BadgeDecorator should inherit from Client and should have a property to be passed through getDescription/getBadges.
 */

Client newClient = new User("newUser", "newUser@gmail.com");

Console.WriteLine(newClient.Description);
newClient = new NewBieBadge(newClient);

Console.WriteLine(newClient.getBadges());

public abstract class Client
{

    public string Description { get; set; }
    public virtual string getDescription()
    {
        return this.Description = "No Description";
    }

    public int Reputation { get; set; }
    public virtual int increaseReputation()
    {
        return Reputation;
    }

    public string Badges { get; set; }
    public virtual string getBadges()
    {
        return Badges;
    }
}

public class User : Client
{
    public string username { get; set; }
    public string email { get; set; }
    public User(string username, string email)
    {
        this.username = username;
        this.email = email;
        Description = "Base-level User";
    }

    public override string getDescription()
    {
        return Description;
    }
}

public abstract class BadgeDecorator : Client
{
    public Client Client;
    public int Reputation;
    public string Badges;

    public override string getBadges()
    {
        return $"{Client.getDescription()}, {Badges}";
    }

    public override int increaseReputation()
    {
        return Client.increaseReputation() + 5;
    }
}

public class NewBieBadge : BadgeDecorator
{
    public NewBieBadge(Client client)
    {
        Client = client;
        Badges = "NewBie";
    } 
}


