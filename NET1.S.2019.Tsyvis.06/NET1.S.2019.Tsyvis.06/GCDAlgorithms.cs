namespace NET1.S._2019.Tsyvis._06
{
    /// <summary>
    /// Provide API to finding gcd.
    /// </summary>
    public static class GCDAlgorithms
    {
        #region API by Euclidean

        public static int CalculateGcdByEuclidean(int a, int b)
            => GcdWith2Params(a, b, new EuclideanAlgorithm());

        public static int CalculateGcdByEuclideanAndTime(int a, int b, out long millisecond) =>
            GcdWith2ParamsAndTime(a, b, new EuclideanAlgorithm(), out millisecond);


        public static int CalculateGcdByEuclidean(int a, int b, int c)
            => GcdWith3Params(a, b, c, new EuclideanAlgorithm());

        public static int CalculateGcdByEuclideanAndTime(int a, int b, int c, out long millisecond) =>
            GcdWith3ParamsAndTime(a, b, c, new EuclideanAlgorithm(), out millisecond);

        public static int CalculateGcdByEuclidean(params int[] arrayParams)
            => GcdWithManyParams(arrayParams, new EuclideanAlgorithm());

        public static int CalculateGcdByEuclideanAndTime(out long millisecond, params int[] arrayParams)
            => GcdWithManyParamsAndTime(arrayParams, new EuclideanAlgorithm(), out millisecond);

        #endregion

        #region API by Stein

        public static int CalculateGcdByStein(int a, int b)
            => GcdWith2Params(a, b, new BinaryAlgorithm());

        public static int CalculateGcdBySteinAndTime(int a, int b, out long millisecond) =>
            GcdWith2ParamsAndTime(a, b, new BinaryAlgorithm(), out millisecond);

        public static int CalculateGcdByStein(int a, int b, int c)
            => GcdWith3Params(a, b, c, new BinaryAlgorithm());

        public static int CalculateGcdBySteinAndTime(int a, int b, int c, out long millisecond) =>
            GcdWith3ParamsAndTime(a, b, c, new BinaryAlgorithm(), out millisecond);

        public static int CalculateGcdByStein(params int[] arrayParams)
            => GcdWithManyParams(arrayParams, new BinaryAlgorithm());

        public static int CalculateGcdBySteinAndTime(out long millisecond, params int[] arrayParams)
            => GcdWithManyParamsAndTime(arrayParams, new BinaryAlgorithm(), out millisecond);

        #endregion

        #region Private helper methods

        private static int GcdWith2ParamsAndTime(int a, int b, GCDAlgorithm algorithm, out long milleseconds) =>
            algorithm.Calculate(a, b, out milleseconds);

        private static int GcdWith2Params(int a, int b, GCDAlgorithm algorithm) =>
            algorithm.Calculate(a, b);

        private static int GcdWith3Params(int a, int b, int c, GCDAlgorithm algorithm) =>
            algorithm.Calculate(a, b, c);

        private static int GcdWith3ParamsAndTime(int a, int b, int c, GCDAlgorithm algorithm, out long milleseconds) =>
            algorithm.Calculate(a, b, c, out milleseconds);

        private static int GcdWithManyParams(int[] array, GCDAlgorithm algorithm) =>
            algorithm.Calculate(array);

        private static int GcdWithManyParamsAndTime(int[] array, GCDAlgorithm algorithm, out long milleseconds) =>
            algorithm.Calculate(array, out milleseconds);

        #endregion
    }
}
