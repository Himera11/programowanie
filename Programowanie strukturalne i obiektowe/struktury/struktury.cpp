#include <iostream>
using namespace std;

struct Point
{
	int x;
	int y;
};

double calculatedDistance(int a, int b)
{
	double distance = sqrt(a * a + b * b);
	return distance;
}
void coordinateTestV1()
{
	
	//Point point;
	int x, y;
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

int main()
{
	//coordinateTestV1();
	coordinateTestV2();

}
