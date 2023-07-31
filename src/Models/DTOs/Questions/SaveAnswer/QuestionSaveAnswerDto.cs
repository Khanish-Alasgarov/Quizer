namespace Models.DTOs.Questions.SaveAnswer;

public class QuestionSaveAnswerDto
{
    public Guid? Id { get; set; }
    public Guid QuestionId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}
