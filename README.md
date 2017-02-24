# Hair Salon

#### _A website for viewing a salon's list of stylists and clients_

#### By _**Nicole Sanders**_

## Description
This web application allows the user to enter in new stylists that work at the salon and clients that work with the stylists. The user will be able to update a client's name and delete clients when they stop frequenting the salon.


## Setup/Installation Requirements

* Requires DNU, DNX, Microsoft SQL Server, and Mono
* Clone to local machine
* Run SQL in Window's Power Shell by typing in the command: sqlcmd -S "(localdb)\mssqllocaldb"
* To create the database type the following command into Windows Power Shell
CREATE DATABASE hair_salon
* To enter into the database enter the command: USE hair_salon; GO
* To create the client table type the following command into Windows Power Shell:
CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255), hair_style VARCHAR(255), stylist_id INT);
GO;
* To create the stylist table type the following command into Windows Power Shell:
CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255), experience INT);
GO;
* In Microsoft SQL Server Manager, back up the database and restore a hair_salon_test database.
* Use command "dnu restore" in command prompt/shell
* Use command "dnx kestrel" to start server
* Navigate to http://localhost:5004 in web browser of choice

## Specifications

**The user inputs a stylist's name and the number of years of experience they have and a page is displayed that tells the user the input was successful**
* Example Input: "Betty White", "2"
* Example Output: Success

**The user can see a list of all of the stylists**
* Example Input: Click on stylist link
* Example Output: List of stylists

**The user inputs a client's name, their usual hair style, and the stylist they use. A page is displayed that tells the user the input was successful**
* Example Input: "Tom Cruise", "Buzz Cut", "1"
* Example Output: Success

**The user can see a list of all of the clients**
* Example Input: Click on clients link
* Example Output: List of clients

**The user can see a list of clients for a specific stylist**

**The user can delete a client**

**The user can edit a client's name**

**Icebox features**
* Edit the stylist name and years of experience
* Delete a stylist if they get a different job
* Search stylist by years of experience
* Sort stylist by most popular
* Sort clients by preferred hair cut

## Support and contact details

Please contact Nicole Sanders at nsanders9022@gmail.com with any questions, concerns, or suggestions.

## Known Bugs

_None. If you find any bugs please let us know._

## Technologies Used

This web application uses:
* Nancy
* Mono
* C#
* Razor
* SQL

### License

*This project is licensed under the MIT license.*

Copyright (c) 2017 **_Nicole Sanders_**
