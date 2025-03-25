using Azure.Storage.Queues;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace TicketHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketPurchases : Controller
    {
        private readonly ILogger<TicketPurchases> _logger;    
        private readonly IConfiguration _configuration;

        public TicketPurchases(ILogger<TicketPurchases> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Hello from contacts controller - GET");
        }


        // POST: TicketPurchases/Create
        [HttpPost]
        public async Task<ActionResult> Post(TicketPurchase ticketPurchase)
        {
            if (ModelState.IsValid == false) { return BadRequest(); }

            //post contact to storage queue 

            string queueName = "purchases";
            // Get connection string from secrets.json
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error was encountered");
            }
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            //serialize the ticket purchase object to a JSON string
            string message = JsonSerializer.Serialize(ticketPurchase);
            await queueClient.SendMessageAsync(message);

            return Ok();
        }

    }
}
