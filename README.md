![Screenshot of the Application](צילום מסך 2024-06-15 225544.png)
Currency Trading Simulator
This application simulates real-time trades on currency pairs,
such as USD/EUR. It is built using a three-layer architecture: UILayer, BusinessLayer, and DataLayer.
Database: The application requires an SQL Server database to store the currency data. 
You can define the connection string in DataLayer\appsettings.json or use mine.

Features
Simulates changes in maximum and minimum prices for currency pairs.
Prices change randomly between 1.5 and 2.5 seconds.
Uses multithreading to handle real-time updates.
Data is stored in a SQL Server database.

Prerequisites

.NET Core SDK
SQL Server
