using System; using System.Globalization;

class Program { static void Main() { Console.Write("Podaj numer PESEL: "); string pesel = Console.ReadLine();

if (IsValidPesel(pesel))
    {
        DateTime birthDate = GetBirthDateFromPesel(pesel);
        int age = CalculateAge(birthDate);
        string gender = GetGenderFromPesel(pesel);
        
        Console.WriteLine($"Data urodzenia: {birthDate:dd-MM-yyyy}");
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

static DateTime GetBirthDateFromPesel(string pesel)
{
    string yearPart = pesel.Substring(0, 2);
    string monthPart = pesel.Substring(2, 2);
    string dayPart = pesel.Substring(4, 2);
    
    int year = int.Parse(yearPart);
    int month = int.Parse(monthPart);
    int day = int.Parse(dayPart);
    
    if (month > 80 && month < 93) { month -= 80; }
    else if (month > 0 && month < 13) { month = month; }
    else if (month > 20 && month < 33) { month += 20; }
    else if (month > 40 && month < 53) { month += 40; }
    else if (month > 60 && month < 73) { month += 60; }
    else { throw new ArgumentException("Niepoprawny miesiąc w PESEL"); }
    
    return new DateTime(year, month, day);
}

static int CalculateAge(DateTime birthDate)
{
    int age = DateTime.Now.Year - birthDate.Year;
    if (DateTime.Now < birthDate.AddYears(age))
    {
        age--;
    }
    return age;
}

static string GetGenderFromPesel(string pesel)
{
    return (int.Parse(pesel[9].ToString()) % 2 == 0) ? "Kobieta" : "Mężczyzna";
}

}

