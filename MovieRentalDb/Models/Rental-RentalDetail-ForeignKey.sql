ALTER TABLE RentalDetail
ADD CONSTRAINT FK_RentalDetail_RentalId FOREIGN KEY (RentalId) REFERENCES Rental(Id);
