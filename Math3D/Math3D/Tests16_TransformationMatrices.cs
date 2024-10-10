using System;
using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    [DefaultFloatingPointTolerance(0.001d)]
    public class Tests16_TransformationMatrices
    {
        [Test]
        public void TestTranslatePoint()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Vector4 v = new Vector4(1f, 0f, 0f, 1f);
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 1f, 0f, 0f, 5f },
                { 0f, 1f, 0f, 3f },
                { 0f, 0f, 1f, 1f },
                { 0f, 0f, 0f, 1f },
            });

            Vector4 vTransformed = m * v;
            Assert.AreEqual(vTransformed.x, 6f);
            Assert.AreEqual(vTransformed.y, 3f);
            Assert.AreEqual(vTransformed.z, 1f);

            Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
            Assert.AreEqual(1f, vTransformedInverted.x);
            Assert.AreEqual(0f, vTransformedInverted.y);
            Assert.AreEqual(0f, vTransformedInverted.z);

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            Assert.AreEqual(1f, vTransformedInverted.x);
            Assert.AreEqual(0f, vTransformedInverted.y);
            Assert.AreEqual(0f, vTransformedInverted.z);

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        public void TestTranslateDirection()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Vector4 v = new Vector4(1f, 0f, 0f, 0f);
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 1f, 0f, 0f, 5f },
                { 0f, 1f, 0f, 3f },
                { 0f, 0f, 1f, 1f },
                { 0f, 0f, 0f, 1f },
            });
            Vector4 vTransformed = m * v;

            Assert.AreEqual(1f, vTransformed.x);
            Assert.AreEqual(0f, vTransformed.y);
            Assert.AreEqual(0f, vTransformed.z);

            Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
            Assert.AreEqual(1f, vTransformedInverted.x);
            Assert.AreEqual(0f, vTransformedInverted.y);
            Assert.AreEqual(0f, vTransformedInverted.z);

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            Assert.AreEqual(1f, vTransformedInverted.x);
            Assert.AreEqual(0f, vTransformedInverted.y);
            Assert.AreEqual(0f, vTransformedInverted.z);

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        public void TestScalePoint()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Vector4 v = new Vector4(2f, 1f, 3f, 1f);
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 0.5f, 0f, 0f, 0f },
                { 0.0f, 2f, 0f, 0f },
                { 0.0f, 0f, 3f, 0f },
                { 0.0f, 0f, 0f, 1f },
            });

            Vector4 vTransformed = m * v;
            Assert.AreEqual(1f, vTransformed.x);
            Assert.AreEqual(2f, vTransformed.y);
            Assert.AreEqual(9f, vTransformed.z);

            Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
            Assert.AreEqual(2f, vTransformedInverted.x);
            Assert.AreEqual(1f, vTransformedInverted.y);
            Assert.AreEqual(3f, vTransformedInverted.z);

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            Assert.AreEqual(2f, vTransformedInverted.x);
            Assert.AreEqual(1f, vTransformedInverted.y);
            Assert.AreEqual(3f, vTransformedInverted.z);

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        public void TestRotatePoint()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Vector4 v = new Vector4(1f, 4f, 7f, 1f);
            double a = Math.PI / 2d;
            float cosA = (float)Math.Cos(a);
            float sinA = (float)Math.Sin(a);
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { cosA, -sinA, 0f, 0f },
                { sinA, cosA, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            });

            Vector4 vTransformed = m * v;
            Assert.AreEqual(-4f, vTransformed.x);
            Assert.AreEqual(1f, vTransformed.y);
            Assert.AreEqual(7f, vTransformed.z);

            Vector4 vTransformedInverted = m.InvertByRowReduction() * vTransformed;
            Assert.AreEqual(1f, vTransformedInverted.x);
            Assert.AreEqual(4f, vTransformedInverted.y);
            Assert.AreEqual(7f, vTransformedInverted.z);

            vTransformedInverted = m.InvertByDeterminant() * vTransformed;
            Assert.AreEqual(1f, vTransformedInverted.x);
            Assert.AreEqual(4f, vTransformedInverted.y);
            Assert.AreEqual(7f, vTransformedInverted.z);

            //  GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}