using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    //Other Solutions to check: https://www.codewars.com/kata/578b4f9b7c77f535fc00002f/solutions/csharp

    // The default fuel level of a car is 20 liters.
    // The maximum size of the tank is 60 liters.
    // Every call of a method from the car correlates to 1 second.
    // The fuel consumption in running idle is 0.0003 liter/second.
    // The fuel tank is on reserve, if the level is under 5 liters.


    public class Car : ICar
    {
        public IFuelTankDisplay fuelTankDisplay;
        private IEngine engine;
        private IFuelTank fuelTank;
                
        public Car()
        {
            engine = new Engine();
            fuelTank = new FuelTank();
            fuelTankDisplay = new FuelTankDisplay();
            EngineIsRunning = engine.IsRunning;                
            
        }

        public Car(double fuelLevel)
        {
            engine = new Engine();
            fuelTank = new FuelTank(fuelLevel);       
            fuelTankDisplay = new FuelTankDisplay(fuelLevel);
            EngineIsRunning = engine.IsRunning;
        }

        public bool EngineIsRunning { get; set; }

        bool ICar.EngineIsRunning { get { return EngineIsRunning; } }
              
        public void EngineStart()
        {
            if(fuelTank.FillLevel > 0)
            { 
            engine.Start();
            EngineIsRunning = engine.IsRunning;
            }
        }

        public void EngineStop()
        {
            engine.Stop();
            EngineIsRunning = engine.IsRunning;
        }

        public void Refuel(double liters)
        {
            if (fuelTank.FillLevel < 60 && liters>0) 
            {        
            fuelTank.Refuel(liters);
            fuelTankDisplay = new FuelTankDisplay(fuelTank.FillLevel);
            }
        }

        public void RunningIdle()
        {
            if(fuelTank.FillLevel > 0.0003 && EngineIsRunning)
            { 
            fuelTank.Consume(0.0003);
            fuelTankDisplay = new FuelTankDisplay(fuelTank.FillLevel);
            }
            else
            {
                EngineStop();
            }
        }
    }

    public class Engine : IEngine
    {        
        public bool IsRunning { get; set; }
        public Engine()
        {            
            IsRunning = false;
        }
        bool IEngine.IsRunning { get { return IsRunning; } } 

        public void Consume(double liters)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            IsRunning=true;
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }

    public class FuelTank : IFuelTank
    {
        public double _fillLevel { get; set; }
        public FuelTank() 
        {
            _fillLevel = 20; //default fuel level
            IsOnReserve = false;
            IsComplete = false;
        }

        public FuelTank(double fuelLevel)
        {
            if(fuelLevel>0) _fillLevel = fuelLevel; 
            else _fillLevel = 0;
            if(fuelLevel>60) _fillLevel = 60;
            if(fuelLevel<5) IsOnReserve = true;
            if(fuelLevel == 60) IsComplete = true;
        }


        public double FillLevel { get { return _fillLevel; } }
        
        public bool IsOnReserve { get; }

        public bool IsComplete { get; }

        public void Consume(double liters)
        {
            _fillLevel -= liters;
        }

        public void Refuel(double liters)
        {
            _fillLevel += liters;
            if (_fillLevel > 60) _fillLevel = 60;
            
        }
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        public double _fillLevel { get; set; }
        public FuelTankDisplay()
        {
            _fillLevel= 20;
            IsOnReserve = false;
            IsComplete = false;
        }

        public FuelTankDisplay(double fuelLevel)
        {
            _fillLevel = fuelLevel;
            if (fuelLevel > 0) _fillLevel = fuelLevel;
            else _fillLevel = 0;
            if (fuelLevel > 60) _fillLevel = 60;
            if (fuelLevel<5) IsOnReserve= true;
            if (fuelLevel == 60) IsComplete = true;
        }
        
        public double FillLevel { get { return Math.Round(_fillLevel,2); } }

        public bool IsOnReserve { get; }

        public bool IsComplete { get; }
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
