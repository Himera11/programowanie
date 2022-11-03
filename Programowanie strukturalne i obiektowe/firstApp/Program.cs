using System;

namespace firstApp
{
    class Rectangle
    {

        // member variables
        double length = 4.5;
        double width = 3.5;

        public double GetArea()
        {
            return length * width;
        }
        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            /*for(int i = 40; i < 400000; i++)
  {
      Console.Beep(i, 100);
  }

  Console.ReadLine();*/
            /*
            Console.WriteLine("Hello World!");

            short a;
            int b;
            double c;

            // actual initialization 
            a = 4;
            b = 20;
            c = a + b;
            Console.WriteLine("a = {0}, b = {1}, c = {2}", a, b, c);
            
            Console.ReadLine();
            */


            Rectangle r = new Rectangle();
            r.Display();

            Console.WriteLine("int: {0}", sizeof(int));

            dynamic a = 5, b = "lol";
            Console.WriteLine("dynamiczna: {0}, b = {1} ", a,b);

            double d = 5673.74;
            int i;

            // cast double to int.
            i = (int)d;
            Console.WriteLine(i);

            bool s = true;
            Console.WriteLine(s.ToString());

            Console.WriteLine("Hello\t\rWorld\b\n");

            //infinite loop
            /* for (; ; )
             {
                 Console.WriteLine("Hey! I am Trapped");
             }*/

            double number;
            double number1;
            double wynik;
            Console.WriteLine("Enter number1: ");
            number = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter number2: ");
            number1 = Convert.ToDouble(Console.ReadLine());

            wynik = number + number1;

            Console.WriteLine("number1 + number2 = {0}", wynik);

            if (wynik % 2 == 0)
            {
                Console.WriteLine("wynik jest parzysty");
            }
            else
            {
                Console.WriteLine("wynik jest nieparzysty");
            }

            Console.ReadLine();
        }   
    }
}
