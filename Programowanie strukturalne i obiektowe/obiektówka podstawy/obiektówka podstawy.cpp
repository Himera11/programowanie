
#include <iostream>
using namespace std;
class Point
{
public:

	double calculatedDistance()
	{
		double distance = sqrt(x * x + y * y);
		return distance;
	}

	void Setx(int x)
	{
		// zak�adamy �e jeste�jmy w 1 �wiartce uk�adu xy
		if (x >= 0)
			this->x = x;
	}

	void Sety(int y)
	{
		// zak�adamy �e jeste�jmy w 1 �wiartce uk�adu xy
		if (y >= 0)
			this->y = y;
	}

private:
	float x;
	float y;

};


int main()
{
	Point point;
	point.Setx(3);
	point.Sety(4);
	cout << "Dystans od punktu (0,0) wynosi: " << point.calculatedDistance() << endl;

}




