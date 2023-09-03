using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tests.Codewars._5Kyu
{
    public class RoadkillDetective    
    {
        [Fact]
        public void Penguin()
        {
            string photo = "======pe====nnnnnn=======================n=n=ng====u==iiii=iii==nn========================n=";

            Assert.True(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo) == "penguin");
        }

        [Fact]
        public void Hyena()
        {
            string photo = "==========h===yyyyyy===eeee=n==a========";
            Assert.True(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo) == "hyena");
        }

        [Fact]
        public void BearReversed()
        {
           string photo = "=====r=rrr=rra=====eee======bb====b=======";
           Assert.True(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo) == "bear");

        }

        [Fact]
        public void Baboon()
        {
           string  photo = "===b=b==========a=a=a=a=a=a=a=boo======n=====";
            Assert.True(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo) == "baboon");
        }


        [Fact]
        public void NoAnimal()
        {
            string photo = "=====";
            Assert.True(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo) == "??");
        }

        [Fact]
        public void AnimalIsUntouched()
        {

            string photo = "=== snake =========";
            Assert.True(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo) == "??");
        }

        [Fact]
        public void SquirrelReversed()
        {

            string photo = "====l===e===r=======riuqs=====";
            Assert.True(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo) == "squirrel");
        }

        
        
            [Fact]
        public void AardvarkReversed()
        {

            string photo = "=====k====r=a=vvvv==d=d=d=d=r==a=a=======";
            Assert.True(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo) == "aardvark");
        }

        [Fact]
        public void Rabbit()
        {

            string photo = "====rraabbiitt==";
            Assert.True(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo) == "rabbit");
        }

        [Fact]
        public void Foxy()
        {

            string photo = "===f====o===x===y=====";
            Assert.True(ExercisesAndAnswers._5Kyu.Kata.RoadKill(photo) == "??");
        }



    }
}
