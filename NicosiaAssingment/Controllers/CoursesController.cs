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
public class CoursesController : ControllerBase
{
	private readonly ICoursesService _coursesService;
	private readonly IMapper _mapper;

	public CoursesController(ICoursesService coursesService, IMapper mapper)
	{
		_coursesService = coursesService;
		_mapper = mapper;
	}

	/// <summary>
	/// An endpoint to show list of classes with the option to only
	/// display a certain academic period and/or taken classes.
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Authorize]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<ActionResult> GetSpecificSections(int skip, int take = 2, int? periodId = null, bool hasTaken = false)
	{
		var userId = int.Parse(HttpContext.GetUserId());

		try
		{
			var sections = await _coursesService.GetSpecificSections(skip, take, userId, periodId, hasTaken);

			return Ok(_mapper.Map<List<SectionInfoDto>>(sections));
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
		}
	}

	/// <summary>
	/// An endpoint to show list of all classes
	/// </summary>
	/// <returns></returns>
	[HttpGet]
	[Authorize]
	[ProducesResponseType(200)]
	[ProducesResponseType(400)]
	public async Task<ActionResult> GetAllSections(int skip, int take = 2)
	{
		var role = HttpContext.GetRole();

		try
		{
			var sections = await _coursesService.GetAllSections(skip, take);

			return role switch
			{
				AuthHelper.LecturerRole => Ok(_mapper.Map<List<ExtendedSectionInfoDto>>(sections)),
				AuthHelper.StudentRole => Ok(_mapper.Map<List<SectionInfoDto>>(sections)),
				_ => new EmptyResult()
			};
		}
		catch (Exception ex)
		{
			return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
		}
	}
}
