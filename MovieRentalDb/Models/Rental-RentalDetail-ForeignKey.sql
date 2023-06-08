ALTER TABLE RentalDetails
ADD CONSTRAINT FK_RentalDetails_RentalId FOREIGN KEY (RentalId) REFERENCES Rental(Id);
