using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests08_ElementaryOperations
    {
        #region Swaps Tests

        [Test]
        public void TestSwapLines()
        {
            MatrixInt m = new MatrixInt(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            });

            MatrixElementaryOperations<int>.SwapLines(m, 0, 1);
            Assert.AreEqual(new[,]
            {
                { 4, 5, 6 },
                { 1, 2, 3 },
                { 7, 8, 9 }
            }, m.ToArray2D());

            MatrixElementaryOperations<int>.SwapLines(m, 0, 2);
            Assert.AreEqual(new[,]
            {
                { 7, 8, 9 },
                { 1, 2, 3 },
                { 4, 5, 6 }
            }, m.ToArray2D());

            MatrixElementaryOperations<int>.SwapLines(m, 2, 1);
            Assert.AreEqual(new[,]
            {
                { 7, 8, 9 },
                { 4, 5, 6 },
                { 1, 2, 3 }
            }, m.ToArray2D());
        }

        [Test]
        public void TestSwapColumns()
        {
            MatrixInt m = new MatrixInt(new[,]
            {
                { 1, 4, 7 },
                { 2, 5, 8 },
                { 3, 6, 9 }
            });

            MatrixElementaryOperations<int>.SwapColumns(m, 0, 1);
            Assert.AreEqual(new[,]
            {
                { 4, 1, 7 },
                { 5, 2, 8 },
                { 6, 3, 9 }
            }, m.ToArray2D());

            MatrixElementaryOperations<int>.SwapColumns(m, 0, 2);
            Assert.AreEqual(new[,]
            {
                { 7, 1, 4 },
                { 8, 2, 5 },
                { 9, 3, 6 }
            }, m.ToArray2D());

            MatrixElementaryOperations<int>.SwapColumns(m, 2, 1);
            Assert.AreEqual(new[,]
            {
                { 7, 4, 1 },
                { 8, 5, 2 },
                { 9, 6, 3 }
            }, m.ToArray2D());
        }

        #endregion

        #region Multiply Lines/Columns Tests

        [Test]
        public void TestMultiplyLine()
        {
            MatrixInt m = new MatrixInt(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            });

            MatrixElementaryOperations<int>.MultiplyLine(m, 0, 2);
            Assert.AreEqual(new[,]
            {
                { 2, 4, 6 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            }, m.ToArray2D());

            MatrixElementaryOperations<int>.MultiplyLine(m, 1, 3);
            Assert.AreEqual(new[,]
            {
                { 2, 4, 6 },
                { 12, 15, 18 },
                { 7, 8, 9 }
            }, m.ToArray2D());

            MatrixElementaryOperations<int>.MultiplyLine(m, 2, 10);
            Assert.AreEqual(new[,]
            {
                { 2, 4, 6 },
                { 12, 15, 18 },
                { 70, 80, 90 }
            }, m.ToArray2D());
            
            Assert.Throws<MatrixScalarZeroException>(() =>
            {
                MatrixElementaryOperations<int>.MultiplyLine(m, 0, 0);
            });
        }

        [Test]
        public void TestMultiplyColumn()
        {
            MatrixInt m = new MatrixInt(new[,]
            {
                { 1, 4, 7 },
                { 2, 5, 8 },
                { 3, 6, 9 }
            });

            MatrixElementaryOperations<int>.MultiplyColumn(m, 0, 2);
            Assert.AreEqual(new[,]
            {
                { 2, 4, 7 },
                { 4, 5, 8 },
                { 6, 6, 9 }
            }, m.ToArray2D());

            MatrixElementaryOperations<int>.MultiplyColumn(m, 1, 3);
            Assert.AreEqual(new[,]
            {
                { 2, 12, 7 },
                { 4, 15, 8 },
                { 6, 18, 9 }
            }, m.ToArray2D());

            MatrixElementaryOperations<int>.MultiplyColumn(m, 2, 10);
            Assert.AreEqual(new[,]
            {
                { 2, 12, 70 },
                { 4, 15, 80 },
                { 6, 18, 90 }
            }, m.ToArray2D());
            
            Assert.Throws<MatrixScalarZeroException>(() =>
            {
                MatrixElementaryOperations<int>.MultiplyColumn(m, 0, 0);
            });
        }

        #endregion

        #region Add Lines/Columns to another (with factor)

        [Test]
        public void TestAddLineToAnother()
        {
            MatrixInt m = new MatrixInt(new[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            });

            MatrixElementaryOperations<int>.AddLineToAnother(m, 1, 0, 2);
            Assert.AreEqual(new[,]
            {
                { 9, 12, 15 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            }, m.ToArray2D());
        }

        [Test]
        public void TestAddColumnToAnother()
        {
            MatrixInt m = new MatrixInt(new[,]
            {
                { 1, 4, 7 },
                { 2, 5, 8 },
                { 3, 6, 9 }
            });

            MatrixElementaryOperations<int>.AddColumnToAnother(m, 1, 0, 2);
            Assert.AreEqual(new[,]
            {
                { 9, 4, 7 },
                { 12, 5, 8 },
                { 15, 6, 9 }
            }, m.ToArray2D());
        }

        #endregion
    }
}