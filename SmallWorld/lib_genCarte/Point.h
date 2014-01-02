#include <iostream>
#include <math.h>

using namespace std;

// Class to represent points.
class Point {
private:
        double xval, yval;
public:
        // Constructor uses default arguments to allow calling with zero, one,
        // or two values.
        Point(double x = 0.0, double y = 0.0) {
                xval = x;
                yval = y;
        }

        // Extractors.
        double x() { return xval; }
        double y() { return yval; }

        // Distance to another point.  Pythagorean thm.
        double dist(Point other) {
                double xd = xval - other.xval;
                double yd = yval - other.yval;
                return sqrt(xd*xd + yd*yd);
        }

        // Add or subtract two points.
        Point operator+(Point b)
        {
                return Point(xval + b.xval, yval + b.yval);
        }
        Point operator-(Point b)
        {
                return Point(xval - b.xval, yval - b.yval);
        }

        // Move the existing point.
        void move(double a, double b)
        {
                xval += a;
                yval += b;
        }

        // Print the point on the stream.  The class ostream is a base class
        // for output streams of various types.
        void print(ostream &strm)
        {
                strm << "(" << xval << "," << yval << ")";
        }
};

// Print a line of the form x op y = z, where x, y, and z are points. 
void prline(ostream &strm, Point x, char *op, Point y, Point z)
{
        x.print(strm);
        cout << " " << op << " ";
        y.print(strm);
        cout << " = ";
        z.print(strm);
        cout << endl;
}