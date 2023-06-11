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
        Console.WriteLine(MathWorks.PathFinder2(a));
    }
}
}