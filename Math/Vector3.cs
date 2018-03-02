// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;

namespace Sigon.Math
{
    public class Vector3
    {
        private double x;
        private double y;
        private double z;

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public Vector3()
        {
            X = Y = Z = 0.0d;        
        }

        public Vector3(double x, double y, double z)
        {
            X = x; Y = y; Z = z;
        }

        public static Vector3 operator+(Vector3 vector1, Vector3 vector2)
        {
            return new Vector3(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);
        }

        public static Vector3 operator-(Vector3 vector1,Vector3 vector2)
        {
            return new Vector3(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);
        }

        // Multiplication with factor
        public static Vector3 operator*(Vector3 vector, double factor)
        {
            return new Vector3(vector.X * factor, vector.Y * factor, vector.Z * factor);
        }

        // dot-product
        public static double operator*(Vector3 vector1, Vector3 vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
        }

        // ^-Operator is used for the cross-product of the Vector
        // (A, B, C) x (X, Y, Z) = (B*Z-C*Y, C*X-A*Z, A*Y-B*X)
        public static Vector3 operator ^(Vector3 vector1, Vector3 vector2)
        {
            return new Vector3(vector1.Y * vector2.Z - vector1.Z * vector2.Y, vector1.Z * vector2.X - vector1.X * vector2.Z, vector1.X * vector2.Y - vector1.Y * vector2.X);
        }

        public static Vector3 operator/(Vector3 vector, double divisor)
        {
            return new Vector3(vector.X / divisor, vector.Y / divisor, vector.Z / divisor);
        }
    
        public double Length()
        {
            return System.Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public void Normalize()
        {
            double factor;

            if (X != 0.0d || X != 0.0d || X != 0.0d)
            {
                factor = 1.0d / Length();

                X *= factor;
                Y *= factor;
                Z *= factor;
            }
        }

        // Set this Vector as the central point between two Vectors.
        public void Center(Vector3 vector1, Vector3 vector2)
        {
            X = (vector1.X + vector2.X) * 0.5d;
            Y = (vector1.Y + vector2.Y) * 0.5d;
            Z = (vector1.Z + vector2.Z) * 0.5d;
        }

        public void Invert()
        {
            X = -X;
            Y = -Y;
            Z = -Z;
        }

        // Rotate the Vector around the X-Axis.
        //  Matrix: |  1   0   0  |
        //          |  0  cos -sin|
        //          |  0  sin cos |
        public void RotateX(double angle)
        {
            double tmp;

            double sin = System.Math.Sin(angle);
            double cos = System.Math.Cos(angle);
        
            tmp = Y * cos + Z * (-sin);
            Z = Y * sin + Z * cos;
            Y = tmp;
        }
    }
}
