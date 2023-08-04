using ExercisesAndAnswers;
namespace Tests
{
    public class LastDigit
    {
        [Fact]
        public void Test0()
        {
            int[] arrayOfInts = new int[0];
            Assert.True(ExercisesAndAnswers._3Kyu.Kata.LastDigit(arrayOfInts) == 1);
        }

        [Fact]
        public void Test1()
        {
            int[] arrayOfInts = new int[] { 0, 0 };
            Assert.True(ExercisesAndAnswers._3Kyu.Kata.LastDigit(arrayOfInts) == 1);
        }

        [Fact]
        public void Test2()
        {
            int[] arrayOfInts = new int[] { 0, 0, 0 };
            Assert.True(ExercisesAndAnswers._3Kyu.Kata.LastDigit(arrayOfInts) == 0);
        }

        [Fact]
        public void Test3()
        {
            int[] arrayOfInts = new int[] { 1, 2 };
            Assert.True(ExercisesAndAnswers._3Kyu.Kata.LastDigit(arrayOfInts) == 1);
        }      


        [Fact]
        public void Test4()
        {
           int[] arrayOfInts = { 3, 4, 5 };
           Assert.True(ExercisesAndAnswers._3Kyu.Kata.LastDigit(arrayOfInts) == 1);
        }

        [Fact]
        public void Test5()
        {            
            int[] arrayOfInts = { 4, 3, 6 };
            Assert.True(ExercisesAndAnswers._3Kyu.Kata.LastDigit(arrayOfInts) == 4);
        }

        [Fact]
        public void Test6()
        {
            int[] arrayOfInts = { 7, 6, 21 };
            Assert.True(ExercisesAndAnswers._3Kyu.Kata.LastDigit(arrayOfInts) == 1);
        }

        [Fact]
        public void Test7()
        {
            int[] arrayOfInts = { 12, 30, 21 };
            Assert.True(ExercisesAndAnswers._3Kyu.Kata.LastDigit(arrayOfInts) == 6);
        }

        [Fact]
        public void Test8()
        {
            int[] arrayOfInts = new int[] { 2, 2, 2, 0 };
            Assert.True(ExercisesAndAnswers._3Kyu.Kata.LastDigit(arrayOfInts) == 4);
        }

        [Fact]
        public void Test9()
        {
            int[] arrayOfInts = { 937640, 767456, 981242 };
            Assert.True(ExercisesAndAnswers._3Kyu.Kata.LastDigit(arrayOfInts) == 0);
        }

        [Fact]
        public void Test10()
        {
            int[] arrayOfInts = { 123232, 694022, 140249 };
            Assert.True(ExercisesAndAnswers._3Kyu.Kata.LastDigit(arrayOfInts) == 6);
        }
        [Fact]
        public void Test11()
        {
            int[] arrayOfInts = { 499942, 898102, 846073 };
            Assert.True(ExercisesAndAnswers._3Kyu.Kata.LastDigit(arrayOfInts) == 6);
        }

        [Fact]
        public void Test12()
        {
            int[] arrayOfInts = { 500128, 746360, 55291, 516792 };
            Assert.True(ExercisesAndAnswers._3Kyu.Kata.LastDigit(arrayOfInts) == 6);
        }

    }
}