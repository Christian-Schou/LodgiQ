# Lodgingly

A smart, efficient, and user-friendly hotel management system built with .NET, designed to simplify reservations, guest
management, and hotel operations.

## What is this project?
Lodgingly is a modular monolithic application written in .NET 9.0. Each module represents different business logic and
are well-defined in terms of boundaries. Each module have logical boundaries, making it a loosely coupled system which
promotes separation of concerns.

The project is made as a proof of concept project where I want to experiment with .NET and learn some new architectural
techniques. You are more than welcome to fork the project and extend on it if you would like to. The goal is to create
a production grade application and deliver it as a Docker image that real hotels can use.

## Technologies
Lodgingly is written in C#/.NET and builds upon well-known NuGet packages from other great authors to make up a solid
and robust application. The backend exposes the API's and takes care of the heavy lifting in terms of logic. The frontend
is written in .NET as well and uses Blazor to create a SPA (Single Page Application). It uses Keycloak for identity
management, extracting out a big and complex service into a well-known and tested solution.

## Roadmap
- [ ] Shared framework in clean architecture style.
  - [x] Domain layer.
  - [x] Application layer.
  - [x] Infrastructure layer.
  - [ ] Presentation layer.
- [ ] Keycloak Authentication/Authorization.
- [ ] Domain Driven Design
- [ ] Distributed Caching
- [ ] Inbox/Outbox messaging between modules for events.