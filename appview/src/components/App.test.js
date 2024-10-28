import React from 'react';
import { render, screen, fireEvent, waitFor, act } from '@testing-library/react';
import '@testing-library/jest-dom';
import App from './App';
import { BASE_URL } from "./../config";
import axios from 'axios';
import Forecast from './Forecast';

jest.mock('axios');

jest.mock('react-animated-weather', () => {
  return function MockedReactAnimatedWeather(props) {
    return <div>{props.icon}</div>; // Mock output
  };
});

describe('App Component', () => {
  beforeEach(() => {
    axios.get.mockReset();
  });

  afterEach(() => {
    jest.clearAllMocks();  // Clear any mock state between tests
    jest.clearAllTimers();  // Clear any timers if used
  });

  const mockWeatherData = {
    city: "City",
    country: "rwp",
    coordinates: {
      "longitude": -0.7072694,
      "latitude": 49.0579403
    },
    condition: {"description": "Chilly",},
    temperature: {"current": 35,},
    wind: { speed: 5,  degree: 301},
    time: 1730150457
    };

  
  it('renders the initial state with loading and error message', async () => {

    render(<App />);

    expect(screen.queryByText(/Searching\.\./i)).toBeInTheDocument();
    await waitFor(() => {
      expect(screen.getByText(/Sorry, city not found. Please try again./i)).toBeInTheDocument();
    });

  });

  it("Weather API has been called", async () => {
    render(<App />);
  
 
    await act(async () => {
      fireEvent.change(screen.getByRole("textbox"), { target: { value: "city name" } });
      fireEvent.click(screen.getByRole('button', { name: /search/i }));
    });

    expect(axios.get).toHaveBeenCalledWith(`${BASE_URL}/weatherforecast/`);

  });

  it("should fetch data when input is entered and Enter is pressed", async () => {

    axios.get.mockResolvedValueOnce({ data: mockWeatherData });
  
    render(<App />);

    await act(async () => {
      fireEvent.change(screen.getByRole("textbox"), { target: { value: "city name" } });
      fireEvent.keyPress(screen.getByRole("textbox"), { key: "Enter", code: "Enter", charCode: 13 });
    });

    await waitFor(() => {
      expect(screen.getByText(/Chilly/i)).toBeInTheDocument();
      expect(screen.getByText(/35/i)).toBeInTheDocument();
      expect(screen.getByText(/5m\/s/i)).toBeInTheDocument();
    });

  });

  it('toggles temperature unit on click', async () => {
  
    axios.get.mockResolvedValueOnce({ data: mockWeatherData });
  
    render(<App />);

    await act(async () => {
      fireEvent.change(screen.getByRole("textbox"), { target: { value: "city name" } });
      fireEvent.click(screen.getByRole('button', { name: /search/i }));
    });

    const tempToggle = screen.getByText(/°C | °F/i);

    fireEvent.click(tempToggle);

    expect(tempToggle).toHaveTextContent(/°F | °C/i);

    fireEvent.click(tempToggle);

    expect(tempToggle).toHaveTextContent(/°C | °F/i);
  });

});
