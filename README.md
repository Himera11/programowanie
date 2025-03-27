using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizDatabaseClassLibrary;
using QuizDatabaseClassLibrary.Models;

namespace zadanie_quiz
{
    public class Viewmodel : BindableObject
    {
        private readonly QuizDBContext dbContext;
        private string resultShow;
        public string ResultShow
        {
            get { return resultShow; }
            set { resultShow = value; OnPropertyChanged(); }
        }

        private bool selectedAnswerId1;
        public bool SelectedAnswerId1
        {
            get { return selectedAnswerId1; }
            set
            {
                selectedAnswerId1 = value;
                SaveAnswer(0);
                OnPropertyChanged();
            }
        }

        private bool selectedAnswerId2;
        public bool SelectedAnswerId2
        {
            get { return selectedAnswerId2; }
            set
            {
                selectedAnswerId2 = value;
                SaveAnswer(1);
                OnPropertyChanged();
            }
        }

        private bool selectedAnswerId3;
        public bool SelectedAnswerId3
        {
            get { return selectedAnswerId3; }
            set
            {
                selectedAnswerId3 = value;
                SaveAnswer(2);
                OnPropertyChanged();
            }
        }

        private bool selectedAnswerId4;
        public bool SelectedAnswerId4
        {
            get { return selectedAnswerId4; }
            set
            {
                selectedAnswerId4 = value;
                SaveAnswer(3);
                OnPropertyChanged();
            }
        }

        private List<Answer> currentAnswers;
        public List<Answer> CurrentAnswers
        {
            get { return currentAnswers; }
            set { currentAnswers = value; OnPropertyChanged(); }
        }

        private string questionText;
        public string QuestionText
        {
            get { return questionText; }
            set { questionText = value; OnPropertyChanged(); }
        }

        private int currentQuestionIndex;
        public int CurrentQuestionIndex
        {
            get { return currentQuestionIndex; }
            set { currentQuestionIndex = value; OnPropertyChanged(); }
        }

        private int totalQuestions;

        public Command SubmitCommand { get; }
        public Command PrevQuestionCommand { get; }
        public Command NextQuestionCommand { get; }
        public Command ResetCommand { get; }

        int score = 0;

        public Viewmodel()
        {
            dbContext = new QuizDBContext();
            SubmitCommand = new Command(Submit);
            NextQuestionCommand = new Command(NextQuestion);
            PrevQuestionCommand = new Command(PrevQuestion);
            ResetCommand = new Command(Reset);

            LoadQuestionsFromDatabase();
        }

        public void LoadQuestionsFromDatabase()
        {
            totalQuestions = dbContext.Questions.Count();
            CurrentQuestionIndex = 0;
            ResetUserAnswers();
            LoadQuestion();
        }

        public void LoadQuestion()
        {
            var currentQuestion = dbContext.Questions
                .Include(q => q.Answers)
                .OrderBy(q => q.Id)
                .Skip(CurrentQuestionIndex)
                .FirstOrDefault();

            if (currentQuestion != null)
            {
                QuestionText = currentQuestion.QuestionText;
                CurrentAnswers = currentQuestion.Answers.ToList();

                var userAnswer = dbContext.Useranswers.FirstOrDefault(ua => ua.QuestionId == currentQuestion.Id);
                SetSelectedAnswer(userAnswer?.AnswerId);
            }
            else
            {
                QuestionText = "Brak pytania";
                CurrentAnswers = new List<Answer>();
            }
        }

        private void SetSelectedAnswer(int? selectedAnswerId)
        {
            SelectedAnswerId1 = selectedAnswerId == 0;
            SelectedAnswerId2 = selectedAnswerId == 1;
            SelectedAnswerId3 = selectedAnswerId == 2;
            SelectedAnswerId4 = selectedAnswerId == 3;
        }

        public void NextQuestion()
        {
            if (CurrentQuestionIndex < totalQuestions - 1)
            {
                CurrentQuestionIndex++;
                LoadQuestion();
            }
        }

        public void PrevQuestion()
        {
            if (CurrentQuestionIndex > 0)
            {
                CurrentQuestionIndex--;
                LoadQuestion();
            }
        }

        public void Reset()
        {
            ResetUserAnswers();
            CurrentQuestionIndex = 0;
            score = 0;
            ResultShow = "";
            LoadQuestion();
        }

        private void ResetUserAnswers()
        {
            dbContext.Useranswers.RemoveRange(dbContext.Useranswers);
            dbContext.SaveChanges();
        }

        public void Submit()
        {
            ResultShow = $"Wynik {CalculateScore()}";
        }

        public int CalculateScore()
        {
            score = 0;
            var userAnswers = dbContext.Useranswers.ToList();

            foreach (var ua in userAnswers)
            {
                var question = dbContext.Questions
                    .Include(q => q.Answers)
                    .FirstOrDefault(q => q.Id == ua.QuestionId);
                if (question != null)
                {
                    var correctAnswer = question.Answers.FirstOrDefault(a => a.IsCorrect);
                    if (correctAnswer != null && ua.AnswerId == correctAnswer.Id)
                    {
                        score++;
                    }
                }
            }
            return score;
        }

        public void SaveAnswer(int selectedAnswerIndex)
        {
            var currentQuestion = dbContext.Questions
                .Include(q => q.Answers)
                .OrderBy(q => q.Id)
                .Skip(CurrentQuestionIndex)
                .FirstOrDefault();

            if (currentQuestion == null)
                return;

            if (selectedAnswerIndex >= 0)
            {
                var selectedAnswer = currentQuestion.Answers.OrderBy(a => a.Id).ElementAt(selectedAnswerIndex);

                var userAnswer = dbContext.Useranswers.FirstOrDefault(ua => ua.QuestionId == currentQuestion.Id);
                if (userAnswer == null)
                {
                    userAnswer = new Useranswer
                    {
                        QuestionId = currentQuestion.Id,
                        AnswerId = selectedAnswer.Id
                    };
                    dbContext.Useranswers.Add(userAnswer);
                }
                else
                {
                    userAnswer.AnswerId = selectedAnswer.Id;
                    dbContext.Useranswers.Update(userAnswer);
                }
                dbContext.SaveChanges();
            }
        }
    }
}
