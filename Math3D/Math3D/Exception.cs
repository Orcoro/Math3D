namespace Maths_Matrices
{
    public class MatrixSumException : ArgumentException
    {
        public MatrixSumException(string message) : base(message)
        {
        }
    }
    
    public class MatrixMultiplyException : ArgumentException
    {
        public MatrixMultiplyException(string message) : base(message)
        {
        }
    }
    
    public class MatrixScalarZeroException : ArgumentException
    {
        public MatrixScalarZeroException(string message) : base(message)
        {
        }
    }
    
    public class MatrixRowReductionException : ArgumentException
    {
        public MatrixRowReductionException(string message) : base(message)
        {
        }
    }
    
    public class MatrixInvertException : ArgumentException
    {
        public MatrixInvertException(string message) : base(message)
        {
        }
    }
}