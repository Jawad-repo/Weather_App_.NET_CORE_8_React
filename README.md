# Weather Forecast Project
This project is a weather forecast application comprising a backend in .NET Core 8 and a frontend in React. It provides current and forecast weather information based on city name input.

This application uses:
Backend: .NET Core 8 API with WeatherService.cs
Frontend: React with custom components (App.js, Forecast.js, SearchEngine.js)

## Project Structure
|-MyClassLib
|--WeatherService.cs
|-MyTests
|--WeatherServiceTest.cs
|-MyWebApi
|--Program.cs
|-appview (React Application)
|--src
|---components
|----App.css
|----App.js
|----App.test.js
|----Forecast.js
|----SearchEngine.js
|--config.js
|--index.css
|--index.js
|--styles.css
|-MyWebApi.sln


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

2- React Unit Tests
   To run the frontend unit tests: your_local_path/appview? npm test
   
   To view the complete test coverage: npm test -- --coverage

   You can also view the detailed coverage report in your browser by opening:
   your_local_path/appview/coverage/lcov-report/index.html   

Feel free to explore and modify the code to fit your requirements. For questions or issues, please raise an issue in this repository.
# Email: jawadahmed.info@gmail.com
