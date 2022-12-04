using NicosiaAssingment.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NicosiaAssingment.DataAccess.Repositories;

public interface INicosiaRepository
{
	Task<List<Section>> GetSpecificSections(int skip, int take, int userId, int? periodId = null, bool hasTaken = false);
	Task<List<Section>> GetAllSections(int skip, int take);
	Task<List<User>> GetLecturerStudents(int userId);
	Task<List<User>> GetClassmatesInfo(int userId);
	Task<User> GetUserByEmail(string email);
	Task CreateMessageApprovalRequest(Message message);
	Task<List<Message>> GetPendingMessageRequests(int skip, int take, bool includeApproved = false);
	Task ApproveMessage(int userId, int messageId);
}
