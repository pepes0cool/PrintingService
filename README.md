# Smart Printing Service for Students at HCMUT
Welcome to the Smart Printing Service project! This platform is designed to simplify and enhance the printing experience for students at Ho Chi Minh City University of Technology (HCMUT). 

# Technologies Used
This project utilizes the following technologies:

- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap 5.3.3
- **Backend**: .NET Core MVC
- **Database**: MS SQL Server
Setup and Installation
Follow these steps to set up the project locally:

## Clone the repository:
git clone https://github.com/phucmap10/PrintingService.git
cd PrintingService
Configure the connection string:

Open the appsettings.json file in the project directory.
Update the connection string to match your MS SQL Server configuration.
Then add migration, update database following this command in package manager console:(Visual Studio)  
add-migration <your Migration name>  
update-database  
Then you are all set !  
Run the application:

Open the solution file in Visual Studio.
Build the project to restore dependencies.
Start the application by running it locally.  
You can create new account in the application, any mail will be 'Student' role, If the mail is 'SPSO@hcmut.edu.vn', the user will be assign to SPSO role.
