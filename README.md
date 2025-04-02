using System;

class Program { static void Main() { Console.Write("Podaj numer PESEL: "); string pesel = Console.ReadLine();

if (IsValidPesel(pesel))
    {
        (int day, int month, int year) = GetBirthDateFromPesel(pesel);
        int age = CalculateAge(year);
        string gender = GetGenderFromPesel(pesel);
        
        Console.WriteLine($"Data urodzenia: {day:D2}-{month:D2}-{year}");
        Console.WriteLine($"Wiek: {age}");
        Console.WriteLine($"Płeć: {gender}");
    }
    else
    {
        Console.WriteLine("Niepoprawny numer PESEL.");
    }
}

static bool IsValidPesel(string pesel)
{
    if (pesel.Length != 11 || !long.TryParse(pesel, out _))
        return false;
    
    return ValidateControlNumber(pesel);
}

static bool ValidateControlNumber(string pesel)
{
    int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
    int sum = 0;
    
    for (int i = 0; i < 10; i++)
    {
        sum += (pesel[i] - '0') * weights[i];
    }
    
    int controlDigit = (10 - (sum % 10)) % 10;
    
    return controlDigit == (pesel[10] - '0');
}

static (int day, int month, int year) GetBirthDateFromPesel(string pesel)
{
    int year = int.Parse(pesel.Substring(0, 2));
    int month = int.Parse(pesel.Substring(2, 2));
    int day = int.Parse(pesel.Substring(4, 2));
    
    if (month > 80 && month < 93) { year += 1800; month -= 80; }
    else if (month > 0 && month < 13) { year += 1900; }
    else if (month > 20 && month < 33) { year += 2000; month -= 20; }
    else if (month > 40 && month < 53) { year += 2100; month -= 40; }
    else if (month > 60 && month < 73) { year += 2200; month -= 60; }
    else { throw new ArgumentException("Niepoprawny miesiąc w PESEL"); }
    
    return (day, month, year);
}

static int CalculateAge(int birthYear)
{
    int currentYear = DateTime.Now.Year;
    return currentYear - birthYear;
}

static string GetGenderFromPesel(string pesel)
{
    return (int.Parse(pesel[9].ToString()) % 2 == 0) ? "Kobieta" : "Mężczyzna";
}

}

