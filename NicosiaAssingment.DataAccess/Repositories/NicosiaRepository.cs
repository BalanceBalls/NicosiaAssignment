using Microsoft.EntityFrameworkCore;
using NicosiaAssingment.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NicosiaAssingment.DataAccess.Repositories;

public class NicosiaRepository : INicosiaRepository
{
	private readonly INicosiaContext _context;

	public NicosiaRepository(INicosiaContext context)
	{
		_context = context;
	}

	public async Task<List<User>> GetLecturerStudents(int userId)
	{
		return await _context.Sections
			.AsNoTracking()
			.Include(x => x.SectionLecturers)
				.ThenInclude(y => y.Lecturer)
			.Include(x => x.StudentEnrollments)
				.ThenInclude(y => y.Student)
			.Select(section => section.StudentEnrollments
				.Where(student => section.SectionLecturers
					.Any(lecturer => lecturer.LecturedSectionId == student.EnrolledInId && lecturer.LecturerId == userId)))
			.SelectMany(x => x.Select(y => y.Student))
			.Distinct()
			.ToListAsync();
	}

	public async Task<List<User>> GetClassmatesInfo(int userId)
	{
		var userClasses = await _context.StudentEnrollments
			.AsNoTracking()
			.Where(x => x.StudentId == userId)
			.Select(x => x.EnrolledInId)
			.ToListAsync();

		return await _context.Users
			.AsNoTracking()
			.Include(x => x.StudentEnrollments)
			.Select(user => 
				user.StudentEnrollments
					.Where(student => student.StudentId != userId &&
				userClasses.Contains(student.EnrolledInId)))
			.SelectMany(x => x.Select(y => y.Student))
			.Distinct()
			.ToListAsync();
	}

	public async Task<List<Section>> GetSpecificSections(int skip, int take, int userId, int? periodId = null, bool hasTaken = false)
	{
		return await _context.Sections
			.AsNoTracking()
			.OrderBy(x => x.Id)
			.Include(x => x.Course)
			.Include(x => x.Period)
			.Include(x => x.SectionLecturers)
				.ThenInclude(y => y.Lecturer)
			.Include(x => x.StudentEnrollments)
			.Where(x => periodId != null ? x.PeriodId == periodId : true)
			.Where(x => hasTaken ? x.StudentEnrollments.Select(y => y.StudentId).Contains(userId) : true)
			.Skip(skip)
			.Take(take)
			.ToListAsync();
	}

	public async Task<User> GetUserByEmail(string email)
	{
		return await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));
	}

	public async Task<List<Section>> GetAllSections(int skip, int take)
	{
		return await _context.Sections
			.AsNoTracking()
			.OrderBy(x => x.Id)
			.Include(x => x.Course)
			.Include(x => x.Period)
			.Include(x => x.SectionLecturers)
				.ThenInclude(y => y.Lecturer)
			.Include(x => x.StudentEnrollments)
			.Skip(skip)
			.Take(take)
			.ToListAsync();
	}

	public async Task CreateMessageApprovalRequest(Message message)
	{
		_context.Messages.Add(message);
		await _context.SaveChangesAsync();
	}

	public async Task<List<Message>> GetPendingMessageRequests(int skip, int take, bool includeApproved = false)
	{
		return await _context.Messages
			.AsNoTracking()
			.OrderBy(x => x.Id)
			.Include(x => x.Sender)
			.Include(x => x.Approver)
			.Include(x => x.TargetSection)
			.Where(x => includeApproved ? true : x.IsApproved == false)
			.Skip(skip)
			.Take(take)
			.ToListAsync();
	}

	public async Task ApproveMessage(int userId, int messageId)
	{
		var message = await _context.Messages.FirstOrDefaultAsync(x => x.Id == messageId);
		if (message is null)
			throw new ArgumentException("Incorrect messageId");

		message.ApproverId = userId;
		message.IsApproved = true;

		await _context.SaveChangesAsync();
	}
}
