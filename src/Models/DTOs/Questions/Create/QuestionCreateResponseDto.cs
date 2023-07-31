namespace Models.DTOs.Questions.Create;

public class QuestionCreateResponseDto
{
    public Guid Id { get; set; }
    public byte Point { get; set; }
    public string Text { get; set; }
}
