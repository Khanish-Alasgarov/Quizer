using Core.Repositories;
using Core.Repositories.Special;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.Repositories;

public class SessionContentRepository : Repository<SessionContent>, ISessionContentRepository
{
    public SessionContentRepository(DbContext db) : base(db)
    {
    }
}
