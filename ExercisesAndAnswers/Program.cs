using ExercisesAndAnswers.Codewars._5Kyu;
using ExercisesAndAnswers.Codewars._5Kyu.Car2;

namespace ExercisesAndAnswers { 
internal class Program
{
    private static void Main(string[] args)
    {
        string a =
                "..WWWWWWWWWWWWWWWWWW\n" +
                "W.................WW\n" +
                "W.WWWWWWWWWWWWWWW.WW\n" +
                "W.WW..............WW\n" +
                "W.WW.WWWWWWWWWWWWWWW\n" +
                "W.WW.WWWWWWWWWWWWWWW\n" +
                "W.WW.WWWWWWWWWWWWWWW\n" +
                "W.WW................\n" +
                "W.WWWWWWWWWWWWWWWWW.\n" +
                "W.WWWWWWWWWWWWWWWWW.\n" +
                "W.WWWWWWWWWWWWWWWWW.\n" +
                "W.WWWWWWWWWWWWWWWWW.\n" +
                "W.WWWWWWWWWWWWWWWWW.\n" +
                "W.WWWWWWWWWWWWWWWWW.\n" +
                "W.WWWWWWWWWWWWWWWWW.\n" +
                "W.WWWWWWWWWWWWWWWWW.\n" +
                "W.WWWWWWWWWWWWWWWWW.\n" +
                "W.WWWWWWWWWWWWWWWWW.\n" +
                "W.WWWWWWWWWWWWWWWWW.\n" +
                "W...................";
        //MathWorks.mazeConvertor(a);
        string c = "......\n" +
                "......\n" +
                "......\n" +
                "......\n" +
                "......\n" +
                "......";
      //  Console.WriteLine(MathWorks.PathFinder2(a));

            //Fibonacci memoization
           // Func<int, int> fibonacci = null;
           // fibonacci = Memoizer.Memoize((int n1) => Fibonacci(n1, fibonacci));
            //Console.WriteLine($"{fibonacci(10)}");

            //int max value = 2147483647
         //   Console.WriteLine($"{ExercisesAndAnswers._4Kyu.Kata.Factorial2(100)}");

         //   Console.WriteLine($"{ExercisesAndAnswers._6Kyu.Kata.High("what time are we climbing up to the volcano")}");

           Car car = new Car(1,20);
            car.EngineStart();
            Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));
            int y = car.drivingInformationDisplay.ActualSpeed; //should be 100
            //car.FreeWheel();
            //car.FreeWheel();
            //car.FreeWheel();
            
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            y = car.drivingInformationDisplay.ActualSpeed; //should be 97
            double u = car.fuelTankDisplay.FillLevel;
            int z = 0;


        }

        int Fibonacci(int n1)
        {
            return Fibonacci(n1, Fibonacci);
        }

        static int Fibonacci(int n1, Func<int,int> fibonacci)
        {
            if (n1 <= 2) return 1;
            return fibonacci(n1 - 1) + fibonacci(n1 - 2);
        }



    }
}