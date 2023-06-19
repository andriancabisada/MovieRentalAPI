CREATE TABLE Customer (
    Id INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100),
    Email VARCHAR(100), 
    [RentalId] INT NULL,
    -- Add other columns as needed
);