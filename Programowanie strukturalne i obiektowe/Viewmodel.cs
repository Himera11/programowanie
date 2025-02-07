using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie_quiz
{
    internal class Viewmodel : BindableObject
    {
        private string resultShow;
        public string ResultShow
        {
            get { return resultShow; }
            set { resultShow = value; OnPropertyChanged(); }
        }

        /*private int ?selectedAnswerId;
        public int ?SelectedAnswerId
        {
            get { return selectedAnswerId; }
            set { selectedAnswerId = value;
                OnPropertyChanged();
                SaveAnswer(value);
            }
        }*/
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


        public List<Questions> questions = new List<Questions>
{
    new Questions("Pytanie 1", new string[] {"1", "2", "3", "4"}, 1, null),
    new Questions("Pytanie 2", new string[] {"1", "2", "3", "0"}, 0, null),
    new Questions("Pytanie 3", new string[] {"1", "2", "3", "2"}, 3, null)
};

        private int currentquestionID;
        public int CurrentQuestionID
        {
            get { return currentquestionID; }
            set { currentquestionID = value; OnPropertyChanged(); }
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
        public Viewmodel()
        {
            LoadQuestion();
            SubmitCommand = new Command(Submit);
            NextQuestionCommand = new Command(NextQuestion);
            PrevQuestionCommand = new Command(PrevQuestion);
            ResetCommand = new Command(Reset);
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
            else
            {
                LoadQuestion();
            }
        }
        public void LoadQuestion()
        {
            var currentquestion = questions[CurrentQuestionID];
            QuestionText = currentquestion.Question;
            CurrentAnswers = currentquestion.Answers.ToList();
            if (currentquestion.SelectedAnswerId == 0)
            {
                SelectedAnswerId1 = true;
                SelectedAnswerId2 = false;
                SelectedAnswerId3 = false;
                SelectedAnswerId4 = false;
            }
            if (currentquestion.SelectedAnswerId == 1)
            {
                SelectedAnswerId1 = false;
                SelectedAnswerId2 = true;
                SelectedAnswerId3 = false;
                SelectedAnswerId4 = false;
            }
            if (currentquestion.SelectedAnswerId == 2)
            {
                SelectedAnswerId1 = false;
                SelectedAnswerId2 = false;
                SelectedAnswerId3 = true;
                SelectedAnswerId4 = false;
            }
            if (currentquestion.SelectedAnswerId == 3)
            {
                SelectedAnswerId1 = false;
                SelectedAnswerId2 = false;
                SelectedAnswerId3 = false;
                SelectedAnswerId4 = true;
            }
            if (currentquestion.SelectedAnswerId == null)
            {
                SelectedAnswerId1 = false;
                SelectedAnswerId2 = false;
                SelectedAnswerId3 = false;
                SelectedAnswerId4 = false;
            }


        }
        public void Reset()
        {
            var currentquestion = questions[CurrentQuestionID];
            foreach (var question in questions)
            {
                question.SelectedAnswerId = null;
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
                if (question.CorrectAnswerID == question.SelectedAnswerId)
                {
                    score++;
                }
            }
            return score;

            /*int score = 0;
                if (selectedAnswerId1 && 0 == questions[currentquestionID].CorrectAnswerID)
                {
                    score++;
                }
                if (selectedAnswerId2 && 1 == questions[currentquestionID].CorrectAnswerID)
                {
                    score++;
                }
                if (selectedAnswerId3 && 2 == questions[currentquestionID].CorrectAnswerID)
                {
                    score++;
                }
                if (selectedAnswerId4 && 3 == questions[currentquestionID].CorrectAnswerID)
                {
                    score++;
                }
                return score;*/
        }
        public void SaveAnswer()
        {
            var currentquestion = questions[CurrentQuestionID];

            if (selectedAnswerId1)
            {
                currentquestion.SelectedAnswerId = 0;
            }
            if (selectedAnswerId2)
            {
                currentquestion.SelectedAnswerId = 1;
            }
            if (selectedAnswerId3)
            {
                currentquestion.SelectedAnswerId = 2;
            }
            if (selectedAnswerId4)
            {
                currentquestion.SelectedAnswerId = 3;
            }
        }
    }
}
