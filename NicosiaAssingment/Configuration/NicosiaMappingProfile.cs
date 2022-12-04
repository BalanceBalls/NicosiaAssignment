using AutoMapper;
using NicosiaAssingment.BusinessLogic.Models;
using NicosiaAssingment.DataAccess.Models;
using NicosiaAssingment.Dtos;
using System.Linq;

namespace NicosiaAssingment.Configuration;

public class NicosiaMappingProfile : Profile
{
	public NicosiaMappingProfile()
	{
		CreateMap<User, UserCredentialsBlo>()
			.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

		CreateMap<User, UserInfoBlo>();

		CreateMap<UserInfoBlo, ExtendedStudentInfoDto>();
		CreateMap<UserInfoBlo, StudentInfoDto>();

		CreateMap<User, LecturerBlo>();
		CreateMap<AcademicPeriod, AcademicPeriodBlo>();
		CreateMap<StudentEnrollment, StudentEnrollmentBlo>();
		CreateMap<Course, CourseBlo>();
		CreateMap<Section, SectionInfoBlo>()
			.ForMember(dest => dest.AcademicPeriod, opt => opt.MapFrom(src => src.Period))
			.ForMember(dest => dest.Lecturers, opt => opt.MapFrom(src => src.SectionLecturers.Select(y => y.Lecturer)));

		CreateMap<SectionInfoBlo, SectionInfoDto>();
		CreateMap<AcademicPeriodBlo, AcademicPeriodDto>();
		CreateMap<CourseBlo, CourseDto>();
		CreateMap<LecturerBlo, LecturerDto>();

		CreateMap<SectionInfoBlo, ExtendedSectionInfoDto>()
			.ForMember(
				dest => dest.StudentsNumber, 
				opt => opt.MapFrom(src => src.StudentEnrollments.Count));

		CreateMap<MessageRequestDto, MessageRequestBlo>();
		CreateMap<MessageRequestBlo, Message>()
			.ForMember(dest => dest.TargetSectionId, opt => opt.MapFrom(src => src.SectionId));

		CreateMap<Message, PendingMessageRequestBlo>()
			.ForMember(dest => dest.MessageId, opt => opt.MapFrom(src => src.Id))
			.ForMember(dest => dest.SectionName, opt => opt.MapFrom(src => src.TargetSection.SectionNumber))
			.ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => $"{src.Sender.FirstName} {src.Sender.LastName}"))
			.ForMember(dest => dest.IsApproved, opt => opt.MapFrom(src => src.IsApproved))
			.ForMember(dest => dest.ApproverName, opt =>
			{
				opt.MapFrom(src =>
					src.Approver == null
						? string.Empty
						: $"{src.Approver.FirstName} {src.Approver.LastName}");
			});

		CreateMap<PendingMessageRequestBlo, PendingMessageRequestDto>();
	}
}
