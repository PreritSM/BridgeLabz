using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using ModelLayer;
using Newtonsoft.Json;
using RepositoryLayer.Entity;

namespace FundooApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly INoteBusiness noteBusiness;
        private readonly ILogger<NoteController> logger;
        IDistributedCache distributedCache;
        public NoteController(INoteBusiness noteBusiness, ILogger<NoteController> logger, IDistributedCache distributedCache)
        {
            this.noteBusiness = noteBusiness;
            this.logger = logger;
            this.distributedCache = distributedCache;
        }
        [HttpPost("AddNote")]
        public IActionResult AddNote(NoteModel noteModel)
        {
            long userId = Convert.ToInt32(User.Claims.FirstOrDefault(a=> a.Type == "UserID").Value);
            var NoteCreate = noteBusiness.AddNote(noteModel, userId);
            if (NoteCreate != null)
            {
                logger.LogInformation("Note Added Successfully for the authorized User");
                return Ok(new ResponseModel<NoteEntity> { Status = true, Message = "Note Added Successfully",Data = NoteCreate});
            }
            else
            {
                logger.LogInformation("No note created for the authorized User");
                return BadRequest(new ResponseModel<NoteEntity> { Status = false, Message = "No note created" });
            }
        }

        [HttpGet("GetNoteByUserID")]
        public IActionResult GetNote()
        {
            long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserID").Value);
            var NoteList = noteBusiness.GetAllNotesByUserID(UserID);
            if (NoteList != null)
            {
                logger.LogInformation("All notes for the authorized User displayed" );
                return Ok(new ResponseModel<List<NoteEntity>> { Status = true, Message = "Notes displayed", Data = NoteList });
            }
            else
            {
                logger.LogInformation("No notes found for the authorized User");
                return BadRequest(new ResponseModel<NoteEntity> { Status = false, Message = "No note found" });
            }
        }

        [HttpPut("PinUnpin")]

        public IActionResult PinUnpin(long noteId)
        {
            long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserID").Value);
            var Notepin = noteBusiness.PinOrUnpinNote(noteId, UserID);
            if (Notepin)
            {
                logger.LogInformation("Note pinned Successfully for the authorized user");

                return Ok(new ResponseModel<bool> { Status = true, Message = "Note pinned successfully", Data = Notepin });
            }
            else
            {
                logger.LogInformation("Note Unpinned Successfully for the authorized user");

                return Ok(new ResponseModel<bool> { Status = true, Message = "Note Unpinned Successfully", Data = Notepin });
            }
        }

        [HttpPut("Archive_NotArchived")]

        public IActionResult Archive_NotArchived(long noteId)
        {
            long UserID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserID").Value);
            var NoteArchive = noteBusiness.PinOrUnpinNote(noteId, UserID);
            if (NoteArchive)
            {
                logger.LogInformation("Note Archived Successfully for the authorized user");
                return Ok(new ResponseModel<bool> { Status = true, Message = "Note Archived successfully", Data = NoteArchive });
            }
            else
            {
                logger.LogInformation("Note UnArchived Successfully for the authorized user");
                return Ok(new ResponseModel<bool> { Status = true, Message = "Note Unarchived Successfully", Data = NoteArchive });
            }
        }

        [AllowAnonymous]

        [HttpGet("GetAllNotes")]
        public IActionResult GetAllNotesPresent()
        {

            var NoteList = noteBusiness.GetAllNotes();
            if (NoteList != null)
            {
                logger.LogInformation("All Existing Notes Displayed");
                return Ok(new ResponseModel<List<NoteEntity>> { Status = true, Message = "All Notes Displayed", Data = NoteList });
            }
            else
            {
                logger.LogInformation("No Notes Displayed");
                return BadRequest(new ResponseModel<NoteEntity> { Status = false, Message = "No note found" });
            }
        }

        [AllowAnonymous]
        [HttpGet("GetAllNotesUsingRedis")]
        public async Task<IActionResult> GetAllNotesUsingRedis()
        {
            var CacheKey = "NotesList";
           // string SerializedNoteList;
            List<NoteEntity> NoteList;
            byte[] RedisNoteList = await distributedCache.GetAsync(CacheKey);
            if (RedisNoteList != null)
            {
                var SerializedNoteList = Encoding.UTF8.GetString(RedisNoteList);
                NoteList = JsonConvert.DeserializeObject<List<NoteEntity>>(SerializedNoteList);
            }
            else
            {
                NoteList = noteBusiness.GetAllNotes();
                var SerializedNoteList = JsonConvert.SerializeObject(NoteList);
                var redisNote =  Encoding.UTF8.GetBytes(SerializedNoteList);
                var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(3));

                await distributedCache.SetAsync(CacheKey, redisNote, options);
            }
            return Ok(NoteList);
        
        }


        [HttpPut("UploadImageToNote")]

        public IActionResult UploadImage(long NoteID, IFormFile img)
        {
            long UserID = Convert.ToInt64(User.Claims.FirstOrDefault(r => r.Type == "UserID").Value);
            var res  = noteBusiness.UploadImage(NoteID, UserID, img);
            if (res != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "Image Uploaded", Data = res });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = true, Message = "Image Upload Failed" });
            }
        }

        [HttpPost("DeleteNote")]

        public IActionResult DeleteNote(long NoteID)
        {
            long UserID = Convert.ToInt64(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
            var result = noteBusiness.DeletedNoteForever(NoteID,UserID);
            if (result != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "Note Deleted Forever", Data = result });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Note not in Trash" });
            }
        }

        [HttpPatch("ChangeColor")]
        public IActionResult ChangeColor (long NoteID, string color)
        {
            long UserID = Convert.ToInt64(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
            var result =  noteBusiness.ChangeColor(NoteID,UserID,color);
            if (result != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "Colour Changed", Data = result });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Colour provided is same as before"});
            }
        }

        [HttpPost("ChangeReminder")]

        public IActionResult ChangeReminder(long NoteID,DateTime reminder)
        {
            long UserID = Convert.ToInt64(User.Claims.FirstOrDefault(e => e.Type == "UserID").Value);
            var result = noteBusiness.ReminderChange(NoteID,UserID,reminder);
            if (result != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "Reminder Changed", Data = result });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Cannot Change Reminder" });
            }
        }




    }
}
