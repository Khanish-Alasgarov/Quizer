namespace Models.DTOs.Questions.Create;

public class QuestionCreateDto
{
    public string Text { get; set; }
    public byte Point { get; set; }
    public Guid QuestionSetId { get; set; }
}
