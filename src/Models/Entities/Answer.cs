using Models.Common;

namespace Models.Entities;

public class Answer: BaseEntity<Guid>
{ 
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
    public Guid QuestionId { get; set; }
    public Question Question { get; set; }
    public List<SessionContent> SessionContent { get; set; }
}
