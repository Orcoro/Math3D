using System.Numerics;
using NUnit.Framework;

namespace Maths_Matrices
{
    public static class MatrixElementaryOperations<T> where T : INumber<T>
    {
        public static void SwapLines(Matrix<T> matrix, int line1, int line2)
        {
            for (int i = 0; i < matrix.NbColumns; i++)
            {
                T temp = matrix[line1, i];
                matrix[line1, i] = matrix[line2, i];
                matrix[line2, i] = temp;
            }
        }
        
        public static void SwapColumns(Matrix<T> matrix, int column1, int column2)
        {
            for (int i = 0; i < matrix.NbLines; i++)
            {
                T temp = matrix[i, column1];
                matrix[i, column1] = matrix[i, column2];
                matrix[i, column2] = temp;
            }
        } 
        
        public static void MultiplyLine(Matrix<T> matrix, int line, T factor)
        {
            if (factor == T.Zero)
            {
                throw new MatrixScalarZeroException("The factor must not be zero.");
            }
            for (int i = 0; i < matrix.NbColumns; i++)
            {
                matrix[line, i] *= factor;
            }
        }
        
        public static void MultiplyColumn(Matrix<T> matrix, int column, T factor)
        {
            if (factor == T.Zero)
            {
                throw new MatrixScalarZeroException("The factor must not be zero.");
            }
            for (int i = 0; i < matrix.NbLines; i++)
            {
                matrix[i, column] *= factor;
            }
        }
        
        public static void AddLineToAnother(Matrix<T> matrix, int lineSource, int lineDestination, T factor)
        {
            for (int i = 0; i < matrix.NbColumns; i++)
            {
                matrix[lineDestination, i] += matrix[lineSource, i] * factor;
            }
        }
        
        public static void AddColumnToAnother(Matrix<T> matrix, int columnSource, int columnDestination, T factor)
        {
            for (int i = 0; i < matrix.NbLines; i++)
            {
                matrix[i, columnDestination] += matrix[i, columnSource] * factor;
            }
        }
    }
}