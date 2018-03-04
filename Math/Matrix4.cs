// Copyright (c) 2018 the SMF Team
// This file is part of the "Sigon MMORPG Framework"
// See AUTHORS and LICENSE for more Information

using System;

namespace Sigon.Math
{
    public class Matrix4
    {
        private double xx, xy, xz, xw;
        private double yx, yy, yz, yw;
        private double zx, zy, zz, zw;
        private double wx, wy, wz, ww;

        public double XX { get { return xx; } set { xx = value; } }
        public double XY { get { return xy; } set { xy = value; } }
        public double XZ { get { return xz; } set { xz = value; } }
        public double XW { get { return xw; } set { xw = value; } }
        public double YX { get { return yx; } set { yx = value; } }
        public double YY { get { return yy; } set { yy = value; } }
        public double YZ { get { return yz; } set { yz = value; } }
        public double YW { get { return yw; } set { yw = value; } }
        public double ZX { get { return zx; } set { zx = value; } }
        public double ZY { get { return zy; } set { zy = value; } }
        public double ZZ { get { return zz; } set { zz = value; } }
        public double ZW { get { return zw; } set { zw = value; } }
        public double WX { get { return wx; } set { wx = value; } }
        public double WY { get { return wy; } set { wy = value; } }
        public double WZ { get { return wz; } set { wz = value; } }
        public double WW { get { return ww; } set { ww = value; } }

        public Matrix4()
        {
            LoadIdentity();
        }
        public void LoadIdentity()
        {
            xx = 1.0d; xy = 0.0d; xz = 0.0d; xw = 0.0d;
            yx = 0.0d; yy = 1.0d; yz = 0.0d; yw = 0.0d;
            zx = 0.0d; zy = 0.0d; zz = 1.0d; zw = 0.0d;
            wx = 0.0d; wy = 0.0d; wz = 0.0d; ww = 1.0d;
        }

        public static Matrix4 operator*(Matrix4 m1, Matrix4 m2)
        {
            return new Matrix4
            {
                xx = m1.xx * m2.xx + m1.xy * m2.xy + m1.xz * m2.xz + m1.xw * m2.xw,
                yx = m1.yx * m2.xx + m1.yy * m2.xy + m1.yz * m2.xz + m1.yw * m2.xw,
                zx = m1.zx * m2.xx + m1.zy * m2.xy + m1.zz * m2.xz + m1.zw * m2.xw,
                wx = m1.wx * m2.xx + m1.wy * m2.xy + m1.wz * m2.xz + m1.ww * m2.xw

                // TODO: Implement other 3 Vectors
            };
        }
    }
}
