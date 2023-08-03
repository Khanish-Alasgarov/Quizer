using Core.Repositories;
using Core.Repositories.Special;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.Repositories;

public class SessionRepository : Repository<Session>, ISessionRepository
{
    public SessionRepository(DbContext db) : base(db)
    {
    }
}
