using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAndAnswers.Codewars._5Kyu.Car1
{
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
        /*
        public Car()
        {
            fuelTank = new FuelTank();
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            engine = new Engine(fuelTank);
        }
        
        public Car(double fuelLevel)
        {
            fuelTank = new FuelTank(fuelLevel);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            engine = new Engine(fuelTank);
        }
        */
        public Car(double fuelLevel = 20)
        {
            fuelTank = new FuelTank(fuelLevel);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            engine = new Engine(fuelTank);
        }

        public bool EngineIsRunning
        {
            get
            {
                return engine.IsRunning;
            }
        }

        public void EngineStart()
        {
            if ((!engine.IsRunning) && (fuelTank.FillLevel > 0))
            {
                engine.Start();
            }
        }

        public void EngineStop()
        {
            if (engine.IsRunning)
            {
                engine.Stop();
            }
        }

        public void Refuel(double liters)
        {
            fuelTank.Refuel(liters);
        }

        public void RunningIdle()
        {
            engine.Consume(0.0003);
        }
    }

    public class Engine : IEngine
    {
        private bool _isRunning = false;

        private IFuelTank _fuelTank;

        public Engine(IFuelTank fuelTank)
        {
            _fuelTank = fuelTank;
        }

        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
        }

        public void Consume(double liters)
        {
            if (_isRunning)
            {
                _fuelTank.Consume(liters);
                if (_fuelTank.FillLevel == 0)
                {
                    Stop();
                }
            }
        }

        public void Start()
        {
            _isRunning = true;
        }

        public void Stop()
        {
            _isRunning = false;
        }
    }

    public class FuelTank : IFuelTank
    {
        private double _fillLevel;

        private const double _tankSize = 60;

        /*
        public FuelTank()
        {
            _fillLevel = 20;
        }
        */
        public FuelTank(double fillLevel)
        {
            if (fillLevel < 0)
            {
                fillLevel = 0;
            }
            if (fillLevel > _tankSize)
            {
                fillLevel = _tankSize;
            }

            _fillLevel = fillLevel;
        }

        public double FillLevel
        {
            get
            {
                return _fillLevel;
            }
        }

        public bool IsOnReserve
        {
            get
            {
                return _fillLevel < 5;
            }
        }

        public bool IsComplete
        {
            get
            {
                return _fillLevel == _tankSize;
            }
        }

        public void Consume(double liters)
        {
            _fillLevel -= liters;
            _fillLevel = Math.Round(_fillLevel, 10);

            if (_fillLevel < 0)
            {
                _fillLevel = 0;
            }
        }

        public void Refuel(double liters)
        {
            _fillLevel += liters;
            if (_fillLevel > _tankSize)
            {
                _fillLevel = _tankSize;
            }
        }
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        private IFuelTank _fuelTank;

        public FuelTankDisplay(IFuelTank fuelTank)
        {
            _fuelTank = fuelTank;
        }

        public double FillLevel
        {
            get
            {
                return Math.Round(_fuelTank.FillLevel, 2);
            }
        }

        public bool IsOnReserve
        {
            get
            {
                return _fuelTank.IsOnReserve;
            }
        }

        public bool IsComplete
        {
            get
            {
                return _fuelTank.IsComplete;
            }
        }
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
