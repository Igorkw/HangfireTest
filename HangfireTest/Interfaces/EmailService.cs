
namespace HangfireTest.Interfaces
{
    public class EmailService : IEmailServices
    {
        public string SendEmail(string jobType, string startTime)
        {
            Console.WriteLine($"{jobType} - {startTime} - Email Successfully sent! {DateTime.Now.ToLongTimeString()}");
            var id = Guid.NewGuid();
            return id.ToString();
        }
    }
}
