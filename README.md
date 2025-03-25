CREATE DATABASE QuizDB;
USE QuizDB;

CREATE TABLE Questions (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    QuestionText VARCHAR(500) NOT NULL
);

CREATE TABLE Answers (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    QuestionId INT NOT NULL,
    AnswerText VARCHAR(255) NOT NULL,
    IsCorrect BOOLEAN NOT NULL,
    FOREIGN KEY (QuestionId) REFERENCES Questions(Id) ON DELETE CASCADE
);

CREATE TABLE UserAnswers (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    QuestionId INT NOT NULL,
    AnswerId INT NULL,
    FOREIGN KEY (QuestionId) REFERENCES Questions(Id) ON DELETE CASCADE,
    FOREIGN KEY (AnswerId) REFERENCES Answers(Id) ON DELETE SET NULL
);

INSERT INTO Questions (QuestionText) VALUES 
('Ile wynosi 2 + 2?'),
('Jaka jest stolica Francji?'),
('Który język programowania jest używany w .NET?');

INSERT INTO Answers (QuestionId, AnswerText, IsCorrect) VALUES
(1, '3', FALSE),
(1, '4', TRUE),
(1, '5', FALSE),
(1, '6', FALSE),

(2, 'Berlin', FALSE),
(2, 'Madryt', FALSE),
(2, 'Paryż', TRUE),
(2, 'Londyn', FALSE),

(3, 'Java', FALSE),
(3, 'Python', FALSE),
(3, 'C#', TRUE),
(3, 'PHP', FALSE);






public class ViewModel : BindableObject
{
    private readonly QuizDbContext dbContext;
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

    private List<Question> questions = new List<Question>();
    private int currentQuestionIndex;

    public int CurrentQuestionIndex
    {
        get { return currentQuestionIndex; }
        set { currentQuestionIndex = value; OnPropertyChanged(); }
    }

    public Command SubmitCommand { get; }
    public Command PrevQuestionCommand { get; }
    public Command NextQuestionCommand { get; }
    public Command ResetCommand { get; }

    int score = 0;

    public ViewModel()
    {
        dbContext = new QuizDbContext();
        SubmitCommand = new Command(Submit);
        NextQuestionCommand = new Command(NextQuestion);
        PrevQuestionCommand = new Command(PrevQuestion);
        ResetCommand = new Command(Reset);

        LoadQuestionsFromDatabase();
    }

    public void LoadQuestionsFromDatabase()
    {
        questions = dbContext.Questions.Include(q => q.Answers).ToList();
        LoadQuestion();
    }

    public void LoadQuestion()
    {
        var currentQuestion = questions[CurrentQuestionIndex];
        QuestionText = currentQuestion.QuestionText;
        CurrentAnswers = currentQuestion.Answers.ToList();
        var userAnswer = dbContext.UserAnswers.FirstOrDefault(ua => ua.QuestionId == currentQuestion.Id);
        SetSelectedAnswer(userAnswer?.SelectedAnswerId);
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
        if (CurrentQuestionIndex < questions.Count - 1)
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
        dbContext.UserAnswers.RemoveRange(dbContext.UserAnswers);
        dbContext.SaveChanges();
        CurrentQuestionIndex = 0;
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
        var userAnswers = dbContext.UserAnswers.ToList();
        foreach (var question in questions)
        {
            var userAnswer = userAnswers.FirstOrDefault(ua => ua.QuestionId == question.Id);
            if (userAnswer != null && userAnswer.SelectedAnswerId == question.Answers.First(a => a.IsCorrect).Id)
            {
                score++;
            }
        }
        return score;
    }

    public void SaveAnswer(int selectedAnswerId)
    {
        var currentQuestion = questions[CurrentQuestionIndex];
        var userAnswer = dbContext.UserAnswers.FirstOrDefault(ua => ua.QuestionId == currentQuestion.Id);
        if (userAnswer == null)
        {
            userAnswer = new UserAnswer { QuestionId = currentQuestion.Id, SelectedAnswerId = selectedAnswerId };
            dbContext.UserAnswers.Add(userAnswer);
        }
        else
        {
            userAnswer.SelectedAnswerId = selectedAnswerId;
            dbContext.UserAnswers.Update(userAnswer);
        }
        dbContext.SaveChanges();
    }
}
