# Band Tracker

#### Allows a user to keep track of the several of their favorite bands and concert venues, July 22, 2016

#### By Callan McNulty

## Description

This web app will access a database of bands and venues. The user can add bands and venues to and retrieve them from the database and view, edit and delete the information of any band or venue. Performances can also be added to the database and viewed in by band or by venue.

## Setup/Installation Requirements

* Clone repository from GitHub
* To import the database:
  * Open SSMS
  * Select File>Open>File and select band_tracker.sql in the cloned directory
  * Add the following lines to the top of the script
    * CREATE DATABASE band_tracker
    * GO
  * Click Save then Execute
* To start the server:
  * Open terminal and navigate to cloned directory
  * Enter the command: dnu restore
  * Enter the command: dnx kestrel
* To start the client:
  * Open a web browser and navigate to http://localhost:5004/
* To run the back end tests (optional):
  * Follow the above instructions for importing the database using the file band_tracker_test.sql and the database name band_tracker_test.
  * Enter the command dnx test in the terminal

## Support and contact details

I can be contacted for support at jabberwocky222@gmail.com

## Technologies Used

* C#
* Nancy Framework w/ Razor view engine
* HTML

Copyright (c) 2016 Callan McNulty
