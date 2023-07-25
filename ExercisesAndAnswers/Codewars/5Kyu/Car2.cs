using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesAndAnswers.Codewars._5Kyu.Car2
{
    #region Constructing a car
    //Constructing a car #2 - Driving
    //https://www.codewars.com/kata/578df8f3deaed98fcf0001e9

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
        public IDrivingInformationDisplay drivingInformationDisplay; // car #2 
        private IDrivingProcessor drivingProcessor; // car #2

        private int _maxAcceleration;
        
        public Car(double fuelLevel = 20, int maxAcceleration = 10)
        {
            if (maxAcceleration > 20) maxAcceleration = 20;
            if (maxAcceleration < 5) maxAcceleration = 5;

            _maxAcceleration = maxAcceleration;
            fuelTank = new FuelTank(fuelLevel);
            fuelTankDisplay = new FuelTankDisplay(fuelTank);
            engine = new Engine(fuelTank);
            drivingProcessor = new DrivingProcessor(maxAcceleration);
            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);

        }

        public bool EngineIsRunning { get { return engine.IsRunning; } }
        
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
            if (fuelTank.FillLevel <= 0) engine.Stop();
        }

        public void BrakeBy(int speed)
        {
            if (speed > 10) speed = 10;
            if (speed < 0) speed = 0;
            drivingProcessor.ReduceSpeed(speed);
            //engine.Consume(currentConsumption());
            //if (fuelTank.FillLevel <= 0) engine.Stop();
        } // car #2

        public void Accelerate(int speed)
        {
            Console.WriteLine($"target speed: {speed}, current speed: {drivingProcessor.ActualSpeed} current tank:{fuelTank.FillLevel} ");
            if (!EngineIsRunning) return;            
            if(speed<0) speed = 0;
            if (speed < drivingProcessor.ActualSpeed)
            {
                FreeWheel();
                return;
            }
            drivingProcessor.IncreaseSpeedTo(speed);                  
            engine.Consume(currentConsumption());
            if (fuelTank.FillLevel <= 0) engine.Stop();
        } // car #2

        public double currentConsumption()
        {
            double amountOfFuel = 0;
            if (drivingProcessor.ActualSpeed >= 1 && drivingProcessor.ActualSpeed <= 60) amountOfFuel = 0.0020;
            if (drivingProcessor.ActualSpeed >= 61 && drivingProcessor.ActualSpeed <= 100) amountOfFuel = 0.0014;
            if (drivingProcessor.ActualSpeed >= 101 && drivingProcessor.ActualSpeed <= 140) amountOfFuel = 0.0020;
            if (drivingProcessor.ActualSpeed >= 141 && drivingProcessor.ActualSpeed <= 200) amountOfFuel = 0.0025;
            if (drivingProcessor.ActualSpeed >= 201) amountOfFuel = 0.0030;
            return amountOfFuel;
        }

        public void FreeWheel()
        {
            drivingProcessor.ReduceSpeed(1);
            if(drivingProcessor.ActualSpeed == 0) RunningIdle();
            
        } // car #2
    }

    public class DrivingInformationDisplay : IDrivingInformationDisplay // car #2
    {
        private IDrivingProcessor  _drivingProcessor;
        public DrivingInformationDisplay(IDrivingProcessor drivingProcessor)
        {
             _drivingProcessor = drivingProcessor;
        }
        public int ActualSpeed { get { return _drivingProcessor.ActualSpeed; } }
    }

    public class DrivingProcessor : IDrivingProcessor // car #2
    {
        private int _actualSpeed = 0;
        private const int _maxSpeed = 250;
        private int _maxAcceleration;
        public int ActualSpeed { get { return _actualSpeed; } }

        public DrivingProcessor(int maxAcceleration = 10)
        {
            _actualSpeed = ActualSpeed;  
            _maxAcceleration = maxAcceleration;
        }
        public void IncreaseSpeedTo(int targetSpeed)
        {
            int amountToIncrease = targetSpeed - _actualSpeed;
            if(amountToIncrease > _maxAcceleration) amountToIncrease = _maxAcceleration;
            if(targetSpeed <= _maxSpeed)  _actualSpeed += amountToIncrease;
            if(targetSpeed > _maxSpeed) _actualSpeed = _maxSpeed;
            if (targetSpeed < 0) return;//_actualSpeed = 0;
        }

        public void ReduceSpeed(int speedReduceBy)
        {
            _actualSpeed -= speedReduceBy;
            if (_actualSpeed < 0) _actualSpeed = 0;
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

        public bool IsRunning { get { return _isRunning; } }
        

        public void Consume(double liters)
        {
            if (_isRunning)
            {
                _fuelTank.Consume(liters);
                if (_fuelTank.FillLevel <= 0)
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
                
        public FuelTank(double fillLevel)
        {
            if (fillLevel < 0) fillLevel = 0;            
            if (fillLevel > _tankSize) fillLevel = _tankSize;          
            _fillLevel = fillLevel;
        }

        public double FillLevel { get { return _fillLevel; } }     

        public bool IsOnReserve { get { return _fillLevel < 5; } }
       

        public bool IsComplete { get { return _fillLevel == _tankSize; } }
      
        public void Consume(double liters)
        {
            _fillLevel -= liters;
            _fillLevel = Math.Round(_fillLevel, 10);

            if (_fillLevel < 0) _fillLevel = 0;
            
        }

        public void Refuel(double liters)
        {
            _fillLevel += liters; //add liters to tank
            if (_fillLevel > _tankSize) _fillLevel = _tankSize; //sum cannot exceed tank size
            
        }
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        private IFuelTank _fuelTank;

        public FuelTankDisplay(IFuelTank fuelTank)
        {
            _fuelTank = fuelTank;
        }

        public double FillLevel { get { return Math.Round(_fuelTank.FillLevel, 2); } }       

        public bool IsOnReserve { get { return _fuelTank.IsOnReserve; } }       

        public bool IsComplete { get { return _fuelTank.IsComplete; } }
        
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

    public interface IDrivingInformationDisplay // car #2
    {
        int ActualSpeed { get; }
    }

    public interface IDrivingProcessor // car #2
    {
        int ActualSpeed { get; }

        void IncreaseSpeedTo(int speed);

        void ReduceSpeed(int speed);
    }


    #endregion
}
