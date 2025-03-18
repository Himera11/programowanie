# klasa-1c-2021-202
CREATE DATABASE QuizDB;
USE QuizDB;

CREATE TABLE Questions (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    QuestionText VARCHAR(500) NOT NULL,
    Answer1 VARCHAR(255) NOT NULL,
    Answer2 VARCHAR(255) NOT NULL,
    Answer3 VARCHAR(255) NOT NULL,
    Answer4 VARCHAR(255) NOT NULL,
    CorrectAnswerId INT NOT NULL CHECK (CorrectAnswerId BETWEEN 0 AND 3),
    SelectedAnswerId INT NULL CHECK (SelectedAnswerId BETWEEN 0 AND 3)
);

-- Przykładowe pytania do testów
INSERT INTO Questions (QuestionText, Answer1, Answer2, Answer3, Answer4, CorrectAnswerId, SelectedAnswerId)
VALUES 
('Ile wynosi 2 + 2?', '3', '4', '5', '6', 1, NULL),
('Jaka jest stolica Francji?', 'Berlin', 'Madryt', 'Paryż', 'Londyn', 2, NULL),
('Który język programowania jest używany w .NET?', 'Java', 'Python', 'C#', 'PHP', 2, NULL);