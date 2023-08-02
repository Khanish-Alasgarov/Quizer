namespace Models.Entities;

public class SessionContent
{
    public Guid SessionId { get; set; }
    public Session Session { get; set; }
    public Guid SubscriberId { get; set; }
    public Subscriber Subscriber { get; set; }
    public Guid QuestionId { get; set; }
    public Question Question { get; set; }
    public Guid? AnswerId { get; set; }
    public Answer Answer { get; set; }
    public bool? Success { get; set; }
}
