using System;
using System.Collections.Generic;
using System.Linq;
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
    public class NoteController : ControllerBase
    {
        private readonly INoteBusiness noteBusiness;
        public NoteController(INoteBusiness noteBusiness)
        {
            this.noteBusiness = noteBusiness;
        }
        [HttpPost("AddNote")]
        public IActionResult AddNote(NoteModel noteModel)
        {
            long userId = Convert.ToInt32(User.Claims.FirstOrDefault(a=> a.Type == "UserID").Value);
            var NoteCreate = noteBusiness.AddNote(noteModel, userId);
            if (NoteCreate != null)
            {
                return Ok(new ResponseModel<NoteEntity> { Status = true, Message = "Note Added Successfully",Data = NoteCreate});
            }
            else
            {
                return BadRequest(new ResponseModel<NoteEntity> { Status = false, Message = "No note created" });
            }
        }

        [HttpGet("GetNote")]
        public IActionResult GetNote()
        {
            long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserID").Value);
            var NoteList = noteBusiness.GetAllNotes(UserID);
            if (NoteList != null)
            {
                return Ok(new ResponseModel<List<NoteEntity>> { Status = true, Message = "Note Added Successfully", Data = NoteList });
            }
            else
            {
                return BadRequest(new ResponseModel<NoteEntity> { Status = false, Message = "No note found" });
            }
        }
    }
}
