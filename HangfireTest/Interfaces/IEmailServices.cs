namespace HangfireTest.Interfaces
{
    public interface IEmailServices
    {
        string SendEmail(string jobType, string startTime);
    }
}
