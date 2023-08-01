using Models.Entities;

namespace Models.DTOs.QuestionSets.Create;
using Models.Entities;
public class QuestionSetCreateResponseDto
{
    public Guid Id { get; set; }
    public string Subject { get; set; }

    public static QuestionSetCreateResponseDto Create(QuestionSet questionSet)
    {
        return new QuestionSetCreateResponseDto
        {
            Id = questionSet.Id,
            Subject = questionSet.Subject

        };
    }
}
