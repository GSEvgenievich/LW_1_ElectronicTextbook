using System;
using System.Collections.Generic;

namespace ServiceLayer.Models;

public partial class Answer
{
    public int AnswerId { get; set; }

    public string AnswerText { get; set; } = null!;

    public int QuestionId { get; set; }

    public virtual Question Question { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
