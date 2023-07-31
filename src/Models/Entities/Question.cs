using Models.Common;

namespace Models.Entities;

public class Question : BaseEntity<Guid>
{ 
    public string Text { get; set; }
    public Guid QuestionSetId { get; set; }
    public byte Point { get; set; }
    public QuestionSet QuestionSet { get; set; }
    public List<Answer> Answers { get; set; }
    public List<SessionContent> SessionContents { get; set; }
}
