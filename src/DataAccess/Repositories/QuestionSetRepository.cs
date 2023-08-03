using Core.Repositories;
using Core.Repositories.Special;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.Repositories;

internal class QuestionSetRepository : Repository<QuestionSet>, IQuestionSetRepository
{
    public QuestionSetRepository(DbContext db) : base(db)
    {
    }
}
