using NicosiaAssingment.BusinessLogic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NicosiaAssingment.BusinessLogic.Services;

public interface ICoursesService
{
	Task<List<SectionInfoBlo>> GetSpecificSections(int skip, int take, int userId, int? periodId = null, bool hasTaken = false);
	Task<List<SectionInfoBlo>> GetAllSections(int skip, int take);
}
