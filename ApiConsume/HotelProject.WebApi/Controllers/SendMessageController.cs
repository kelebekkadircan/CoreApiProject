﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageService;

        public SendMessageController(ISendMessageService sendMessageService)
        {
            _sendMessageService = sendMessageService;
        }


        [HttpGet]
        public IActionResult SendMessageList()
        {
            var values = _sendMessageService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddSendMessage(SendMessage sendMessage)
        {
            _sendMessageService.TInsert(sendMessage);
            return Ok("Added a message");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSendMessage(int id)
        {
            var values = _sendMessageService.TGetById(id);
            _sendMessageService.TDelete(values);
            return Ok("Delete a message");

        }

        [HttpPut]
        public IActionResult UpdateSendMessage(SendMessage sendMessage)
        {
            _sendMessageService.TUpdate(sendMessage);
            return Ok("Update a sendMessage");
        }

        [HttpGet("{id}")]
        public IActionResult GetSendMessageById(int id)
        {
            var values = _sendMessageService.TGetById(id);
            return Ok(values);
        } 
        [HttpGet("SendMessageCount")]
        public IActionResult SendMessageCount()
        {
            var values = _sendMessageService.TSendMessageCount();
            return Ok(values);
        }




    }
}
