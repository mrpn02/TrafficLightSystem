using System;
using System.Collections.Generic;
using System.Linq;
using TrafficLightSystem.Models;

namespace TrafficLightSystem.Services
{
    public class TrafficLightService
    {
        //All numbers for time are in milliseconds

        private readonly List<TrafficLight> trafficLights;
        private readonly ITrafficLightTimer scheduler;

        //constructor
        public TrafficLightService() : this(new TrafficLightScheduler())
        {
        }

        public TrafficLightService(ITrafficLightTimer scheduler)
        {
            this.scheduler = scheduler;

            trafficLights = new List<TrafficLight>
            {
                new TrafficLight { TrafficDirection = TrafficDirection.South, TrafficLightSignal = TrafficLightSignal.Red },
                new TrafficLight { TrafficDirection = TrafficDirection.West, TrafficLightSignal = TrafficLightSignal.Red },
                new TrafficLight { TrafficDirection = TrafficDirection.North, TrafficLightSignal = TrafficLightSignal.Red },
                new TrafficLight { TrafficDirection = TrafficDirection.East, TrafficLightSignal = TrafficLightSignal.Red },
                new TrafficLight { TrafficDirection = TrafficDirection.NorthtoRight, TrafficLightSignal = TrafficLightSignal.Red }
            };

            StartTrafficCycle();
        }

        private void StartTrafficCycle()
        {
            SetNorthSouthToGreen();
        }

        private void SetNorthSouthToGreen()
        {
            GetTrafficLight(TrafficDirection.South).TrafficLightSignal = TrafficLightSignal.Green;
            GetTrafficLight(TrafficDirection.North).TrafficLightSignal = TrafficLightSignal.Green;

            scheduler.Schedule(SetNorthSouthToYellow, IsPeakTime() ? 40000 : 20000);
        }

        private void SetNorthSouthToYellow()
        {
            GetTrafficLight(TrafficDirection.South).TrafficLightSignal = TrafficLightSignal.Yellow;
            GetTrafficLight(TrafficDirection.North).TrafficLightSignal = TrafficLightSignal.Yellow;

            scheduler.Schedule(SetNorthSouthToRed, 5000);
        }

        private void SetNorthSouthToRed()
        {
            GetTrafficLight(TrafficDirection.South).TrafficLightSignal = TrafficLightSignal.Red;
            GetTrafficLight(TrafficDirection.North).TrafficLightSignal = TrafficLightSignal.Red;
            GetTrafficLight(TrafficDirection.NorthtoRight).TrafficLightSignal = TrafficLightSignal.Green;

            scheduler.Schedule(() =>
            {
                GetTrafficLight(TrafficDirection.NorthtoRight).TrafficLightSignal = TrafficLightSignal.Red;
                SetEastWestToGreen();
            }, 10000);
        }

        private void SetEastWestToGreen()
        {
            GetTrafficLight(TrafficDirection.West).TrafficLightSignal = TrafficLightSignal.Green;
            GetTrafficLight(TrafficDirection.East).TrafficLightSignal = TrafficLightSignal.Green;

            scheduler.Schedule(SetEastWestToYellow, IsPeakTime() ? 10000 : 20000);
        }

        private void SetEastWestToYellow()
        {
            GetTrafficLight(TrafficDirection.West).TrafficLightSignal = TrafficLightSignal.Yellow;
            GetTrafficLight(TrafficDirection.East).TrafficLightSignal = TrafficLightSignal.Yellow;

            scheduler.Schedule(() =>
            {
                GetTrafficLight(TrafficDirection.West).TrafficLightSignal = TrafficLightSignal.Red;
                GetTrafficLight(TrafficDirection.East).TrafficLightSignal = TrafficLightSignal.Red;
                SetNorthSouthToGreen();
            }, 5000);
        }

        private TrafficLight GetTrafficLight(TrafficDirection direction)
        {
            return trafficLights.FirstOrDefault(light => light.TrafficDirection == direction);
        }

        private bool IsPeakTime()
        {
            var currentTime = DateTime.Now.TimeOfDay;
            return (currentTime >= TimeSpan.FromHours(8) && currentTime <= TimeSpan.FromHours(10))
                   || (currentTime >= TimeSpan.FromHours(17) && currentTime <= TimeSpan.FromHours(19));
        }

        public IEnumerable<TrafficLight> GetCurrentState()
        {
            return trafficLights;
        }
    }
}
