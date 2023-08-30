namespace TrafficLightSystem.Models
{
    public class TrafficLight
    {
        public TrafficDirection TrafficDirection { get; set; }
        public TrafficLightSignal TrafficLightSignal { get; set; }
    }


    //enums for N,E,W,S and traffic signal
    public enum TrafficDirection
    {
        South,
        West,
        North,
        East,
        NorthtoRight
    }

    public enum TrafficLightSignal
    {
        Red,
        Yellow,
        Green
    }

}
