using ExercisesAndAnswers;
namespace Tests
{
    public class SquareIntoSquares
    {
        [Fact]
        public void Test0()
        {
            long n = 11;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.decompose(n) == "1 2 4 10");
        }

        [Fact]
        public void Test1()
        {
            long n = 625;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.decompose(n) == "2 5 8 34 624");
        }

        [Fact]
        public void Test2()
        {
            long n = 7654322;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.decompose(n) == "1 4 11 69 3912 7654321");
        }

        [Fact]
        public void Test3()
        {
            long n = 7100;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.decompose(n) == "2 3 5 119 7099");
        }      


        [Fact]
        public void Test4()
        {
            long n = 1234567;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.decompose(n) == "2 8 32 1571 1234566");
        }

        [Fact]
        public void Test5()
        {
            long n = 3;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.decompose(n) == null);
        }

    }
}