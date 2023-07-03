Project name:PlanitTestJupiterAutomation
Project background: This project is done for automation some test scenarios for "https://jupiter.cloud.planittesting.com/#/" using C# Selenium and Nunit.

1.Before getting started, makesure that you have following:

-Visual Studio(or any other C# supported IDE in your Computer, I used Visual Studeo 2022)
-.NET framework installed .
- NuGet package manager installed.
2. Clone or Download the repository

3. Open the project in your C# IDE by selecting PlanitTestJupiterAutomation solution file(e.g., Visual Studio).

4.Restore NuGet packages by right-clicking on the solution in the Solution Explorer and selecting "Restore NuGet Packages".

5.Build the solution to ensure all dependencies are resolved.

Configuration
The project may requires configuration before running the tests. Open the appSettings.json file located in the project's root directory and update the following settings:

Url: The base URL of the application under test.
Browser: The browser to be used for the tests (e.g., Chrome, Firefox, etc.) Currently done for Chrome and Firefox only.

Writing Tests
The tests are written using the Specflow frature file and BDD GIVEN WHEN THEN format. Feature files are located in "Features" directory in Project file. To add a new test, create a new Feature file or add a new BDD scenario to an existing feature.


Running Tests
To run the tests, use the test explorer in IDE.

Thanks.
