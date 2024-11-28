using Models.Entities;

namespace Models.DTOs.Questions.GetById;

public class QuestionGetByIdResponseDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public string[] Answers { get; set; }

    public static QuestionGetByIdResponseDto Create(Question question)
    {
        return new QuestionGetByIdResponseDto
        {
            Id = question.Id,
            Text = question.Text,
            Answers = question.Answers.Select(x => x.Text).ToArray()
        };
    }
}