using Models.Entities;

namespace Models.DTOs.Questions.SaveAnswer;

public class QuestionSaveAnswerResponseDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
    public static QuestionSaveAnswerResponseDto Create(Answer answer)
    {
        return new QuestionSaveAnswerResponseDto
        {
            IsCorrect= answer.IsCorrect,
            Text = answer.Text,
            Id= answer.Id
        };
    }
}
