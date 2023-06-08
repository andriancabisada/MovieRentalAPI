CREATE TABLE Rental (
    Id INT PRIMARY KEY IDENTITY,
    RentalDate DATETIME,
    CustomerId INT, 
    [DueDate] DATETIME NULL,
    -- Add other columns as needed
);
