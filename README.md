# RentWheelz API Documentation

## Overview
RentWheelz is a car rental service that allows users to register, log in, reserve cars, view their bookings, and cancel reservations. This README provides the necessary information to get started with the RentWheelz API, including setup instructions and example request bodies for various operations.

## Prerequisites
.NET SDK
Entity Framework Core
Setup Instructions
1. Setting Up the Database
Entity Framework (EF) Core commands are used to manage the database schema. Below are the commands to create and update the database.

## Add Initial Migration
This command creates a new migration script to set up the initial database schema based on the current model.

### dotnet ef migrations add InitialCreate --project src/RentWheelz.Database/RentWheelz.Database.csproj --startup-project src/RentWheelz.API/RentWheelz.API.csproj

## Explanation:

dotnet ef migrations add InitialCreate: Adds a new migration named InitialCreate.
--project src/RentWheelz.Database/RentWheelz.Database.csproj: Specifies the project that contains the Entity Framework Core context.
--startup-project src/RentWheelz.API/RentWheelz.API.csproj: Specifies the startup project that the tools should use for the database connection and migrations.

## Update the Database
This command applies any pending migrations to the database, creating or updating the database schema as necessary.

### dotnet ef database update --project src/RentWheelz.Database/RentWheelz.Database.csproj --startup-project src/RentWheelz.API/RentWheelz.API.csproj

## Explanation:

dotnet ef database update: Applies all pending migrations to the database.
--project src/RentWheelz.Database/RentWheelz.Database.csproj: Specifies the project that contains the Entity Framework Core context.
--startup-project src/RentWheelz.API/RentWheelz.API.csproj: Specifies the startup project for the database connection.


## API Endpoints

# Register
Registers a new user.

Endpoint: /register
Method: POST
Request Body: 

  "userName": "krishna",
  "userEmail": "krishna@abc.com",
  "userPassword": "krishna@123",
  "proofId": "U101"
}

# Login
Logs in an existing user.

Endpoint: /login
Method: POST
Request Body:
{
  "userEmail": "krishna@abc.com",
  "userPassword": "krishna@123"
}

# Reserve
Reserves a car for a specified period.

Endpoint: /reserve
Method: POST
Request Body:
{
  "pickupDate": "2023-11-30",
  "returnDate": "2023-12-01",
  "numOfTravelers": 4,
  "carId": "C102"
}

# My Booking
Retrieves all bookings for a user.

Endpoint: /my-booking
Method: POST
Request Body:
{
  "userEmail": "krishna@abc.com"
}

# Cancel
Cancels a booking.

Endpoint: /cancel
Method: POST
Request Body:
{
  "bookingId": "B202405171227493023"
}

# Conclusion
This README provides an overview of how to set up and interact with the RentWheelz API. 
Use the provided EF Core commands to manage the database and refer to the example request bodies for the API endpoints to perform various operations. 
For further information or troubleshooting, 
please refer to the official Entity Framework Core documentation or the .NET SDK documentation.

