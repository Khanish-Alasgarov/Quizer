using Core.Repositories;
using Core.Repositories.Special;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(DbContext db) : base(db)
        {
        }

        public bool IsCorrect(Guid questionId, Guid answerId)
        {
            throw new NotImplementedException();
        }
    }
}
