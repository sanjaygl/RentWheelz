-- Create a Sql schema for User Table based on the this requirements User
-- Name Type Condition
-- userName String Required, Unique
-- userEmail String Required, Unique
-- userPassword String Required, Unique
-- proofId String Required, Unique

CREATE TABLE User (
    userId INT PRIMARY KEY AUTO_INCREMENT,
    userName VARCHAR(255) NOT NULL UNIQUE,
    userEmail VARCHAR(255) NOT NULL UNIQUE,
    userPassword VARCHAR(255) NOT NULL,
    proofId VARCHAR(255) NOT NULL UNIQUE
);

-- Create a Sql schema for Car Table based on the this requirements
-- Car 
-- Name Type Condition
-- carID String Required, Unique
-- carModel String Required
-- registrationNumber String Required, Unique
-- carAvailability String Required
-- brand String Required
-- pricePerHour Number Required
-- thumbnail String Required

CREATE TABLE Car (
    carID INT PRIMARY KEY AUTO_INCREMENT,
    carModel VARCHAR(255) NOT NULL,
    registrationNumber VARCHAR(255) NOT NULL UNIQUE,
    carAvailability VARCHAR(255) NOT NULL,
    brand VARCHAR(255) NOT NULL,
    pricePerHour DECIMAL(10, 2) NOT NULL,
    thumbnail VARCHAR(255) NOT NULL
);


-- Create a Sql schema for Reservation Table based on the this requirements
-- Reservation 
-- Name Type Condition
-- bookingId String Required, Unique
-- userEmail String Required, Unique
-- carID String Required, Unique
-- reservationDate Date Required
-- pickupDate Date Required
-- returnDate Date Required
-- numOfTravellers Number Required
-- status String Required
-- car String Required
-- img String Required
-- total Number Required

CREATE TABLE Reservation (
    bookingId INT PRIMARY KEY AUTO_INCREMENT,
    userEmail VARCHAR(255) NOT NULL,
    carID INT NOT NULL,
    reservationDate DATE NOT NULL,
    pickupDate DATE NOT NULL,
    returnDate DATE NOT NULL,
    FOREIGN KEY (userEmail) REFERENCES User(userEmail),
    FOREIGN KEY (carID) REFERENCES Car(carID),
    numOfTravellers INT NOT NULL,
    status VARCHAR(255) NOT NULL,
    car VARCHAR(255) NOT NULL,
    img VARCHAR(255) NOT NULL,
    total DECIMAL(10, 2) NOT NULL
);
