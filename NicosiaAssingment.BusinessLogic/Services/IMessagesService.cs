using NicosiaAssingment.BusinessLogic.Models;
using NicosiaAssingment.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NicosiaAssingment.BusinessLogic.Services;

public interface IMessagesService
{
	Task RequestMessageApproval(int userId, MessageRequestBlo message);

	Task<List<PendingMessageRequestBlo>> GetMessageRequests(int skip, int take, bool includeApproved = false);

	Task ApproveMessage(int userId, int messageId);
}
