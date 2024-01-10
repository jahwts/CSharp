namespace Lab1.Tests
{
    public class FirstPartTests
    {
        [Theory]
        [InlineData(0, -10)]
        public void IsWrongLengthVectorCreatingFailed(int a, int b)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new FirstPart(a));
            Assert.Throws<ArgumentOutOfRangeException>(() => new FirstPart(b));
        }

        [Fact]
        public void IsMaxValueValid()
        {
            var firstPart = new FirstPart(100);
            Assert.Equal(firstPart.MaxValue(), firstPart.Vector.Max());
        }

        [Fact]
        public void IsVectorContainsPositives()
        {
            var firstPart = new FirstPart(100);
            Assert.Contains(firstPart.Vector, p => p > 0);
        }

        [Fact]
        public void IsIndexOfLastPositiveValid()
        {
            var firstPart = new FirstPart(100);
            Assert.Equal(Array.LastIndexOf(firstPart.Vector.ToArray(), firstPart.Vector.Last(n => n > 0)), firstPart.IndexOfLastPositive());
        }


        [Fact]
        public void IsSumValid()
        {
            var firstPart = new FirstPart(100);
            var arr = firstPart.Vector.ToArray();
            var lp = Array.LastIndexOf(arr, firstPart.Vector.Last(n => n > 0));
            double sum = 0;
            for (int i = 0; i < lp; i++)
            {
                sum += arr[i];
            }
            Assert.Equal(firstPart.Sum(), sum);
        }



    }
}