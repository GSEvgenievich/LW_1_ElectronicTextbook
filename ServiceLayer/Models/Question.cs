using System;
using System.Collections.Generic;

namespace ServiceLayer.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public string QuestionText { get; set; } = null!;

    public int TestId { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Test Test { get; set; } = null!;

    public virtual ICollection<Answer> AnswersNavigation { get; set; } = new List<Answer>();
}
