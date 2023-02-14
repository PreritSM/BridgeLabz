using System.Linq;
using System;
using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using RepositoryLayer.Entity;

namespace FundooApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CollabController : ControllerBase
    {
        private readonly ICollabBussiness collab;

        public CollabController(ICollabBussiness collab)
        {
            this.collab = collab;
        }

        [HttpPost("Add_Collaborator")]
        public IActionResult AddCollab (string email,long NoteID)
        {
            long userID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserID").Value);
            var result = collab.AddCollab(email,userID,NoteID);
            if (result!=null)
            {
                return Ok(new ResponseModel<CollabEntity> { Status = true, Message = "Collaborator Added Successfully", Data = result });
            }
            else
            {
                return BadRequest(new ResponseModel<CollabEntity> { Status = false, Message = "Collaborator Addition Failed" });
            }
        }

    }
}
