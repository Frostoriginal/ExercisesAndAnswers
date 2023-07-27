using ExercisesAndAnswers.Codewars._5Kyu;

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

            #region job test
            /*
            List<IProject> currentProjects = new List<IProject>();
            currentProjects.Add(new project {Name="a", Start=new DateTime(2023,07,27), End=new DateTime(2023,07,29)});
            currentProjects.Add(new project { Name = "b", Start = new DateTime(2023, 07, 16), End = new DateTime(2023, 07, 20) });
            project toCheck = new project() { Name = "c", Start = new DateTime(2023, 07, 01), End = new DateTime(2023, 07, 28) };

            static bool IsProjectPossible(List<IProject> existing, IProject project)
            {
                foreach (IProject item in existing)
                {
                    if (item.Start.Date < project.End.Date && project.Start.Date < item.End.Date) return false;
                }
                return true;
            }

            Console.WriteLine(IsProjectPossible(currentProjects, toCheck));
            */
            #endregion

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

        #region job test
        /*
        public class project : IProject
        {
            public string Name {get; set;}
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
        }
        public interface IProject
        {
            string Name { get; set; }
            DateTime Start { get; set; }
            DateTime End { get; set; }
        }*/
        #endregion






    }

}