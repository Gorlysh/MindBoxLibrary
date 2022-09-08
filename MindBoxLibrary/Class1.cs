using System;
using System.Collections.Generic;

namespace MindBoxLibrary
{
    public class Figure
    {
        public List<double> a = new List<double>(); //стороны треугольника либо радиус круга в нулевом элементе
        public byte type; // тип фингуры 0-треугольник, 1-круг (в дальнейшем можно добавлять фигуры)
        public bool rectangular; // true- прямоугольный треугольник, false - обычный

        public Figure(double arg1, double arg2, double arg3) // конструктор для треугольника
        {
            if (arg1!=0 && arg2 != 0 && arg3 != 0)
            {
                a.Clear();
                type = 0;
                a.Add(arg1);
                a.Add(arg2);
                a.Add(arg3);
            }

            a.Sort();
            if (Math.Pow(a[2],2) == Math.Pow(a[0], 2) + Math.Pow(a[1], 2)) //пароверка является ли треугольник прямоугольным
            {
                rectangular = true; 
            } else rectangular = false;

        }

        public Figure(int arg1) // конструктор для круга
        {
            if (arg1 != 0)
            {
                a.Clear();
                type = 1;
                a.Add(arg1);
            }

        }


        public double Area()
        {
            switch (type)
            {
                case 0: // площадь треугольника
                    if (rectangular == true)
                    {
                        return 0.5 * a[1] * a[2]; //площадь прямоугольного треугольника
                    }
                    else
                    {
                        double p = (a[0] + a[1] + a[2]) / 2.0; //полупериметр треугольника
                        return Math.Sqrt(p * (p - a[0]) * (p - a[1]) * (p - a[2])); // находим площадь по формуле Герона 
                    }

                case 1: // площадь круга
                    return Math.PI * Math.Pow(a[0], 2); // находим площадь круга
            }

            return 0;
            
        }
    }
}
