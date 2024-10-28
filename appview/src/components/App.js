import React, { useState, useEffect, useRef } from "react";
import SearchEngine from "./SearchEngine";
import Forecast from "./Forecast";
import { BASE_URL } from "./../config";
import axios from "axios";
import "../styles.css";

function App() {
  const [query, setQuery] = useState("");
  const [weather, setWeather] = useState({
    loading: true,
    data: {
      condition: "", // Default empty string to avoid undefined issues
      temperature: "",
      wind: { speed: 0 }, // Default wind.speed to 0
    },
    error: false,
  });

  const lastQueryRef = useRef("");

  const search = async (event) => {
    event.preventDefault();
    if (
      (event.type === "click" || (event.type === "keypress" && event.key === "Enter")) &&
      (query !== lastQueryRef.current)
    ) {
      lastQueryRef.current = query;
      setWeather({ ...weather, loading: true });
      const url = `${BASE_URL}/weatherforecast/${query}`;
      try {
        const res = await axios.get(url);
        setWeather({ data: res.data, loading: false, error: false });
      } catch (error) {
        setWeather({ ...weather, data: {}, error: true });
      }
    }
  };

  useEffect(() => {
    const fetchData = async () => {
      const url = `${BASE_URL}/weatherforecast/${query}`;
      try {
        const response = await axios.get(url);
        setWeather({ data: response.data, loading: false, error: false });
      } catch (error) {
        setWeather({ data: {}, loading: false, error: true });
      }
    };
    fetchData();
  }, []);

  return (
    <div className="App">
      <SearchEngine query={query} setQuery={setQuery} search={search} />
      {weather.loading && (
        <>
          <br />
          <br />
          <h4>Searching..</h4>
        </>
      )}
      {weather.error && (
        <>
          <br />
          <br />
          <span className="error-message">
            <span style={{ fontFamily: "font" }}>
              Sorry, city not found. Please try again.
            </span>
          </span>
        </>
      )}
      {weather && weather.data && weather.data.condition && (
        <Forecast weather={weather} />
      )}
    </div>
  );
}

export default App;
