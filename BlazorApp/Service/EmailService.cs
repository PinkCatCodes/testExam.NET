using System.Text.Json;
using BlazorApp.Domain;

namespace BlazorApp.Service;

public class EmailService : IEmailService
{
    private List<Email> _emails = new ();

    public EmailService()
    {
        // Create 5 dummy emails
        for (int i = 0; i < 5; i++)
        {
            var email = new Email
            {
                Id = i + 1,
                Sender = i % 2 == 0 ? "You" : "Someone Else",
                Receiver = i % 2 == 0 ? "Someone Else" : "You",
                Title = $"Dummy Title {i + 1}",
                Body = $"This is the body of dummy email {i + 1}",
                TimeSent = DateTime.Now
            };
            _emails.Add(email);
        }

      
        
    }
    public void SendEmail(Email email)
    {
        email.Id = _emails.Count + 1; 
        email.Sender = "You";
        email.TimeSent = DateTime.Now;
        _emails.Add(email);
       
        string jsonEmail = JsonSerializer.Serialize(email);
        Console.WriteLine(jsonEmail);
      
    }

    public List<Email> GetEmails()
    {
        return _emails;
    }

    public Email GetEmailById(int id)
    {
        return _emails.FirstOrDefault(e => e.Id == id);
    }


    
}