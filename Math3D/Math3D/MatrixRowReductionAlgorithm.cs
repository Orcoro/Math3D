using System.Numerics;

namespace Maths_Matrices
{
    public class MatrixRowReductionAlgorithm<T> where T : INumber<T>
    {
        public static (Matrix<T>, Matrix<T>) Apply(Matrix<T> m1, Matrix<T> m2, bool throwException = false)
        {
            if (m1.NbLines != m2.NbLines) {
                throw new MatrixRowReductionException("The two matrices must have the same number of lines.");
            }

            Matrix<T> result1 = new Matrix<T>(m1);
            Matrix<T> result2 = new Matrix<T>(m2);

            for (int i = 0; i < m1.NbLines; i++) {
                int pivotRow = i;
                for (int j = i + 1; j < m1.NbLines; j++) {
                    if (result1[j, i] > result1[pivotRow, i] && result1[j, i] != T.Zero) {
                        pivotRow = j;
                    }
                }

                if (pivotRow != i) {
                    MatrixElementaryOperations<T>.SwapLines(result1, i, pivotRow);
                    MatrixElementaryOperations<T>.SwapLines(result2, i, pivotRow);
                }

                if (T.Abs(result1[i, i]) == T.Zero) {
                    if (throwException) {
                        throw new MatrixRowReductionException("The diagonal element must not be zero.");
                    }
                    else {
                        continue;
                    }
                }

                T pivotValue = result1[i, i];
                for (int k = 0; k < m1.NbColumns; k++) {
                    result1[i, k] /= pivotValue;
                }

                for (int k = 0; k < m2.NbColumns; k++) {
                    result2[i, k] /= pivotValue;
                }

                for (int j = 0; j < m1.NbLines; j++) {
                    if (i != j) {
                        T factor = result1[j, i];
                        for (int k = 0; k < m1.NbColumns; k++) {
                            result1[j, k] -= result1[i, k] * factor;
                        }

                        for (int k = 0; k < m2.NbColumns; k++) {
                            result2[j, k] -= result2[i, k] * factor;
                        }
                    }
                }
            }

            return (result1, result2);
        }
    }
}