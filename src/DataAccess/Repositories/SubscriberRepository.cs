using Core.Repositories;
using Core.Repositories.Special;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.Repositories;

public class SubscriberRepository : Repository<Subscriber>, ISubscriberRepository
{
    public SubscriberRepository(DbContext db) : base(db)
    {
    }
}
