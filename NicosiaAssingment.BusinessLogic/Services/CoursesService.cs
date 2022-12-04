using AutoMapper;
using NicosiaAssingment.BusinessLogic.Models;
using NicosiaAssingment.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NicosiaAssingment.BusinessLogic.Services;

public class CoursesService : ICoursesService
{
	private readonly INicosiaRepository _nicosiaRepository;
	private readonly IMapper _mapper;

	public CoursesService(INicosiaRepository nicosiaRepository, IMapper mapper)
	{
		_nicosiaRepository = nicosiaRepository;
		_mapper = mapper;
	}

	public async Task<List<SectionInfoBlo>> GetAllSections(int skip, int take)
	{
		var sections = await _nicosiaRepository.GetAllSections(skip, take);

		return _mapper.Map<List<SectionInfoBlo>>(sections);
	}

	public async Task<List<SectionInfoBlo>> GetSpecificSections(int skip, int take, int userId, int? periodId = null, bool hasTaken = false)
	{
		if (periodId == null && hasTaken == false)
		{
			throw new ArgumentException("Ether an academic period or enrollment must be specified");
		}

		var sections = await _nicosiaRepository.GetSpecificSections(skip, take, userId, periodId, hasTaken);

		return _mapper.Map<List<SectionInfoBlo>>(sections);
	}
}
