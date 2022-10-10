#include <iostream>
using namespace std;

struct Point
{
	float x;
	float y;
};

double calculatedDistance(float a, float b)
{
	double distance = sqrt(a * a + b * b);
	return distance;
}

double calculatedDistance(Point p)
{
	double distance = sqrt(p.x * p.x + p.y * p.y);
	return distance;
}

void coordinateTestV1()
{
	
	//Point point;
	float x, y;
	cout << "podaj x\n";
	cin >> x;
	cout << "podaj y\n";
	cin >> y;
	//double d = sqrt(x*x + y*y);
	double distance = calculatedDistance(x, y);
	cout << "odleglosc od (0,0) wynosi " << distance;
}

void coordinateTestV2()
{
	Point point;
	cout << "podaj x\n";
	cin >> point.x;
	cout << "podaj y\n";
	cin >> point.y;
	//double d = sqrt(x*x + y*y);
	double distance = calculatedDistance(point.x, point.y);
	cout << "odleglosc od (0,0) wynosi " << distance;
}
/*
string name;
string tab;
int age;
int height;
*/
struct Person
{
	string name;
	string tab;
	int age;
	int height;
	Point coordinates;
};

Person p1;
//p1.name
//p1.coordinate.x

string nametab[5];
string surnametab[5];
int agetab[5];
int heighttab[5];

Person ptab[5];
//ptab[1].name = "Ala";
int main()
{
	//coordinateTestV1();
	coordinateTestV2();

}
