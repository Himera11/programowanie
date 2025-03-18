P

-- Tabela przechowująca pytania i odpowiedzi CREATE TABLE Questions ( Id INT AUTO_INCREMENT PRIMARY KEY, QuestionText VARCHAR(500) NOT NULL, Answer1 VARCHAR(255) NOT NULL, Answer2 VARCHAR(255) NOT NULL, Answer3 VARCHAR(255) NOT NULL, Answer4 VARCHAR(255) NOT NULL, CorrectAnswerId INT NOT NULL CHECK (CorrectAnswerId BETWEEN 0 AND 3) );

-- Tabela przechowująca wybrane odpowiedzi użytkowników CREATE TABLE UserAnswers ( Id INT AUTO_INCREMENT PRIMARY KEY, QuestionId INT NOT NULL, SelectedAnswerId INT NULL CHECK (SelectedAnswerId BETWEEN 0 AND 3), FOREIGN KEY (QuestionId) REFERENCES Questions(Id) ON DELETE CASCADE );

-- Przykładowe pytania do testów INSERT INTO Questions (QuestionText, Answer1, Answer2, Answer3, Answer4, CorrectAnswerId) VALUES ('Ile wynosi 2 + 2?', '3', '4', '5', '6', 1), ('Jaka jest stolica Francji?', 'Berlin', 'Madryt', 'Paryż', 'Londyn', 2), ('Który język programowania jest używany w .NET?', 'Java', 'Python', 'C#', 'PHP', 2);

