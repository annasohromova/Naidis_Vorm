using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naidis_Vorm
{
    class Triangle
    {

        public double a;
        public double b;
        public double c;
        private string type;

        public Triangle(double A, double B, double C)
        {
            a = A;
            b = B;
            c = C;
            type = "määramata";
            if(a == b && b == c)
            {
                type = "Võrdpoolne";
            }
            else if(a == b || b == c || c == a)
            {
                type = "võrdhaarne";
            }
            //else(a > b && c > a && b > c)
            //{
             //   type = "";
            //}
        }
        public string TriangleType
        {
            get { return type; }
            set { type = value; }
        }
        public double CalculateSemiPerimeter()
        {
            return (a + b + c) / 2;
        }
        public string outputA()
        { 
            return Convert.ToString(a); 
        }
        public string outputB()
        {
            return Convert.ToString(b);
        }
        public string outputC()
        {
            return Convert.ToString(c);
        }
        public double Perimeter()
        {
            double p = 0;
            p = a + b + c;
            return p;
        }
        public double Surface()
        {
            double s = 0;
            double p = 0;
            p = (a + b + c) / 2;
            s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            return s;
        }
        public double GetSetA
        {
            get
            { return a; }
            set
            { a = value; }
        }
        public double GetSetB
        {
            get 
            { return b; }
            set 
            { b = value; }
        }
        public double GetSetC
        {
            get
            { return c; }
            set
            { c = value; }
        }
        public bool ExistTriangle
        {
            get
            {
                if ((a < b + c) && (b < a + c) && (c < a + b))
                    return false;
                else return true;
            }
        }

    }
}

