CREATE DATABASE MedicalManagementDB;
USE MedicalManagementDB;



-- Create the Users table
CREATE TABLE Users (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    PhoneNumber NVARCHAR(20),
    CONSTRAINT UC_Username UNIQUE (Username),
    CONSTRAINT UC_Email UNIQUE (Email)
);

-- Create the MedicalCards table
CREATE TABLE MedicalCards (
    Id INT PRIMARY KEY IDENTITY,
    PatientId UNIQUEIDENTIFIER NOT NULL,
    State NVARCHAR(100),
    CONSTRAINT FK_MedicalCard_Patient FOREIGN KEY (PatientId) REFERENCES Users (Id)
);

-- Create the Doctors table
CREATE TABLE Doctors (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    UserId UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT FK_Doctor_User FOREIGN KEY (UserId) REFERENCES Users (Id),
    CONSTRAINT UC_Doctor UNIQUE (UserId)
);

-- Create the Patients table
CREATE TABLE Patients (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    UserId UNIQUEIDENTIFIER NOT NULL,
    MedicalCardId INT NOT NULL,
    CONSTRAINT FK_Patient_User FOREIGN KEY (UserId) REFERENCES Users (Id),
    CONSTRAINT UC_Patient UNIQUE (UserId),
    CONSTRAINT FK_Patient_MedicalCard FOREIGN KEY (MedicalCardId) REFERENCES MedicalCards (Id)
);

-- Create the Appointments table
CREATE TABLE Appointments (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    PatientId UNIQUEIDENTIFIER NOT NULL,
    DoctorId UNIQUEIDENTIFIER NOT NULL,
    DateTime DATETIME NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    CONSTRAINT FK_Appointment_Patient FOREIGN KEY (PatientId) REFERENCES Patients (Id),
    CONSTRAINT FK_Appointment_Doctor FOREIGN KEY (DoctorId) REFERENCES Doctors (Id),
	CONSTRAINT CHK_DateTime CHECK (Datetime > GETDATE())
);

