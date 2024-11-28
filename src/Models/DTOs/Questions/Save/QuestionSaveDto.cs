namespace Models.DTOs.Questions.Save;

public class QuestionSaveDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public byte Point { get; set; }
    public Guid QuestionSetId { get; set; }
    public Guid? CorrectAnswerId { get; set; }
}
