using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Questions.GetAll
{
    public class QuestionResponseDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid QuestionSetId { get; set; }
        public byte Point { get; set; }
    }
}
