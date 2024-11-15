## Weather Forecast Project (.NET CORE 8 Minimal API and REACT)
This project is a weather forecast application comprising a backend in **.NET Core 8** minimal API with **xUnit** test and a frontend in **React** with **jest** unit test. It provides the _predefine_ current and forecast weather information based on city name or any input.

This application uses:

- Backend: .NET Core 8 API 
- Frontend: React with custom components (App.js, Forecast.js, SearchEngine.js)

![image](https://github.com/user-attachments/assets/acecd9f0-afaa-4782-84ed-8029876733c1)

## Project Structure
    |── MyClassLib                                   # Service API
    |   └── WeatherService.cs        
    ├── MyTests                                      # .Net Unit test 
    |   └── WeatherServiceTest.cs 
    ├── MyWebApi                                     # .Net Request pipeline
    |   └── Program.cs                  
    ├── appview                                      # Frontend React App            
    |   |── src   
    |   |   └── components 
    |   |       |── App.css 
    |   |       |── App.js
    |   |       |── App.test.js 
    |   |       |── Forecast.js
    |   |       └── SearchEngine.js
    |   |── config.js
    |   |── index.css
    |   |── index.js
    |   └──styles.css
    ├── MyWebApi.sln  
    └── README.md

# Configuration and Execution

## CORS Configuration
 1- Backend
    The CORS service is registered in Program.cs. Update the CORS policy with your local port where the React app will run.

 2- Front end (MyWebApi)
   API Base URL in Frontend (appview/src/config.js)
   In config.js, set the BASE_URL to the URL where your API is hosted, typically your local backend server URL during development.

## Running the Project
1- Start the Backend:
   Open MyWebApi.sln in Visual Studio.
   Run the project from Visual Studio to start the .NET Core Web API.

2- Start the Frontend:
   Open a terminal and navigate to the React app directory:  your_local_path/appview
   Start the React application: npm start
   
   This should automatically open the app in your browser. Enter any city name and press Enter to see the weather results.
   
## Running Unit Tests



1- .NET Core Unit Tests
   Open Visual Studio, navigate to the Test Explorer, and click "Run All Tests" to execute all backend unit tests.
   ![image](https://github.com/user-attachments/assets/1c4ffc6b-6984-40e8-881d-f86e739227d2)


2- React Unit Tests
   To run the frontend unit tests: your_local_path/appview? 'npm test'
   
   To view the complete test coverage: 'npm test -- --coverage'

   You can also view the detailed coverage report in your browser by opening:
   your_local_path/appview/coverage/lcov-report/index.html   
   ![image](https://github.com/user-attachments/assets/02be2520-4264-4e59-aeb2-32ac1292df32)

Feel free to explore and modify the code to fit your requirements. For questions or issues, please raise an issue in this repository.
# Email: jawadahmed.info@gmail.com
