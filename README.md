# Helmes Assignment 
# How to run this project
1. Restore the nuget packages
	- Select the Tools > NuGet Package Manager > Package Manager Settings menu command.
	- Set both options under Package Restore.
	- Select OK.
	
2. Create and seed the database
	- Open the Package Manager console and run `Update-Database`

This project does the following:
Tasks:
1. Correct all of the deficiencies in index.html
2. "Sectors" selectbox:
2.1. Add all the entries from the "Sectors" selectbox to database
2.2. Compose the "Sectors" selectbox using data from database
3. Perform the following activities after the "Save" button has been pressed:
3.1. Validate all input data (all fields are mandatory)
3.2. Store all input data to database (Name, Sectors, Agree to terms)
3.3. Refill the form using stored data
3.4. Allow the user to edit his/her own data during the session

Live demo: https://helmesassignment-rod.azurewebsites.net/ 

