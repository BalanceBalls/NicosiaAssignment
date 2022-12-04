using NicosiaAssingment.BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NicosiaAssingment.BusinessLogic.Services;

public interface IPeopleService
{
	Task<List<UserInfoBlo>> GetStudents(int userId, string role);
}
