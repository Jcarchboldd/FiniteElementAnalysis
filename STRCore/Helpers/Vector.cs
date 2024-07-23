namespace STRCore.Helpers
{
    internal static class Vector
    {
        /// <summary>
        /// Normalizes the given vector in place, modifying the original vector to have a length of 1.
        /// </summary>
        /// <param name="vin">The vector to normalize. The vector is modified in place.</param>
        internal static void Normalize(ref double[] vin)
        {
            double length = Length(vin);
            vin[0] /= length;
            vin[1] /= length;
            vin[2] /= length;
        }

        /// <summary>
        /// Calculates the length (magnitude) of the given vector.
        /// </summary>
        /// <param name="vin">The vector whose length is to be calculated.</param>
        /// <returns>The length of the vector.</returns>
        internal static double Length(double[] vin)
        {
            return Math.Sqrt(Math.Pow(vin[0], 2) + Math.Pow(vin[1], 2) + Math.Pow(vin[2], 2));
        }

        /// <summary>
        /// Calculates the dot product of two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>The dot product of the two vectors.</returns>
        internal static double Dot(double[] v1, double[] v2)
        {
            return v1[0] * v2[0] + v1[1] * v2[1] + v1[2] * v2[2];
        }

        /// <summary>
        /// Calculates the cross product of two vectors.
        /// </summary>
        /// <param name="v1">The first vector.</param>
        /// <param name="v2">The second vector.</param>
        /// <returns>A new vector that is the cross product of the two input vectors.</returns>
        internal static double[] CrossProduct(double[] v1, double[] v2)
        {
            double[] result = new double[3];

            double x = v1[1] * v2[2] - v1[2] * v2[1];
            double y = v1[2] * v2[0] - v1[0] * v2[2];
            double z = v1[0] * v2[1] - v1[1] * v2[0];

            result[0] = x;
            result[1] = y;
            result[2] = z;

            return result;
        }
    }
}