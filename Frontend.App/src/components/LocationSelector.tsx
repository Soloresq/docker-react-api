import {FunctionComponent, useEffect, useState} from "react";

type WeatherForecastDto = {
    date: string,
    temperatureC: number,
    temperatureF: number,
    summary: string 
}

export const LocationSelector: FunctionComponent = ({
}) => {
    const [forecasts, setForecasts] = useState<WeatherForecastDto[]>([]);
   useEffect(() => {
      fetch('http://localhost:5002/WeatherForecast')
         .then((response) => response.json())
         .then((data) => {
            console.log(data);
            setForecasts(data);
         })
         .catch((err) => {
            console.log(err.message);
         });
   }, []);
    
    return (
        <>
            {forecasts.map((forecast) => {
                return (
                    <>
                      <h2>{forecast.summary}</h2>
                      <div>Date: {forecast.date}</div>
                      <div>Temperature: {forecast.temperatureC} °C</div>
                      <div>Temperature: {forecast.temperatureF} °F</div>
                    </>
                );
            })}
        </>
    )
};