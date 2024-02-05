namespace BlazorApp.Services;

public interface IEmailService
{
    void SendEmail(Email email);
    List<Email> GetEmails();
    Email GetEmailById(int id);
}