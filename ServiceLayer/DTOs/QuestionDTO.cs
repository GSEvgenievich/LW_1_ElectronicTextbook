﻿using ServiceLayer.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ServiceLayer.DTOs
{
    public class QuestionDTO: INotifyPropertyChanged
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; } = null!;

        public int TestId { get; set; }

        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

        private Answer? _selectedAnswer;
        public Answer? SelectedAnswer
        {
            get => _selectedAnswer;
            set
            {
                if (_selectedAnswer != value)
                {
                    _selectedAnswer = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
