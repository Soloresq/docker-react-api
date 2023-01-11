# Docker React API

Sample application contains two applications:

__Frontend.Api__  
ASP.Net Core 6 based WebAPI providing a dummy controller

__Frontend.App__  
ASP.Net Core 6 based WebApp serving a React App written in TypeScript (accessing the Frontend.Api)

Both apps are running in seperated containers.

## Prerequisites
- Install latest Docker Desktop for Windows
- Install latest Node
- Start Docker Desktop for Windows

## Getting started
- Navigate into 'Docker' directory
- Type `docker compose up` to start the containers and setup their network
- Type `docker compose down` to stop the containers and remove their network

The app can be accessed at http://localhost:5000  
The swagger ui of the api can be accessed at http://localhost:5002/swagger/index.html
