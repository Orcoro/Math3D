using System.Numerics;
using NUnit.Framework;

namespace Maths_Matrices
{
    /// <summary>
    /// Represents a generic matrix.
    /// </summary>
    public class Matrix<T> where T : INumber<T>
    {
        private protected T[,] _values;

        public int NbLines => _values.GetLength(0);
        public int NbColumns => _values.GetLength(1);

        public T this[int i, int j]
        {
            get => _values[i, j];
            set => _values[i, j] = value;
        }

        #region Constructors

        public Matrix()
        {
            _values = new T[0, 0];
        }

        public Matrix(int nbLines, int nbColumns)
        {
            _values = new T[nbLines, nbColumns];
        }

        public Matrix(T[,] values)
        {
            _values = values;
        }

        public Matrix(Matrix<T> m)
        {
            _values = new T[m.NbLines, m.NbColumns];
            for (int i = 0; i < m.NbLines; i++) {
                for (int j = 0; j < m.NbColumns; j++) {
                    _values[i, j] = m[i, j];
                }
            }
        }

        #endregion //Constructors

        #region Static Methods

        public static Matrix<T> Identity(int n)
        {
            Matrix<T> m = new Matrix<T>(n, n);
            for (int i = 0; i < n; i++) {
                m[i, i] = (T)Convert.ChangeType(1, typeof(T));
            }

            return m;
        }

        /// <summary>
        /// Multiplies a matrix by a scalar.
        /// </summary>
        /// <param name="m">The matrix to multiply.</param>
        /// <param name="scalar">The scalar to multiply by.</param>
        /// <returns>The resulting matrix after multiplication.</returns>
        public static Matrix<T> Multiply(Matrix<T> m, T scalar)
        {
            Matrix<T> result = new Matrix<T>(m);
            result.Multiply(scalar);
            return result;
        }

        public static Matrix<T> Multiply(T scalar, Matrix<T> m)
        {
            return Multiply(m, scalar);
        }

        public static Matrix<T> Multiply(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.NbColumns != m2.NbLines) {
                throw new System.ArgumentException("Matrix dimensions are not compatible for multiplication.");
            }

            Matrix<T> result = new Matrix<T>(m1.NbLines, m2.NbColumns);
            for (int i = 0; i < m1.NbLines; i++) {
                for (int j = 0; j < m2.NbColumns; j++) {
                    T sum = T.Zero;
                    for (int k = 0; k < m1.NbColumns; k++) {
                        sum += m1[i, k] * m2[k, j];
                    }

                    result[i, j] = sum;
                }
            }

            return result;
        }

        public static Matrix<T> Add(Matrix<T> m1, Matrix<T> m2)
        {
            Matrix<T> result = new Matrix<T>(m1);
            if (m1.NbLines != m2.NbLines || m1.NbColumns != m2.NbColumns) {
                throw new System.ArgumentException("The two matrices must have the same number of lines and columns");
            }

            for (int i = 0; i < result.NbLines; i++) {
                for (int j = 0; j < result.NbColumns; j++) {
                    dynamic value = m1[i, j];
                    result[i, j] = value + m2[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> Transpose(Matrix<T> m)
        {
            return m.Transpose();
        }

        public static Matrix<T> GenerateAugmentedMatrix(Matrix<T> m1, Matrix<T> m2)
        {
            Matrix<T> result = new Matrix<T>(m1.NbLines, m1.NbColumns + m2.NbColumns);
            for (int i = 0; i < result.NbLines; i++) {
                for (int j = 0; j < m1.NbColumns; j++) {
                    result[i, j] = m1[i, j];
                }

                for (int j = 0; j < m2.NbColumns; j++) {
                    result[i, m1.NbColumns + j] = m2[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> InvertByRowReduction(Matrix<T> matrix)
        {
            if (matrix.NbLines != matrix.NbColumns) {
                throw new MatrixInvertException("The matrix must be square.");
            }

            Matrix<T> identity = Matrix<T>.Identity(matrix.NbLines);
            Matrix<T> reducedMatrix;
            Matrix<T> invertedMatrix;
            (reducedMatrix, invertedMatrix) = MatrixRowReductionAlgorithm<T>.Apply(matrix, identity);
            return invertedMatrix;
        }

        public static Matrix<T> SubMatrix(Matrix<T> matrix, int line, int column)
        {
            return matrix.SubMatrix(line, column);
        }

        public static T Determinant(Matrix<T> matrix)
        {
            return matrix.Determinant();
        }

        public static Matrix<T> Adjugate(Matrix<T> matrix)
        {
            return matrix.Adjugate();
        }

        public static Matrix<T> InvertByDeterminant(Matrix<T> matrix)
        {
            return matrix.InvertByDeterminant();
        }

        #endregion //Static Methods

        #region Public Methods
        public bool IsIdentity()
        {
            if (NbLines != NbColumns) {
                return false;
            }

            for (int i = 0; i < NbLines; i++) {
                for (int j = 0; j < NbColumns; j++) {
                    if (i == j && _values[i, j].Equals(Convert.ChangeType(1, typeof(T))) == false) {
                        return false;
                    }

                    if (i != j && _values[i, j].Equals(Convert.ChangeType(0, typeof(T))) == false) {
                        return false;
                    }
                }
            }

            return true;
        }

        public virtual void Add(Matrix<T> m)
        {
            if (NbLines != m.NbLines || NbColumns != m.NbColumns) {
                throw new MatrixSumException("The two matrices must have the same number of lines and columns");
            }
            for (int i = 0; i < NbLines; i++) {
                for (int j = 0; j < NbColumns; j++) {
                    dynamic value = _values[i, j];
                    _values[i, j] = value + m[i, j];
                }
            }
        }

        public virtual void Multiply(T scalar)
        {
            for (int i = 0; i < NbLines; i++) {
                for (int j = 0; j < NbColumns; j++) {
                    dynamic value = _values[i, j];
                    _values[i, j] = value * scalar;
                }
            }
        }

        public virtual Matrix<T> Multiply(Matrix<T> m)
        {
            if (NbColumns != m.NbLines) {
                throw new System.ArgumentException(
                    "The number of columns of the first matrix must be equal to the number of lines of the second matrix");
            }

            Matrix<T> result = new Matrix<T>(NbLines, m.NbColumns);
            for (int i = 0; i < NbLines; i++) {
                for (int j = 0; j < m.NbColumns; j++) {
                    dynamic sum = 0;
                    for (int k = 0; k < NbColumns; k++) {
                        sum += _values[i, k] * m[k, j];
                    }

                    result[i, j] = sum;
                }
            }

            return result;
        }

        public virtual Matrix<T> Transpose()
        {
            Matrix<T> result = new Matrix<T>(NbColumns, NbLines);
            for (int i = 0; i < NbLines; i++) {
                for (int j = 0; j < NbColumns; j++) {
                    result[j, i] = _values[i, j];
                }
            }

            return result;
        }

        public virtual (Matrix<T>, Matrix<T>) Split(int column)
        {
            Matrix<T> left = new Matrix<T>(NbLines, column + 1);
            Matrix<T> right = new Matrix<T>(NbLines, NbColumns - (column + 1));
            for (int i = 0; i < NbLines; i++) {
                for (int j = 0; j < NbColumns; j++) {
                    if (j <= column) {
                        left[i, j] = _values[i, j];
                    }
                    else {
                        right[i, j - (column + 1)] = _values[i, j];
                    }
                }
            }

            return (left, right);
        }

        public virtual Matrix<T> InvertByRowReduction()
        {
            if (IsSingular()) {
                throw new MatrixInvertException("The matrix is singular.");
            }

            Matrix<T> identity = Matrix<T>.Identity(NbLines);
            var (reducedMatrix, invertedMatrix) = MatrixRowReductionAlgorithm<T>.Apply(this, identity);
            return invertedMatrix;
        }

        public virtual Matrix<T> SubMatrix(int line, int column)
        {
            Matrix<T> result = new Matrix<T>(NbLines - 1, NbColumns - 1);
            for (int i = 0; i < NbLines; i++) {
                for (int j = 0; j < NbColumns; j++) {
                    if (i < line && j < column) {
                        result[i, j] = _values[i, j];
                    }
                    else if (i < line && j > column) {
                        result[i, j - 1] = _values[i, j];
                    }
                    else if (i > line && j < column) {
                        result[i - 1, j] = _values[i, j];
                    }
                    else if (i > line && j > column) {
                        result[i - 1, j - 1] = _values[i, j];
                    }
                }
            }

            return result;
        }

        public Matrix<T> Adjugate()
        {
            if (NbLines != NbColumns) {
                throw new InvalidOperationException("The matrix must be square.");
            }

            Matrix<T> result = new Matrix<T>(NbLines, NbColumns);
            for (int i = 0; i < NbLines; i++) {
                for (int j = 0; j < NbColumns; j++) {
                    result[j, i] = (i + j) % 2 == 0 ? SubMatrix(i, j).Determinant() : -SubMatrix(i, j).Determinant();
                }
            }

            return result;
        }

        public Matrix<T> InvertByDeterminant()
        {
            T determinant = Determinant();
            if (determinant.Equals(T.Zero)) {
                throw new MatrixInvertException("The matrix is singular.");
            }

            return Adjugate() * (T.One / determinant);
        }

        public T[,] ToArray2D()
        {
            return _values;
        }
        
        public Matrix<T> GetColumn(int column)
        {
            Matrix<T> result = new Matrix<T>(NbLines, 1);
            for (int i = 0; i < NbLines; i++) {
                result[i, 0] = _values[i, column];
            }

            return result;
        }
        
        public Matrix<T> GetLine(int line)
        {
            Matrix<T> result = new Matrix<T>(1, NbColumns);
            for (int i = 0; i < NbColumns; i++) {
                result[0, i] = _values[line, i];
            }

            return result;
        }

        #endregion //Public Methods

        #region Private Methods
        private protected bool IsSingular()
        {
            return Determinant() == T.Zero;
        }

        public virtual T Determinant()
        {
            if (NbLines != NbColumns) {
                throw new InvalidOperationException("Determinant can only be calculated for square matrices.");
            }

            return CalculateDeterminant(_values);
        }

        private protected T CalculateDeterminant(T[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (n == 1) {
                return matrix[0, 0];
            }

            if (n == 2) {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }

            T determinant = T.Zero;
            for (int p = 0; p < n; p++) {
                T[,] subMatrix = new T[n - 1, n - 1];
                for (int i = 1; i < n; i++) {
                    int subMatrixColumn = 0;
                    for (int j = 0; j < n; j++) {
                        if (j == p) continue;
                        subMatrix[i - 1, subMatrixColumn] = matrix[i, j];
                        subMatrixColumn++;
                    }
                }

                determinant += matrix[0, p] * CalculateDeterminant(subMatrix) * (p % 2 == 0 ? T.One : -T.One);
            }

            return determinant;
        }

        #endregion //Private Methods

        #region Operators

        public static Matrix<T> operator *(Matrix<T> m, T scalar)
        {
            return Multiply(m, scalar);
        }

        public static Matrix<T> operator *(T scalar, Matrix<T> m)
        {
            return Multiply(m, scalar);
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.NbColumns != m2.NbLines) {
                throw new System.ArgumentException(
                    "The number of columns of the first matrix must be equal to the number of lines of the second matrix");
            }

            Matrix<T> result = new Matrix<T>(m1.NbLines, m2.NbColumns);
            for (int i = 0; i < m1.NbLines; i++) {
                for (int j = 0; j < m2.NbColumns; j++) {
                    dynamic sum = 0;
                    for (int k = 0; k < m1.NbColumns; k++) {
                        sum += m1[i, k] * m2[k, j];
                    }

                    result[i, j] = sum;
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> m)
        {
            Matrix<T> result = new Matrix<T>(m);
            for (int i = 0; i < m.NbLines; i++) {
                for (int j = 0; j < m.NbColumns; j++) {
                    dynamic value = m[i, j];
                    result[i, j] = -value;
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            return Add(m1, -m2);
        }

        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            return Add(m1, m2);
        }

        #endregion //Operators
    }

    public class MatrixInt : Matrix<int>
    {
        #region Constructors

        public MatrixInt() : base()
        {
        }

        public MatrixInt(int nbLines, int nbColumns) : base(nbLines, nbColumns)
        {
        }

        public MatrixInt(int[,] values) : base(values)
        {
        }

        public MatrixInt(Matrix<int> m) : base(m)
        {
        }

        #endregion

        #region Static Methods

        public static MatrixInt Identity(int n)
        {
            MatrixInt m = new MatrixInt(n, n);
            for (int i = 0; i < n; i++) {
                m[i, i] = 1;
            }

            return m;
        }

        public static Matrix<int> InvertByRowReduction(Matrix<int> matrix)
        {
            if (matrix.NbLines != matrix.NbColumns) {
                throw new MatrixInvertException("The matrix must be square.");
            }

            Matrix<int> identity = MatrixInt.Identity(matrix.NbLines);
            Matrix<int> reducedMatrix;
            Matrix<int> invertedMatrix;
            (reducedMatrix, invertedMatrix) = MatrixRowReductionAlgorithm<int>.Apply(matrix, identity);
            return invertedMatrix;
        }

        public static MatrixInt Multiply(Matrix<int> m, int scalar)
        {
            MatrixInt result = new MatrixInt(m);
            result.Multiply(scalar);
            return result;
        }

        public static Matrix<int> Multiply(int scalar, Matrix<int> m)
        {
            return Multiply(m, scalar);
        }

        public static MatrixInt Multiply(Matrix<int> m1, Matrix<int> m2)
        {
            if (m1.NbColumns != m2.NbLines) {
                throw new MatrixMultiplyException(
                    "The number of columns of the first matrix must be equal to the number of lines of the second matrix");
            }

            MatrixInt result = new MatrixInt(m1.NbLines, m2.NbColumns);
            for (int i = 0; i < m1.NbLines; i++) {
                for (int j = 0; j < m2.NbColumns; j++) {
                    dynamic sum = 0;
                    for (int k = 0; k < m1.NbColumns; k++) {
                        sum += m1[i, k] * m2[k, j];
                    }

                    result[i, j] = sum;
                }
            }

            return result;
        }

        public static MatrixInt Add(Matrix<int> m1, Matrix<int> m2)
        {
            MatrixInt result = new MatrixInt(m1);
            if (m1.NbLines != m2.NbLines || m1.NbColumns != m2.NbColumns) {
                throw new MatrixSumException("The two matrices must have the same number of lines and columns");
            }

            for (int i = 0; i < result.NbLines; i++) {
                for (int j = 0; j < result.NbColumns; j++) {
                    dynamic value = m1[i, j];
                    result[i, j] = value + m2[i, j];
                }
            }

            return result;
        }

        public static MatrixInt Transpose(Matrix<int> m1)
        {
            return new MatrixInt(m1.Transpose());
        }

        public static MatrixInt GenerateAugmentedMatrix(Matrix<int> m1, Matrix<int> m2)
        {
            MatrixInt result = new MatrixInt(Matrix<int>.GenerateAugmentedMatrix(m1, m2));

            return result;
        }

        #endregion //Static Methods

        #region Public Methods

        public override void Multiply(int scalar)
        {
            for (int i = 0; i < NbLines; i++) {
                for (int j = 0; j < NbColumns; j++) {
                    _values[i, j] *= scalar;
                }
            }
        }

        public override MatrixInt Multiply(Matrix<int> m)
        {
            if (NbColumns != m.NbLines) {
                throw new MatrixMultiplyException(
                    "The number of columns of the first matrix must be equal to the number of lines of the second matrix");
            }

            MatrixInt result = new MatrixInt(NbLines, m.NbColumns);
            for (int i = 0; i < NbLines; i++) {
                for (int j = 0; j < m.NbColumns; j++) {
                    dynamic sum = 0;
                    for (int k = 0; k < NbColumns; k++) {
                        sum += _values[i, k] * m[k, j];
                    }

                    result[i, j] = sum;
                }
            }

            return result;
        }

        public override MatrixInt Transpose()
        {
            return new MatrixInt(base.Transpose());
        }

        public override Matrix<int> InvertByRowReduction()
        {
            if (NbLines != NbColumns) {
                throw new MatrixInvertException("The matrix must be square.");
            }

            Matrix<int> identity = MatrixInt.Identity(NbLines);
            Matrix<int> reducedMatrix;
            Matrix<int> invertedMatrix;
            (reducedMatrix, invertedMatrix) = MatrixRowReductionAlgorithm<int>.Apply(this, identity);
            return invertedMatrix;
        }

        #endregion //Public Methods

        #region Operators

        public static MatrixInt operator *(MatrixInt m, int scalar)
        {
            return Multiply(m, scalar);
        }

        public static MatrixInt operator *(int scalar, MatrixInt m)
        {
            return Multiply(m, scalar);
        }

        public static MatrixInt operator *(MatrixInt m1, MatrixInt m2)
        {
            return Multiply(m1, m2);
        }

        public static MatrixInt operator -(MatrixInt m)
        {
            MatrixInt result = new MatrixInt(m);
            for (int i = 0; i < m.NbLines; i++) {
                for (int j = 0; j < m.NbColumns; j++) {
                    result[i, j] = -m[i, j];
                }
            }

            return result;
        }

        public static MatrixInt operator -(MatrixInt m1, MatrixInt m2)
        {
            return Add(m1, -m2);
        }

        public static MatrixInt operator +(MatrixInt m1, MatrixInt m2)
        {
            return Add(m1, m2);
        }

        #endregion //Operators
    }

    public class MatrixFloat : Matrix<float>
    {
        #region Constructors

        public MatrixFloat() : base()
        {
        }

        public MatrixFloat(int nbLines, int nbColumns) : base(nbLines, nbColumns)
        {
        }

        public MatrixFloat(float[,] values) : base(values)
        {
        }

        public MatrixFloat(Matrix<float> m) : base(m)
        {
        }

        #endregion

        #region Static Methods

        public static MatrixFloat Identity(int n)
        {
            MatrixFloat m = new MatrixFloat(n, n);
            for (int i = 0; i < n; i++) {
                m[i, i] = 1;
            }

            return m;
        }

        public static Matrix<float> InvertByRowReduction(Matrix<float> matrix)
        {
            if (matrix.NbLines != matrix.NbColumns) {
                throw new MatrixInvertException("The matrix must be square.");
            }

            Matrix<float> identity = MatrixFloat.Identity(matrix.NbLines);
            Matrix<float> reducedMatrix;
            Matrix<float> invertedMatrix;
            (reducedMatrix, invertedMatrix) = MatrixRowReductionAlgorithm<float>.Apply(matrix, identity);
            return invertedMatrix;
        }

        #endregion //Static Methods

        #region Public Methods

        public override Matrix<float> InvertByRowReduction()
        {
            if (NbLines != NbColumns) {
                throw new MatrixInvertException("The matrix must be square.");
            }

            Matrix<float> identity = MatrixFloat.Identity(NbLines);
            Matrix<float> reducedMatrix;
            Matrix<float> invertedMatrix;
            (reducedMatrix, invertedMatrix) = MatrixRowReductionAlgorithm<float>.Apply(this, identity);
            return invertedMatrix;
        }

        #endregion //Public Methods
    }
}