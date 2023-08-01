using Models.Entities;

namespace Models.DTOs.Questions.Create;

public class QuestionCreateResponseDto
{
    public Guid Id { get; set; }
    public byte Point { get; set; }
    public string Text { get; set; }

    public static QuestionCreateResponseDto Create(Question question)
    {
        return new QuestionCreateResponseDto
        {
            Id= question.Id,
            Point = question.Point,
            Text = question.Text,

        };
    } 
}
