using Hangfire;
using HangfireTest.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HangfireTest.Controllers
{
    public class HangfireController : ControllerBase
    {
        private IEmailServices _emailServices;
        private IBackgroundJobClient _backgroundJobClient;
        private IRecurringJobManager _recurringJobManager;

        public HangfireController(IEmailServices emailservices, IBackgroundJobClient backgroundjobclient, IRecurringJobManager recurringJobManager)
        {
            _emailServices = emailservices;
            _backgroundJobClient = backgroundjobclient;
            _recurringJobManager = recurringJobManager;
        }

        [HttpGet]
        [Route("Jobs")]

        //Queued Jobs (Set and forget Job)
        /*public ActionResult CreateFireAndForgetJob() 
        {
            _backgroundJobClient.Enqueue(() => _emailServices.SendEmail("Fire-and-Forget Job", DateTime.Now.ToLongTimeString()));
            return Ok("Background job executed successfully!!");
        }*/

        //Delayed Job
        /*public ActionResult CreateDelayedJob()
        {
            _backgroundJobClient.Schedule(() => _emailServices.SendEmail("Delayed Job", DateTime.Now.ToLongTimeString()), TimeSpan.FromMinutes(5));
            return Ok($"Background job execution delayed for 5 minutes!!");
        }*/

        //Recuring Job
        /*public ActionResult CreateRecurringJob()
        {
            RecurringJob.AddOrUpdate(() => _emailServices.SendEmail("Recuring Job", DateTime.Now.ToLongTimeString()), Cron.Daily);
            return Ok($"Background job execution is daily!!");
        }*/

        // Continuation Job
        public ActionResult CreateRecurringJob()
        {
            var jobId = BackgroundJob.Enqueue(()=> _emailServices.SendEmail("Recuring Job", DateTime.Now.ToLongTimeString()));
            BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine($"Email sent successfully with id {jobId}"));
            return Ok($"Background job running with Id {jobId}!!");
        }
    }
}
