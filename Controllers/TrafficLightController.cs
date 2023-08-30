using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TrafficLightSystem.Models;
using TrafficLightSystem.Services;

namespace TrafficLightSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrafficLightsController : ControllerBase
    {
        private readonly TrafficLightService _trafficLightService;

        public TrafficLightsController(TrafficLightService trafficLightService)
        {
            _trafficLightService = trafficLightService ?? throw new ArgumentNullException(nameof(trafficLightService));
        }

        // Endpoint to get the current state of the traffic lights
        [HttpGet]
        public IEnumerable<TrafficLight> GetCurrentState()
        {
            return _trafficLightService.GetCurrentState();
        }
    }
}
