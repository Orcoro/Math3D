using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests09_AugmentedMatricesAndSplit
    {
        [Test]
        public void TestGenerateAugmentedMatrix()
        {
            MatrixInt m1 = new MatrixInt(new[,]
            {
                { 3, 2, -3 },
                { 4, -3, 6 },
                { 1, 0, -1 }
            });

            MatrixInt m2 = new MatrixInt(new[,]
            {
                { -13 },
                { 7 },
                { -5 }
            });

            MatrixInt augmentedMatrix = MatrixInt.GenerateAugmentedMatrix(m1, m2);
            Assert.AreEqual(new[,]
            {
                { 3, 2, -3, -13 },
                { 4, -3, 6, 7 },
                { 1, 0, -1, -5 }
            }, augmentedMatrix.ToArray2D());
        }

        [Test]
        public void TestSplitMatrix()
        {
            Matrix<int> m = new Matrix<int>(new[,]
            {
                { 2, 1, 3, 0 },
                { 0, 1, -1, 0 },
                { 1, 3, -1, 0 }
            });

            //This method use deconstruction tuple system
            //More information here =>
            //https://docs.microsoft.com/fr-fr/dotnet/csharp/fundamentals/functional/deconstruct
            (Matrix<int> m1, Matrix<int> m2) = m.Split(2);

            Assert.AreEqual(new[,]
            {
                { 2, 1, 3 },
                { 0, 1, -1 },
                { 1, 3, -1 }
            }, m1.ToArray2D());

            Assert.AreEqual(new[,]
            {
                { 0 },
                { 0 },
                { 0 }
            }, m2.ToArray2D());
        }
    }
}