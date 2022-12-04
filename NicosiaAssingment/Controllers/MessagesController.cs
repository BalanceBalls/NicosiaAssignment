using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NicosiaAssingment.BusinessLogic.Services;
using NicosiaAssingment.Dtos;
using NicosiaAssingment.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using NicosiaAssingment.BusinessLogic.Models;

namespace NicosiaAssingment.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MessagesController : ControllerBase
{
	private readonly IMessagesService _messagesService;
	private readonly IMapper _mapper;

	public MessagesController(IMessagesService messagesService, IMapper mapper)
	{
		_messagesService = messagesService;
		_mapper = mapper;
	}

	/// <summary>
	/// An endpoint to show list of all classes
	/// </summary>
	/// <returns></returns>
	[HttpPost]
	[Authorize(Roles = AuthHelper.StudentRole)]
	[ProducesResponseType(201)]
	[ProducesResponseType(400)]
	public async Task<ActionResult> RequestMessageApproval([FromBody] MessageRequestDto message)
	{
		var userId = int.Parse(HttpContext.GetUserId());

		try
		{
			await _messagesService.RequestMessageApproval(userId, _mapper.Map<MessageRequestBlo>(message));
			return StatusCode(StatusCodes.Status201Created);
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
		}
	}

	/// <summary>
	/// An endpoint to see a list of message requests
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Authorize(Roles = AuthHelper.LecturerRole)]
	[ProducesResponseType(typeof(List<PendingMessageRequestDto>), 200)]
	[ProducesResponseType(400)]
	public async Task<List<PendingMessageRequestDto>> GetMessageRequests(int skip, int take = 2, bool includeApproved = false)
	{
		var pendingMessages = await _messagesService.GetMessageRequests(skip, take, includeApproved);
		return _mapper.Map<List<PendingMessageRequestDto>>(pendingMessages);
	}

	/// <summary>
	/// An endpoint to approve a message request
	/// </summary>
	/// <returns></returns>
	[HttpPut("{messageId}/[action]")]
	[Authorize(Roles = AuthHelper.LecturerRole)]
	[ProducesResponseType(204)]
	[ProducesResponseType(400)]
	public async Task<ActionResult> ApproveMessage(int messageId)
	{
		var userId = int.Parse(HttpContext.GetUserId());

		try
		{
			await _messagesService.ApproveMessage(userId, messageId);

			return NoContent();
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
		}
	}

}
