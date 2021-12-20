# Southern Cross Health Society Member Search App
Southern Cross Developer Technical Challenge

## Overview
A single page application that enable a user to search for a member using the member's policy number or their member card number.  The results will be displayed based on the query parameters and allow a user to iterate through previous search results.

<br/>

## Technologies used
* [ASP.NET Core 3.1](https://dotnet.microsoft.com/en-us/learn/aspnet/what-is-aspnet-core)
* [.NET Standard 2.0](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)
* [LiteDB 5.0.11](https://www.litedb.org/) 
* [Bootsrap v4.0](https://getbootstrap.com/docs/4.0/getting-started/introduction/)
* [FluentValidation ASP.NET Core 10.3.6](https://docs.fluentvalidation.net/en/latest/index.html)
* [Autofac 6.3.0](https://autofac.org/)

## Design Patterns
* [Repository Pattern](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design#:~:text=of%20Work%20patterns.-,The%20Repository%20pattern,from%20the%20domain%20model%20layer.) - Persistence layer
* [Model-View-Controller](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93controller)

## Limitations
* No operation service 
* Decouple Service Layer from the Web
* No Data Mapper inside repository

## Needs Improvement
* Exception Logging
* Apply CQRS
* Create a separate API layer

## Pending Issues
* DI container did not work

