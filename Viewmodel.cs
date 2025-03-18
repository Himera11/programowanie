using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Models;
using ClassLibrary;

namespace MauiApp1
{
    class Viewmodel
    {
        public class ViewModel : BindableObject
        {
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
                    SaveAnswer();
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
                    SaveAnswer();
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
                    SaveAnswer();
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
                    SaveAnswer();
                    OnPropertyChanged();
                }
            }

            private List<string> currentAnswers;
            public List<string> CurrentAnswers
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

            private List<Question> questions = new List<Question>(); 
            private int currentQuestionId;
            public int CurrentQuestionID
            {
                get { return currentQuestionId; }
                set { currentQuestionId = value; OnPropertyChanged(); }
            }

            private Command submitCommand;
            public Command SubmitCommand
            {
                get { return submitCommand; }
                set { submitCommand = value; }
            }

            private Command prevQuestionCommand;
            public Command PrevQuestionCommand
            {
                get { return prevQuestionCommand; }
                set { prevQuestionCommand = value; }
            }

            private Command nextQuestionCommand;
            public Command NextQuestionCommand
            {
                get { return nextQuestionCommand; }
                set { nextQuestionCommand = value; }
            }

            private Command resetCommand;
            public Command ResetCommand
            {
                get { return resetCommand; }
                set { resetCommand = value; }
            }

            int score = 0;

            public ViewModel()
            {
                SubmitCommand = new Command(Submit);
                NextQuestionCommand = new Command(NextQuestion);
                PrevQuestionCommand = new Command(PrevQuestion);
                ResetCommand = new Command(Reset);

                LoadQuestionsFromDatabase();
            }

            public void LoadQuestionsFromDatabase()
            {
                using (var dbContext = new QuizDbContext())
                {
                    questions = dbContext.Questions.ToList();
                }
                LoadQuestion();
            }

            public void LoadQuestion()
            {
                var currentQuestion = questions[CurrentQuestionID];
                QuestionText = currentQuestion.QuestionText;
                CurrentAnswers = new List<string>
        {
            currentQuestion.Answer1,
            currentQuestion.Answer2,
            currentQuestion.Answer3,
            currentQuestion.Answer4
        };

                // Przywrócenie zaznaczonej odpowiedzi
                if (currentQuestion.SelectedAnswerId == 0)
                {
                    SelectedAnswerId1 = true;
                    SelectedAnswerId2 = false;
                    SelectedAnswerId3 = false;
                    SelectedAnswerId4 = false;
                }
                else if (currentQuestion.SelectedAnswerId == 1)
                {
                    SelectedAnswerId1 = false;
                    SelectedAnswerId2 = true;
                    SelectedAnswerId3 = false;
                    SelectedAnswerId4 = false;
                }
                else if (currentQuestion.SelectedAnswerId == 2)
                {
                    SelectedAnswerId1 = false;
                    SelectedAnswerId2 = false;
                    SelectedAnswerId3 = true;
                    SelectedAnswerId4 = false;
                }
                else if (currentQuestion.SelectedAnswerId == 3)
                {
                    SelectedAnswerId1 = false;
                    SelectedAnswerId2 = false;
                    SelectedAnswerId3 = false;
                    SelectedAnswerId4 = true;
                }
                else
                {
                    SelectedAnswerId1 = false;
                    SelectedAnswerId2 = false;
                    SelectedAnswerId3 = false;
                    SelectedAnswerId4 = false;
                }
            }

            public void NextQuestion()
            {
                if (CurrentQuestionID < questions.Count - 1)
                {
                    CurrentQuestionID++;
                    LoadQuestion();
                }
                else
                {
                    QuestionText = "Naciśnij Sprawdź";
                }
            }

            public void PrevQuestion()
            {
                if (CurrentQuestionID > 0)
                {
                    CurrentQuestionID--;
                    LoadQuestion();
                }
            }

            public void Reset()
            {
                foreach (var question in questions)
                {
                    question.SelectedAnswerId = null; // Resetujemy odpowiedzi w bazie
                }
                CurrentQuestionID = 0;
                score = 0;
                ResultShow = "";
                LoadQuestion();
            }

            public void Submit()
            {
                ResultShow = $"Wynik {CalculateScore()}";
            }

            public int CalculateScore()
            {
                score = 0;
                foreach (var question in questions)
                {
                    if (question.CorrectAnswerId == question.SelectedAnswerId)
                    {
                        score++;
                    }
                }
                return score;
            }

            public void SaveAnswer()
            {
                var currentQuestion = questions[CurrentQuestionID];

                if (selectedAnswerId1)
                {
                    currentQuestion.SelectedAnswerId = 0;
                }
                else if (selectedAnswerId2)
                {
                    currentQuestion.SelectedAnswerId = 1;
                }
                else if (selectedAnswerId3)
                {
                    currentQuestion.SelectedAnswerId = 2;
                }
                else if (selectedAnswerId4)
                {
                    currentQuestion.SelectedAnswerId = 3;
                }

                // Zapisujemy odpowiedź do bazy danych
                using (var dbContext = new QuizDbContext())
                {
                    dbContext.Update(currentQuestion);
                    dbContext.SaveChanges();
                }
            }
        }

    }
}
