using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    [DefaultFloatingPointTolerance(0.001f)]
    public class Tests10RowReduction
    {
        [Test]
        public void TestApplyRowReduction_CourseExample()
        {
            Matrix<float> m1 = new Matrix<float>(new[,]
            {
                { 3f, 2f, -3f },
                { 4f, -3f, 6f },
                { 1f, 0f, -1f }
            });

            Matrix<float> m2 = new Matrix<float>(new[,]
            {
                { -13f },
                { 7f },
                { -5f }
            });

            //This method use deconstruction tuple system
            //More information here =>
            //https://docs.microsoft.com/fr-fr/dotnet/csharp/fundamentals/functional/deconstruct
            (m1, m2) = MatrixRowReductionAlgorithm<float>.Apply(m1, m2);
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001f;
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f },
                { 0f, 1f, 0f },
                { 0f, 0f, 1f }
            }, m1.ToArray2D());

            Assert.AreEqual(new[,]
            {
                { -2f },
                { 1f },
                { 3f }
            }, m2.ToArray2D());
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        public void TestApplyRowReduction_Exercise()
        {
            Matrix<float> m1 = new Matrix<float>(new[,]
            {
                { 2f, 1f, 3f },
                { 0f, 1f, -1f },
                { 1f, 3f, -1f }
            });

            Matrix<float> m2 = new Matrix<float>(new[,]
            {
                { 0f },
                { 0f },
                { 0f }
            });

            //This method use deconstruction tuple system
            //More information here =>
            //https://docs.microsoft.com/fr-fr/dotnet/csharp/fundamentals/functional/deconstruct
            (m1, m2) = MatrixRowReductionAlgorithm<float>.Apply(m1, m2);
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001f;
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 2f },
                { 0f, 1f, -1f },
                { 0f, 0f, 0f }
            }, m1.ToArray2D());

            Assert.AreEqual(new[,]
            {
                { 0f },
                { 0f },
                { 0f }
            }, m2.ToArray2D());
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}