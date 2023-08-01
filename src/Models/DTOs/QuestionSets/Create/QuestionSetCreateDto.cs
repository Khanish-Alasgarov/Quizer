using Models.Entities;
namespace Models.DTOs.QuestionSets.Create;

public class QuestionSetCreateDto
{
    public string Subject { get; set; }

    public QuestionSet ToEntity()
    {
        return new QuestionSet
        {
            Id = Guid.NewGuid(),
            Subject = Subject
        };
    }
}
