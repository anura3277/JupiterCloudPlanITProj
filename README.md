# Project name: Planit Test Jupiter Automation
Project background: This project is done for automation some test scenarios for "https://jupiter.cloud.planittesting.com/#/" using C# Selenium and Nunit.

## Dependencies

1.Before getting started, makesure that you have following:

-Visual Studio(or any other C# supported IDE in your Computer, I used Visual Studeo 2022)
-.NET framework installed .
- NuGet package manager installed.
- SpecFlow.Allure package installed to PlanitTestJupiterAutomation.Driver project
- Install Allure report generation tool to the computer

2. Clone or Download the repository

3. Open the project in your C# IDE by selecting PlanitTestJupiterAutomation solution file(e.g., Visual Studio).

4.Restore NuGet packages by right-clicking on the solution in the Solution Explorer and selecting "Restore NuGet Packages".

5.Build the solution to ensure all dependencies are resolved.

## Configuration
The project may requires configuration before running the tests. Open the appSettings.json file located in the project's root directory and update the following settings:

Url: The base URL of the application under test.
Browser: The browser to be used for the tests (e.g., Chrome, Firefox, etc.) Currently done for Chrome and Firefox only.

## Writing Tests
The tests are written using the Specflow frature file and BDD GIVEN WHEN THEN format. Feature files are located in "Features" directory in Project file. To add a new test, create a new Feature file or add a new BDD scenario to an existing feature.


## Running Tests

To run the tests, use the test explorer in IDE.

## Test Report 

Allure is used to generate test reports.

1.To generate reports open commandline from following folder "Project location\bin\Debug\net6.0\allure-results"
2.then run the command <allure serve allure-results>. To get the reports, you must have installed Allure in to your computer.

