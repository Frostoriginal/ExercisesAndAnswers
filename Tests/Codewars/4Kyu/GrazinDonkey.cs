using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Codewars._4Kyu
{
    public class GrazinDonkey
    {
        [Fact]
        public void Test0()
        {
            int fieldDiameter = 200;
            double eatenRatio = 0.5;
            int expected = 115;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.GetRopeLength(fieldDiameter, eatenRatio) == expected);
        }

        [Fact]
        public void Test1()
        {
            int fieldDiameter = 10;
            double eatenRatio = 0.5;
            int expected = 5;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.GetRopeLength(fieldDiameter, eatenRatio) == expected);
        }

        [Fact]
        public void Test2()
        {
            int fieldDiameter = 1277841897;
            double eatenRatio = 0.5662171276606766;
            int expected = 800039292;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.GetRopeLength(fieldDiameter,eatenRatio) == expected );
        }

        [Fact]
        public void Test3()
        {           
            int fieldDiameter = 1774659813;
            double eatenRatio = 0.910237788102865;
            int expected = 1567186079;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.GetRopeLength(fieldDiameter, eatenRatio) == expected);
        }

        [Fact]
        public void Test4()
        {
            int fieldDiameter = 26053;
            double eatenRatio = 0.5706236655715278;
            int expected = 16391;
            Assert.True(ExercisesAndAnswers._4Kyu.Kata.GetRopeLength(fieldDiameter, eatenRatio) == expected);
        }
    }
}
