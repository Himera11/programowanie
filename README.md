CREATE DATABASE QuizDB;
USE QuizDB;

-- Tabela pytań
CREATE TABLE Questions (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    QuestionText VARCHAR(500) NOT NULL
);

-- Tabela odpowiedzi
CREATE TABLE Answers (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    QuestionId INT NOT NULL,
    AnswerText VARCHAR(255) NOT NULL,
    IsCorrect BOOLEAN NOT NULL,
    FOREIGN KEY (QuestionId) REFERENCES Questions(Id) ON DELETE CASCADE
);

-- Tabela odpowiedzi użytkownika
CREATE TABLE UserAnswers (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    QuestionId INT NOT NULL,
    AnswerId INT NULL,
    FOREIGN KEY (QuestionId) REFERENCES Questions(Id) ON DELETE CASCADE,
    FOREIGN KEY (AnswerId) REFERENCES Answers(Id) ON DELETE SET NULL
);

-- Dodanie przykładowych pytań
INSERT INTO Questions (QuestionText) VALUES 
('Ile wynosi 2 + 2?'),
('Jaka jest stolica Francji?'),
('Który język programowania jest używany w .NET?');

-- Dodanie odpowiedzi do pytań
INSERT INTO Answers (QuestionId, AnswerText, IsCorrect) VALUES
-- Pytanie 1
(1, '3', FALSE),
(1, '4', TRUE),
(1, '5', FALSE),
(1, '6', FALSE),

-- Pytanie 2
(2, 'Berlin', FALSE),
(2, 'Madryt', FALSE),
(2, 'Paryż', TRUE),
(2, 'Londyn', FALSE),

-- Pytanie 3
(3, 'Java', FALSE),
(3, 'Python', FALSE),
(3, 'C#', TRUE),
(3, 'PHP', FALSE);