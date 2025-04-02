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
    return pesel.Length == 11 && long.TryParse(pesel, out _);
}

static DateTime GetBirthDateFromPesel(string pesel)
{
    int year = int.Parse(pesel.Substring(0, 2));
    int month = int.Parse(pesel.Substring(2, 2));
    int day = int.Parse(pesel.Substring(4, 2));

    int century = month / 20;
    month %= 20;

    year += century switch
    {
        0 => 1900,
        1 => 2000,
        2 => 2100,
        3 => 2200,
        4 => 1800,
        _ => throw new ArgumentException("Niepoprawny PESEL")
    };
    
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


