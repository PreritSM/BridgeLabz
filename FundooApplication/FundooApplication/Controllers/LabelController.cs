using System;
using System.Collections.Generic;
using System.Linq;
using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using ModelLayer;
using RepositoryLayer.Entity;

namespace FundooApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LabelController : ControllerBase
    {
        private readonly ILabelBussiness labelBussiness;
        public LabelController (ILabelBussiness labelBussiness)
        {
            this.labelBussiness = labelBussiness;
        }

        [HttpPost ("Add_Label")]
        public IActionResult Add_Label(long NoteId,string label)
        {
            long userID = Convert.ToInt32(User.Claims.FirstOrDefault(a=>a.Type == "UserID").Value);
            var added_label = labelBussiness.AddLabel(NoteId, userID, label);
            if (added_label != null)
            {
                return Ok(new ResponseModel<LabelEntity> { Status = true, Message = "Label Added Successfully", Data = added_label });
            }
            else
            {
                return BadRequest(new ResponseModel<LabelEntity> {Status = false, Message="Could not add label" });
            }
        }

        [AllowAnonymous]
        [HttpGet("Get_All_Labels")]

        public IActionResult Get_Labels()
        {
            var labelEntities = labelBussiness.GetLabels();
            if (labelEntities != null)
            {
                return Ok(new ResponseModel<List<LabelEntity>> { Status = true, Message = "All Labels Displayed", Data = labelEntities });
            }
            else
            {
                return BadRequest(new ResponseModel<List<LabelEntity>> { Status = false, Message = "Cannot Display Labels" });
            }
        }

        [HttpPost("Delete_Label")]

        public IActionResult DeleteLabel(long LabelId, long NoteID)
        {
            long userID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserID").Value);
            var result = labelBussiness.DeleteLabel(LabelId,NoteID,userID);
            if(result!= null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "Label Deleted Successfully", Data = result });
            }
            else
            {
                return BadRequest(new ResponseModel<string> { Status = false, Message = "Label couldn't be deleted"});
            }
        }

        [HttpPatch("UpdateLabel")]

        public IActionResult UpdateLabel(string labelDesc, long LabelID)
        {
            long userID = Convert.ToInt32(User.Claims.FirstOrDefault(a => a.Type == "UserID").Value);
            var result = labelBussiness.UpdateLabel(labelDesc,LabelID,userID);
            if (result != null)
            {
                return Ok(new ResponseModel<LabelEntity> { Status = true, Message = "Label Updated Successfully", Data = result });
            }
            else
            {
                return BadRequest(new ResponseModel<LabelEntity> { Status = false, Message = "Label couldn't be updated" });
            }
        }

    }
}
