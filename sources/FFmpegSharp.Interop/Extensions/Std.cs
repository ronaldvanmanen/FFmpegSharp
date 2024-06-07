// Copyright (C) 2021-2024 Ronald van Manen
//
// This file is part of FFmpegSharp.
//
// FFmpegSharp is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// FFmpegSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with FFmpegSharp; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA

using System;

namespace FFmpegSharp.Interop
{
    public static class Std
    {
        public const int EAGAIN = 11;

        public const int ENOMEM = 12;

        public const int EINVAL = 22;

        public const int ENOSYS = 40;

        ///<summary>
        /// Approximate square roots of DBL_MAX and DBL_MIN. Numbers
        /// between these two shouldn't neither overflow nor underflow
        /// when squared.
        ///</summary>
        private const double __SQRT_DBL_MAX = 1.3e+154;

        ///<summary>
        /// Approximate square roots of DBL_MAX and DBL_MIN. Numbers
        /// between these two shouldn't neither overflow nor underflow
        /// when squared.
        ///</summary>
        private const double __SQRT_DBL_MIN = 2.3e-162;

        public static double hypot(double x, double y)
        {
            double abig = Math.Abs(x), asmall = Math.Abs(y);
            double ratio;

            /* Make abig = max(|x|, |y|), asmall = min(|x|, |y|).  */
            if (abig < asmall)
            {
                double temp = abig;
                abig = asmall;
                asmall = temp;
            }

            /* Trivial case.  */
            if (asmall == 0)
            {
                return abig;
            }

            /* Scale the numbers as much as possible by using its ratio.
               For example, if both ABIG and ASMALL are VERY small, then
               X^2 + Y^2 might be VERY inaccurate due to loss of
               significant digits.  Dividing ASMALL by ABIG scales them
               to a certain degree, so that accuracy is better.  */

            if ((ratio = asmall / abig) > __SQRT_DBL_MIN && abig < __SQRT_DBL_MAX)
            {
                return abig * Math.Sqrt(1.0 + ratio * ratio);
            }
            else
            {
                /* Slower but safer algorithm due to Moler and Morrison.  Never
                   produces any intermediate result greater than roughly the
                   larger of X and Y.  Should converge to machine-precision
                   accuracy in 3 iterations.  */

                double r = ratio * ratio, t, s, p = abig, q = asmall;

                do
                {
                    t = 4.0 + r;
                    if (t == 4.0)
                    {
                        break;
                    }

                    s = r / t;
                    p += 2.0 * s * p;
                    q *= s;
                    r = (q / p) * (q / p);
                }
                while (true);

                return p;
            }
        }
    }
}
