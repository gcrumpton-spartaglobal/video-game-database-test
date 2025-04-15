# Video Game Database Test
This repo contains a RestSharp API test framework project.

# 1.0 Project Setup
## 1.1 Set Up JSON config file
Create a JSON file called 'appsettings.json' inside the folder 'Resources/Config'. This file needs to have the following structure:
```json
{
  "UserInfo": {
    "username": "<your_username>",
    "password": "<your_password>",
    "token": "<your_token>"
  }
}
```
Copy and paste your username, password, and token obtained when obtaining the API key into this JSON file.

## 1.2 Set Up GitHub Secrets
Create a GitHub repository secret, called 'APP_SETTINGS' and copy and paste the completed 'appsettings.json' config file from the previous step into the 'Secret *' field.
