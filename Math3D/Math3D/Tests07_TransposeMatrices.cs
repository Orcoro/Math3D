using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests07_TransposeMatrices
    {
        [Test]
        public void TestTransposeMatrixInstance()
        {
            MatrixInt m1 = new MatrixInt(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            });

            MatrixInt m1t = m1.Transpose();

            Assert.AreEqual(new[,]
            {
                { 1, 4 },
                { 2, 5 },
                { 3, 6 }
            }, m1t.ToArray2D());
        }
        
        [Test]
        public void TestTransposeMatrixStatic()
        {
            MatrixInt m1 = new MatrixInt(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 }
            });

            MatrixInt m1t = MatrixInt.Transpose(m1);

            Assert.AreEqual(new[,]
            {
                { 1, 4 },
                { 2, 5 },
                { 3, 6 }
            }, m1t.ToArray2D());
        }
    }
}