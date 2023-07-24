using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAndAnswers.Codewars._5Kyu
{
    internal class Kata
    {

        // RGB to hex conversion 5kyu
        // https://www.codewars.com/kata/513e08acc600c94f01000001
        public static string HexConverter(int r, int g, int b)
        {
            if (r > 255) r = 255;
            if (r < 0) r = 0;
            if (g > 255) g = 255;
            if (g < 0) g = 0;
            if (b > 255) b = 255;
            if (b < 0) b = 0;

            return $"{r.ToString("X2")}{g.ToString("X2")}{b.ToString("X2")}";

        }

        //Rot13 5kyu
        //https://www.codewars.com/kata/530e15517bc88ac656000716/solutions/csharp
        //https://www.codewars.com/kata/52223df9e8f98c7aa7000062/solutions/csharp
        public static string Rot13(string message)
        {
            char[] chars = message.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {

                    if ((int)chars[i] >= 65 && (int)chars[i] < 78)
                        chars[i] = (char)((int)chars[i] + 13);
                    else if ((int)chars[i] >= 78 && (int)chars[i] <= 90)
                        chars[i] = (char)((int)chars[i] - 13);
                    else if ((int)chars[i] >= 97 && (int)chars[i] <= 109)
                        chars[i] = (char)((int)chars[i] + 13);
                    else if ((int)chars[i] > 109 && (int)chars[i] <= 122)
                        chars[i] = (char)((int)chars[i] - 13);

                }
            }
            return new string(chars);
        }



    }
    #region Constructing a car
    //Constructing a car #1 - Engine and Fuel tank
    //https://www.codewars.com/kata/578b4f9b7c77f535fc00002f/train/csharp
    public class Car : ICar
    {
        public IFuelTankDisplay fuelTankDisplay;

        private IEngine engine;

        private IFuelTank fuelTank;


        public Car()
        {            
           
            
        }

        public Car(double fuelLevel)
        {
            
        }
               

        bool ICar.EngineIsRunning  => engine.IsRunning;

        public string EngineIsRunning()
        {
            if (engine.IsRunning) return "Engine should be running.";
            return "Engine could not be running.";
        }
        public void EngineStart()
        {
            engine.Start();
        }

        public void EngineStop()
        {
            engine.Stop();
        }

        public void Refuel(double liters)
        {
           this.fuelTank.Refuel(liters);
        }

        public void RunningIdle()
        {
            
            throw new NotImplementedException();
        }
    }

    public class Engine : IEngine
    {
        public bool IsRunning = false;

        bool IEngine.IsRunning => IsRunning;//throw new NotImplementedException();

        public void Consume(double liters)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            IsRunning = true;
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }

    public class FuelTank : IFuelTank
    {
        public double FillLevel => FillLevel;
        
        public bool IsOnReserve => throw new NotImplementedException();

        public bool IsComplete => throw new NotImplementedException();

        public void Consume(double liters)
        {
            throw new NotImplementedException();
        }

        public void Refuel(double liters)
        {
            throw new NotImplementedException();
        }
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        public double FillLevel => throw new NotImplementedException();

        public bool IsOnReserve => throw new NotImplementedException();

        public bool IsComplete => throw new NotImplementedException();
    }

    #endregion

    #region car interfaces
    public interface ICar
    {
        bool EngineIsRunning { get; }

        void EngineStart();

        void EngineStop();

        void Refuel(double liters);

        void RunningIdle();
    }

    public interface IEngine
    {
        bool IsRunning { get; }

        void Consume(double liters);

        void Start();

        void Stop();
    }

    public interface IFuelTank
    {
        double FillLevel { get; }

        bool IsOnReserve { get; }

        bool IsComplete { get; }

        void Consume(double liters);

        void Refuel(double liters);
    }

    public interface IFuelTankDisplay
    {
        double FillLevel { get; }

        bool IsOnReserve { get; }

        bool IsComplete { get; }
    }
    #endregion
}
