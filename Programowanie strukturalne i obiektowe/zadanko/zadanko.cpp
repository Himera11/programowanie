#include <iostream>
#include <ctime>
using namespace std;

int currenttime()
{
	time_t now = time(0);
	tm* ltm = new tm;
	localtime_s(ltm, &now);
	return 1900 + ltm->tm_year;
}

class Person
{
public:

	Person(string name)
	{
		this->name = name;
	}

	Person(string name, string rank, int iq)
	{
		this->name = name;
		this->rank = rank;
		this->iq = iq;
	}


	Person(string name, int weight, int Birthday, string sex, int height, string rank, int iq)
	{
		this->name = name;
		this->weight = weight;
		this->Birthday = Birthday;
		this->sex = sex;
		this->height = height;
		this->rank = rank;
		this->iq = iq;
	}

	void showinfo()
	{
		cout << "*********************************\n";
		cout << "imie i nazwisko " << name << '\n';
		if (weight >= 200)
		{
			cout << "jestes zbyt gruby xD w cb" << '\n';
		}
		else
		{
			cout << "waga " << weight << '\n';
		}

		cout << "data urodzenia " << Birthday << '\n';
		cout << "plec " << sex << '\n';
		cout << "wiek  " << currenttime() - Birthday << '\n';
		cout << "wielkosc " << height << '\n';
		cout << "rank " << rank << '\n';
		cout << "poziom iq " << iq << '\n';
		cout << "*********************************\n";
	}

	void majurity()
	{
		int year;
		cout << "podaj rok urodzenia:" << endl;
		cin >> year;
		if (currenttime() - year >= 18)
			cout << "adult";
		else
		{
			cout << "not adult";
		}
	}

	
protected:

private:
	string name;
	string sex = "mezczyzna";
	int weight = 25;
	int Birthday = 2000;
	int height = 70;
	string rank = "iron_4";
	int iq = 0;
};



int main()
{
	Person person1("Joe Biden.Jr", "brozne_1", 100);

	int liczba;
	cout << "wybierz funkcje - 1_dorosly : 2_info  -  ";
	cin >> liczba;
	
	if (liczba == 1)
	{
		person1.majurity();
	}
	if (liczba == 2)
	{
		person1.showinfo();
	}

	//person1.showinfo();
	//person1.majurity();
}
