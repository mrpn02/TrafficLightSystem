# TrafficLightSystem
This is demo traffic light system. The backend is WEBAPI while the front end is an HTML with JS and hardcoded fetch. (Note: change the fetch to match the API in the swagger UI)

**SwaggerUI**
![image](https://github.com/mrpn02/TrafficLightSystem/assets/128514124/cf0a0dcd-48aa-42f0-be3f-2f8898d411f0)



**HTML**

![image](https://github.com/mrpn02/TrafficLightSystem/assets/128514124/7a51a1af-8071-40c6-83bc-6863dba2e778)




To run: 
- 1st clone this github repo in your local
- 2nd run the backend in visual studio or dotnet run in CMD
- 3rd run the frontend 
    - In CMD navigate to the solution file until you get to the frontend-demo folder
    - run npm start
    - click the refresh button (remember the test simulate 20 secs or 40 for rush hour, just click the refresh button)

Improvements
  - allow asynchronous refreshes every 20/40 secs so I dont need click the button everytime.
  - unit testing in xunit. But I implemented the interfaces to allow for mocking / unit testing.
