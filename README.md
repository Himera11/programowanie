CREATE DATABASE ElearningDB; USE ElearningDB;

-- Tabela użytkowników (tylko uczniowie) CREATE TABLE Uzytkownicy ( UzytkownikID INT AUTO_INCREMENT PRIMARY KEY, Email VARCHAR(255) UNIQUE NOT NULL, Imie VARCHAR(100) NOT NULL, Nazwisko VARCHAR(100) NOT NULL, DataUrodzenia DATE NOT NULL ) ENGINE=InnoDB;

-- Tabela instruktorów (oddzielna od użytkowników) CREATE TABLE Instruktorzy ( InstruktorID INT AUTO_INCREMENT PRIMARY KEY, Email VARCHAR(255) UNIQUE NOT NULL, Imie VARCHAR(100) NOT NULL, Nazwisko VARCHAR(100) NOT NULL, Specjalizacja VARCHAR(255) ) ENGINE=InnoDB;

-- Tabela kursów CREATE TABLE Kursy ( KursID INT AUTO_INCREMENT PRIMARY KEY, Tytul VARCHAR(255) NOT NULL ) ENGINE=InnoDB;

-- Tabela pośrednia: wielu instruktorów do wielu kursów CREATE TABLE Instruktorzy_Kursy ( InstruktorID INT NOT NULL, KursID INT NOT NULL, PRIMARY KEY (InstruktorID, KursID), FOREIGN KEY (InstruktorID) REFERENCES Instruktorzy(InstruktorID) ON DELETE CASCADE, FOREIGN KEY (KursID) REFERENCES Kursy(KursID) ON DELETE CASCADE ) ENGINE=InnoDB;

-- Tabela lekcji CREATE TABLE Lekcje ( LekcjaID INT AUTO_INCREMENT PRIMARY KEY, KursID INT NOT NULL, Tytul VARCHAR(255) NOT NULL, FOREIGN KEY (KursID) REFERENCES Kursy(KursID) ON DELETE CASCADE ) ENGINE=InnoDB;

-- Tabela zapisów uczniów na kursy CREATE TABLE Zapisy ( ZapisID INT AUTO_INCREMENT PRIMARY KEY, UzytkownikID INT NOT NULL, KursID INT NOT NULL, FOREIGN KEY (UzytkownikID) REFERENCES Uzytkownicy(UzytkownikID) ON DELETE CASCADE, FOREIGN KEY (KursID) REFERENCES Kursy(KursID) ON DELETE CASCADE ) ENGINE=InnoDB;

-- Tabela pośrednia: uczeń może być przypisany do wielu lekcji CREATE TABLE Uczniowie_Lekcje ( UzytkownikID INT NOT NULL, LekcjaID INT NOT NULL, PRIMARY KEY (UzytkownikID, LekcjaID), FOREIGN KEY (UzytkownikID) REFERENCES Uzytkownicy(UzytkownikID) ON DELETE CASCADE, FOREIGN KEY (LekcjaID) REFERENCES Lekcje(LekcjaID) ON DELETE CASCADE ) ENGINE=InnoDB;

Jakie sa tu relacje

