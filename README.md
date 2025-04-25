# Video Game Database Test
This repo contains a RestSharp API test framework project.

# 1.0 Project Setup
## 1.1 Set Up the IDE
1. Install Visual Studio 2022 or later.
2. Install the .NET 8 SDK.
3. Clone the project repository from GitHub.
4. Open the project in Visual Studio.
5. Install the Reqnroll plugin for Visual Studio. This also may require you to restart Visual Studio.
6. Ensure that the following Nuget packages are installed:
	- RestSharp
	- Newtonsoft.Json.Schema
	- NUnit
	- NUnit3TestAdapter
	- NUnit.Analyzers
	- Microsoft.NET.Test.Sdk
	- Reqnroll.NUnit
	- Reqnroll.SpecFlowCompatibility

# 2.0 Important Notes
## 2.1 API Design
The system under test, 'Video Game DB 2022 API' has some oddities when it comes to API design. 
For example, when requesting an API key you must enter a username and password of "admin",
or the request fails with a 403 Forbidden error. This allowed me to easily automatically
generate a valid API key for use in the tests each time the test suite is run. However, 
most APIs in practice would allow you to create a unique token given a specific username and 
password.

