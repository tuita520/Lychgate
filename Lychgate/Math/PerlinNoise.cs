// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;
using OpenTK;

namespace Sigon.Lychgate.Math
{
    /// <summary>
    /// Implements a Perlin-Noise Algorithm.
    /// </summary>
    public class PerlinNoise
    {
        private int seed;
        /// <summary>
        /// 
        /// </summary>
        public int Seed { get { return seed; } set { seed = value; } }

        private int depth;
        /// <summary>
        /// 
        /// </summary>
        public int Depth { get { return depth; } set { depth = value; } }

        private double add;
        /// <summary>
        /// 
        /// </summary>
        public double Add { get { return add; } set { add = value; } }

        private double amplitude;
        /// <summary>
        /// 
        /// </summary>
        public double Amplitude { get { return amplitude; } set { amplitude = value; } }

        private double persistence;
        /// <summary>
        /// 
        /// </summary>
        public double Persistence { get { return persistence; } set { persistence = value; } }

        /// <summary>
        /// 
        /// </summary>
        public PerlinNoise()
        {
            Seed = 0;
            Depth = 5;

            Add = 0.0d;
            Amplitude = 1.0d;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void SetAmplitude(double min, double max)
        {
            Add = min;
            Amplitude = max;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Create()
        {
            double range;
            double summarizedMultiplier;
            double multiplier;

            range = Amplitude - Add;
            Add += range * 0.5d;

            // We get values between -1 and 1 out of the Rand function
            summarizedMultiplier = 0.0d;
            multiplier = 2.0d;

            for (int i = 0; i < Depth; ++i)
            {
                summarizedMultiplier += multiplier;
                multiplier *= Persistence;
            }

            Amplitude = range / summarizedMultiplier;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double GetValue(double x, double y)
        {
            double total = 0;
            double ampl = Amplitude;

            for (int i = 0; i < Depth; ++i)
            {
                //   total += InterpolatedRand(x, y) * ampl;
                ampl *= Persistence;

                x *= 2.0d;
                y *= 2.0d;

                // Without this we get a strong precision loss and also overflows.
                // This can't also prevent this forever but it's better than nothing.
                if (x >= 4096.0f)
                    x -= 4096.0f;

                if (y >= 4096.0f)
                    y -= 4096.0f;
            }

            total += Add;

            return total;
        }
    }
}
#region Todo
//public double InterpolatedRand(double x, double y)
//{
//                SYSUINT L_IntX = (SYSUINT)X;
//                FLP32 L_FracX = X - L_IntX;

//                SYSUINT L_IntY = (SYSUINT)Y;
//                FLP32 L_FracY = Y - L_IntY;

//                FLP32 L_V1, L_V2, L_V3, L_V4, L_ResX1, L_ResX2;

//                L_V1 = SmoothRand(L_IntX, L_IntY);
//                L_V2 = SmoothRand(L_IntX + 1, L_IntY);
//                L_V3 = SmoothRand(L_IntX, L_IntY + 1);
//                L_V4 = SmoothRand(L_IntX + 1, L_IntY + 1);

//                L_ResX1 = Interpolate(L_V1, L_V2, L_FracX);
//                L_ResX2 = Interpolate(L_V3, L_V4, L_FracX);

//                return Interpolate(L_ResX1, L_ResX2, L_FracY);
//            }

//            FLP32 LC_PerlinNoise2D::Interpolate(FLP32 V1, FLP32 V2, FLP32 Step)
//{
//                FLP32 L_Fact;

//                // This interpolation methode is faster than a cosinus function, but it's neary
//                // equal to the cos-graph. I simply take a square function either in positiv
//                // direction or in negativ direction starting from 1.0.

//                if (Step > 0.5f)
//                {
//                    L_Fact = (1.0f - Step);
//                    L_Fact = L_Fact * L_Fact * 2.0f;
//                }
//                else
//                {
//                    L_Fact = 1.0f - Step * Step * 2.0f;
//                }

//                return V1 * L_Fact + V2 * (1.0f - L_Fact);
//            }

//            FLP32 LC_PerlinNoise2D::SmoothRand(SYSUINT X, SYSUINT Y)
//{
//                return Rand(X, Y);

//                // The following code gives a smoother perlin noise, but it's also quite slow
//                /*FLP32   L_Corners;
//                FLP32   L_Sides;
//                FLP32   L_Center;

//                L_Corners = ( Rand(X-1, Y-1) + Rand(X+1, Y-1) + Rand(X-1, Y+1) + Rand(X+1, Y+1) ) * ( 1.0f / 16.0f );
//                L_Sides   = ( Rand(X-1, Y  ) + Rand(X+1, Y  ) + Rand(X  , Y-1) + Rand(X  , Y+1) ) * ( 1.0f / 8.0f );
//                L_Center  =   Rand(X  , Y  ) * ( 1.0f / 4.0f );

//                return L_Center + L_Sides + L_Corners;*/
//            }

//            FLP32 LC_PerlinNoise2D::Rand(SYSUINT X, SYSUINT Y)
//{
//                SYSUINT L_Base;

//                L_Base = X + Y * 57 + m_Seed;
//                L_Base = (L_Base << 13) ^ L_Base;

//                return (1.0f - ((L_Base * (L_Base * L_Base * 15731 + 789221) + 1376312589) & 0x7fffffff) * (1.0f / 1073741824.0f));
//            }


//        }
//    }
//}
#endregion