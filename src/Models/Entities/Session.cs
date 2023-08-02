using Models.Common;

namespace Models.Entities;

public class Session : BaseEntity<Guid>
{
    public string Code { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid QuestionSetId { get; set; }
    public QuestionSet QuestionSet { get; set; }
    public List<SessionContent> SessionContents { get; set; }
}
