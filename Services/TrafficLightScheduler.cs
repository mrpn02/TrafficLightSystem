namespace TrafficLightSystem.Services
{
    using System.Timers;

    //seperate the scheduler logic in seperate file.
    public class TrafficLightScheduler : ITrafficLightTimer
    {
        public void Schedule(Action action, int delay)
        {
            Timer? timer = new Timer(delay);
            timer.Elapsed += (sender, e) =>
            {
                action.Invoke();
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }
    }
}
