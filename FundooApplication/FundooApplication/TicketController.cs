using System;
using System.Threading.Tasks;
using BussinessLayer.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FundooApplication
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IBus bus;
        private readonly IUserBusiness user;


        public TicketController(IBus bus, IUserBusiness user)
        {
            this.bus = bus;
            this.user = user;
        }

        [HttpPost("Ticket")]

        public async Task< IActionResult>CreateTicketForPassword(string Email)
        {
            var token = user.ForgetPassword(Email);
            if(token != null)
            {
                var ticket = user.CreateTicketforPassword(Email, token);
                Uri uri = new Uri("rabbitmq://localhost/ticketqueue");
                var endPoint = await bus.GetSendEndpoint(uri);
                await endPoint.Send(ticket);
                return Ok(new { Status = true, message = "Mail sent successfully" });
            }
            else
            {
                return BadRequest(new { status = false, message = "Mail not sent" });
            }
        }
    }
}
