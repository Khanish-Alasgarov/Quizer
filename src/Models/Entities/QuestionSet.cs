using Models.Common;

namespace Models.Entities;

public class QuestionSet : BaseEntity<Guid>
{
    public string Subject { get; set; }
    public List<Question> Questions { get; set; }
    public List<Session> Sessions { get; set; }

}
