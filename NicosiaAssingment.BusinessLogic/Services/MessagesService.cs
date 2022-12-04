using AutoMapper;
using NicosiaAssingment.BusinessLogic.Models;
using NicosiaAssingment.DataAccess.Models;
using NicosiaAssingment.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NicosiaAssingment.BusinessLogic.Services;

public class MessagesService : IMessagesService
{
	private readonly INicosiaRepository _nicosiaRepository;
	private readonly IMapper _mapper;

	public MessagesService(INicosiaRepository nicosiaRepository, IMapper mapper)
	{
		_nicosiaRepository = nicosiaRepository;
		_mapper = mapper;
	}

	public async Task ApproveMessage(int userId, int messageId)
	{
		await _nicosiaRepository.ApproveMessage(userId, messageId);
	}

	public async Task<List<PendingMessageRequestBlo>> GetMessageRequests(int skip, int take, bool includeApproved = false)
	{
		var pedningMessages = await _nicosiaRepository.GetPendingMessageRequests(skip, take, includeApproved);
		return _mapper.Map<List<PendingMessageRequestBlo>>(pedningMessages);
	}

	public async Task RequestMessageApproval(int userId, MessageRequestBlo message)
	{
		message.SenderId = userId;
		if (message.Content is null || message.Content == string.Empty)
			throw new ArgumentException("Message should not be empty");

		await _nicosiaRepository.CreateMessageApprovalRequest(_mapper.Map<Message>(message));
	}
}
