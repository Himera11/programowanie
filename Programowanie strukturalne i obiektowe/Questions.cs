using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_quiz
{
    internal class Questions
    {
        public string Question { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswerID { get; set; }
        public int? SelectedAnswerId {get; set; }

        public Questions(string question, string [] answers, int correctAnswerID, int? selectedAnswer)
        {
            Question = question;
            Answers = answers;
            CorrectAnswerID = correctAnswerID;
            SelectedAnswerId = selectedAnswer;
        }
    }
}
