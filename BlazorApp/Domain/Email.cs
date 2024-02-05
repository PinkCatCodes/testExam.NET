namespace BlazorApp.Domain;

public class Email
{
    public int Id { get; set; }
    public string Sender { get; set; }
    public string Receiver { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime TimeSent { get; set; }

    public Email( string sender, string receiver, string title, string body, DateTime timeSent)
    {
        
        Sender = sender;
        Receiver = receiver;
        Title = title;
        Body = body;
        TimeSent = timeSent;
    }
    public Email(){}
}