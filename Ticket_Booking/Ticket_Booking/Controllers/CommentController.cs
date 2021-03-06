﻿using BusinessService;
using DataService.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticket_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController:ControllerBase
    {
        private ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin,artist,user")]
        [HttpGet]
        public IActionResult GetComments()
        {
            return Ok(_commentService.GetComments());
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin,artist,user")]
        [HttpGet("Comment/{id}")]
        public IActionResult GetComment(int id)
        {
            var comment = _commentService.GetComment(id);

            if (comment != null)
            {
                return Ok(comment);
            }
            return NotFound($"Comment with Id: {id} was not found");
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin,artist,user")]
        [HttpGet("User/{id}")]
        public IActionResult GetCommentByUserId(int id)
        {
            var comment = _commentService.GetCommentByUserId(id);

            if (comment != null)
            {
                return Ok(comment);
            }
            return NotFound($"User with Id: {id} was not found");
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin,artist,user")]
        [HttpGet("Event/{id}")]
        public IActionResult GetCommentByEventId(int id)
        {
            var comment = _commentService.GetCommentByEventId(id);

            if (comment != null)
            {
                return Ok(comment);
            }
            return NotFound($"Event with Id: {id} was not found");
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin,artist,user")]
        [HttpPost("adding")]
        public bool AddComment(Comment comment)
        {
            var p = _commentService.AddComment(comment);
            return p;
            
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin,artist,user")]
        [HttpPost("Reply")]
        public bool AddReply(int id,string reply)
        {
            var p = _commentService.AddReply(id,reply);
            return p;

        }
    }
}
