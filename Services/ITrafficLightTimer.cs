namespace TrafficLightSystem.Services
{

    //interface for TrafficLightScheduler
    public interface ITrafficLightTimer
    {
        void Schedule(Action action, int delay);
    }
}
