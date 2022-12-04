using AutoMapper;
using NicosiaAssingment.BusinessLogic.Models;
using NicosiaAssingment.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NicosiaAssingment.BusinessLogic.Services;

public class PeopleService : IPeopleService
{
	private readonly INicosiaRepository _nicosiaRepository;
	private readonly IMapper _mapper;

	public PeopleService(INicosiaRepository nicosiaRepository, IMapper mapper)
	{
		_nicosiaRepository = nicosiaRepository;
		_mapper = mapper;
	}
	/// <summary>
	/// Gets a list of students
	/// </summary>
	/// <param name="userId">User's Id</param>
	/// <param name="role">Uses's role</param>
	/// <returns>A list of students</returns>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	public async Task<List<UserInfoBlo>> GetStudents(int userId, string role)
	{
		var students = role switch
		{
			// For Lecturers: They will have full access to student’s information,
			// granted that the student has taken a class with them
			Roles.LecturerRole => await _nicosiaRepository.GetLecturerStudents(userId),
			// For students: They will see list of students’ first name and last names,
			// granted they’ve had a class together.
			Roles.StudentRole => await _nicosiaRepository.GetClassmatesInfo(userId),
			_ => throw new ArgumentOutOfRangeException(nameof(role), $"Cannot get students for the role: {role}"),
		};
		
		return _mapper.Map<List<UserInfoBlo>>(students);
	}
}
