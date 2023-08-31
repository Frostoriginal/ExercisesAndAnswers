using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Codewars._4Kyu
{
    public class BlockSequences
    {
        [Fact]
        public void Test0()
        {           
            long n = 1;
            int expected = 1;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.solve(n) == expected);
        }
        [Fact]
        public void Test1()
        {
            long n = 2;
            int expected = 1;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.solve(n) == expected);
        }

        [Fact]
        public void Test2()
        {
            long n = 3;
            int expected = 2;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.solve(n) == expected);
        }

        [Fact]
        public void Test3()
        {
            long n = 100;
            int expected = 1;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.solve(n) == expected);
        }

        [Fact]
        public void Test4()
        {
            long n = 2100;
            int expected = 2;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.solve(n) == expected);
        }

        [Fact]
        public void Test5()
        {
            long n = 3100;
            int expected = 2;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.solve(n) == expected);
        }

        [Fact]
        public void Test6()
        {
            long n = 55;
            int expected = 1;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.solve(n) == expected);
        }

        [Fact]
        public void Test7()
        {
            long n = 123456;
            int expected = 6;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.solve(n) == expected);
        }

        /*
        [Fact]
        public void Test8()
        {
            long n = 123456789;
            int expected = 3;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.solve(n) == expected);
        }

        [Fact]
        public void Test9()
        {
            long n = 999999999999999999;
            int expected = 4;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.solve(n) == expected);
        }

        [Fact]
        public void Test9()
        {
            long n = 1000000000000000000;
            int expected = 1;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.solve(n) == expected);
        }

          [Fact]
        public void Test10()
        {
            long n = 999999999999999993;
            int expected = 7;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.solve(n) == expected);
        }



        */



    }
}
