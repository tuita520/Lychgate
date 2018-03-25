// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System.Runtime.CompilerServices;

namespace Sigon.Lychgate.Math
{
    /// <summary>
    /// Implements a Perlin-Noise Algorithm.
    /// </summary>
    public class PerlinNoise
    {
        /// <summary>
        /// 
        /// </summary>
        public uint Seed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Add { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Amplitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Persistence { get; set; }

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
            var range = Amplitude - Add;
            Add += range * 0.5d;

            // We get values between -1 and 1 out of the Rand function
            var summarizedMultiplier = 0.0d;
            var multiplier = 2.0d;

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

            for (var i = 0; i < Depth; ++i)
            {
                //   total += InterpolatedRand(x, y) * ampl;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double InterpolatedRand(double x, double y)
        {
            var intX = (uint)x;
            var fracX = x - intX;

            var intY = (uint)y;
            var fracY = y - intY;

            var v1 = SmoothRand(intX, intY);
            var v2 = SmoothRand(intX + 1, intY);
            var v3 = SmoothRand(intX, intY + 1);
            var v4 = SmoothRand(intX + 1, intY + 1);

            var resX1 = Interpolate(v1, v2, fracX);
            var resX2 = Interpolate(v3, v4, fracX);

            return Interpolate(resX1, resX2, fracY);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="V1"></param>
        /// <param name="V2"></param>
        /// <param name="Step"></param>
        /// <returns></returns>
        public double Interpolate(double V1, double V2, double Step)
        {
            double fact;

            // This interpolation methode is faster than a cosinus function, but it's nearly
            // equal to the cos-graph. I simply take a square function either in positive
            // direction or in negative direction starting from 1.0.

            if (Step > 0.5f)
            {
                fact = (1.0f - Step);
                fact = fact * fact * 2.0f;
            }
            else
            {
                fact = 1.0f - Step * Step * 2.0f;
            }

            return V1 * fact + V2 * (1.0f - fact);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double SmoothRand(uint x, uint y)
        {
            return Rand(x, y);

            // This is a better, but slower algorithm. Should be tested.

            //double Corners;
            //double Sides;
            //double Center;

            //Corners = (Rand(x - 1, y - 1) + Rand(x + 1, y - 1) + Rand(x - 1, y + 1) + Rand(x + 1, y + 1)) * (1.0f / 16.0f);
            //Sides = (Rand(x - 1, y) + Rand(x + 1, y) + Rand(x, y - 1) + Rand(x, y + 1)) * (1.0f / 8.0f);
            //Center = Rand(x, y) * (1.0f / 4.0f);

            //return Center + Sides + Corners;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Rand(uint x, uint y)
        {
            var Base = x + y * 57 + Seed;
            Base = (Base << 13) ^ Base;

            return (1.0f - ((Base * (Base * Base * 15731 + 789221) + 1376312589) & 0x7fffffff) * (1.0f / 1073741824.0f));
        }
    }
}
