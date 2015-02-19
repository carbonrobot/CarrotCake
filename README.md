# CarrotCake
Experiments with repository and service patterns in C#

There are 3 different ORM implementations in this project. Native SQL, Dapper, and Entity Framework. 
They can swapped out by uncommenting the appropriate line in `Web/CarrotCake.Web.Api/App_Start/UnityConfig`.

The solution is set up in the following way:

````
src/
  data/
    CarrotCake.Data
      - Contains the shared interfaces for data access. 
      - Dependencies: [CarrotCake.Domain]
      
    CarrotCake.Data.Dapper
      - Contains the Dapper concrete repository implementation
      - Dependencies: [CarrotCake.Domain, CarrotCake.Data]
      
    CarrotCake.Data.Ef
      - Contains the EF concrete repository implementation
      - Dependencies: [CarrotCake.Domain, CarrotCake.Data]
      
    CarrotCake.Data.Sql
      - Contains the Native SQL concrete repository implementation
      - Dependencies: [CarrotCake.Domain, CarrotCake.Data]
      
  domain/
    CarrotCake.Domain
      -Contains all domain models/business objects
      - Dependencies: None
      
    CarrotCake.Services
      - Contains the core business logic, provides a single interface for all business operations
      - Dependencies: [CarrotCake.Domain, CarrotCake.Data]
    
  web/
    CarrotCake.Web.Api
      - Contains a REST Api for exposing data to the wide world
      - Dependencies: [All]
