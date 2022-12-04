using Microsoft.EntityFrameworkCore;
using NicosiaAssingment.DataAccess.Models;
using System.Threading.Tasks;

namespace NicosiaAssingment.DataAccess;

public interface INicosiaContext
{
	DbSet<Section> Sections { get; set; }
	DbSet<User> Users { get; set; }
	DbSet<Message> Messages { get; set; }

	DbSet<StudentEnrollment> StudentEnrollments { get; set; }

	void Migrate();

	void EnsureCreated();

	Task SaveChangesAsync();
}
