using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NicosiaAssingment.BusinessLogic.Services;
using NicosiaAssingment.Dtos;
using NicosiaAssingment.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NicosiaAssingment.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class PeopleController : ControllerBase
{
	private readonly IPeopleService _peopleService;
	private readonly IMapper _mapper;

	public PeopleController(IPeopleService peopleService, IMapper mapper)
	{
		_peopleService = peopleService;
		_mapper = mapper;
	}
	/// <summary>
	/// An endpoint that shows a list of students
	/// </summary>
	/// <returns>A list of students</returns>
	[HttpGet]
	[Authorize]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<ActionResult> GetStudents()
	{
		var role = HttpContext.GetRole();
		var userId = int.Parse(HttpContext.GetUserId());

		try
		{
			var students = await _peopleService.GetStudents(userId, role);

			return role switch
			{
				AuthHelper.LecturerRole => Ok(_mapper.Map<List<ExtendedStudentInfoDto>>(students)),
				AuthHelper.StudentRole => Ok(_mapper.Map<List<StudentInfoDto>>(students)),
				_ => new EmptyResult()
			};
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
		}
	}
}
