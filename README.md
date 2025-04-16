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

# 2.0 Defect Reports
## 2.1 Creating a Video Game Without Authorisation
<table>
    <tbody>
        <tr>
            <td colspan=3><b>Unique ID:</b> 1</td>
            <td colspan=3><b>Title:</b> Create Video Game Successfully Without Authorisation</td>
        </tr>
        <tr>
            <td colspan=2><b>Date:</b> 16/04/2025</td>
            <td colspan=2><b>Tester's Name:</b> gcrumpton-spartaglobal</td>
            <td colspan=2><b>Assigned To:</b> gcrumpton-spartaglobal</td>
        </tr>
        <tr>
            <td colspan=2><b>Severity:</b> Medium</td>
            <td colspan=2><b>Priority:</b> Medium</td>
            <td colspan=2><b>Status:</b> New</td>
        </tr>
        <tr>
            <td colspan=6><b>Summary of Defect:</b> A user is able to create a new video game entry while using an invalid API key.</td>
        </tr>
        <tr>
            <td colspan=3><b>Expected Result:</b> 403 Forbidden</td>
            <td colspan=3><b>Actual Result:</b> 200 OK</td>
        </tr>
        <tr>
            <td colspan=6>
              <b>Defect Description:</b> Given a POST request is created with an invalid token or without a token altogether,
              when the request is sent to the '/api/v2/videogame' end point, then the response status code is 200 OK.
            </td>
        </tr>
        <td colspan=6><b>Further Comments:</b> The https://videogamedb.uk/ website shows a padlock next to the 'create a video game' action, thus suggesting that a valid API key is required to successfully send the request.</td>
    </tbody>
</table>
