namespace Models.Entities;

public class Question
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public Guid QuestionSetId { get; set; }
}
