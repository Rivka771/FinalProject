CREATE TABLE Volunteers (
  VolunteerID INT PRIMARY KEY,
  Name VARCHAR(100),
  Phone VARCHAR(15)
);

CREATE TABLE Services (
  ServiceID INT PRIMARY KEY,
  ServiceName VARCHAR(100)
);

CREATE TABLE VolunteerServices (
  VolunteerServiceID INT PRIMARY KEY,
  VolunteerID INT,
  ServiceID INT,
  MonthlyHours INT,
   FOREIGN KEY (VolunteerID) REFERENCES Volunteers(VolunteerID),
  FOREIGN KEY (ServiceID) REFERENCES Services(ServiceID)
  );
  CREATE TABLE HelpSeekers (
  SeekerID INT PRIMARY KEY,
  Name VARCHAR(100),
  Phone VARCHAR(15),
  Address VARCHAR(255)
);

CREATE TABLE Requests (
  RequestID INT PRIMARY KEY,
  SeekerID INT,
  RequestContent TEXT,
  Status VARCHAR(20),
  Date DATE,
  ServiceID INT,
  Hours INT,
  FOREIGN KEY (SeekerID) REFERENCES HelpSeekers(SeekerID),
  FOREIGN KEY (ServiceID) REFERENCES Services(ServiceID)
);

CREATE TABLE AssignedRequests (
  AssignmentID INT PRIMARY KEY,
  RequestID INT,
  VolunteerID INT,
  FOREIGN KEY (RequestID) REFERENCES Requests(RequestID),
  FOREIGN KEY (VolunteerID) REFERENCES Volunteers(VolunteerID)
);
INSERT INTO Volunteers VALUES 
(1, 'Avi Cohen', '0558769098'),
(2, 'Shlomo Levi', '0543546678');

INSERT INTO Services VALUES 
(1, 'Panzer on wheels'),
(2, 'No fuel');

INSERT INTO VolunteerServices VALUES 
(1, 1, 1, 10),
(2, 2, 2, 5);

INSERT INTO HelpSeekers VALUES 
(1, 'Chaim Ben Chamu', '0567667898', 'Jerusalem'),
(2, 'Shimon Yakovzon', '0556787767', 'TelAviv');

INSERT INTO Requests VALUES 
(1, 1, 'Panzer on wheels', 'pending', '2025-05-01', 1, 3),
(2, 2, 'No fuel', 'approved', '2025-05-02', 2, 2);

INSERT INTO AssignedRequests VALUES 
(1, 2, 1);