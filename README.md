# Phantom Pulse

This is a sample application of how to use and retrive secrets, keys and certificates in Azure Key Vault.

## Creation of app

Create a new .NET console application

```bash
dotnet new console -n PhantomPulse
cd PhantomPulse
```

Add Azure SDK Packages

```bash
dotnet add package Azure.Identity
dotnet add package Azure.Security.KeyVault.Secrets
```

Add code found in `Program.cs`

## App Registration

If you plan to use this application in an Azure Resource, you can simply assign a Managed Identity to that resource that will run this code and assign that managed identity the appropriate permissions in Azure Key Vault. Be sure to select Manage Identity when prompted by this application. If you are not running this application in Azure, or you are not using Managed Identity, you can create a service principal to use for authentication to Key Vault by creating an Azure AD Application. Azure Key Vault authentication is done through Azure AD. Here are the steps to create your Azure AD Application registration and service principal

1. Log into the Azure Portal
    
    * Visit the Azure Portal at https://portal.azure.com and sign in with your Azure Account.

1. Go to Azure Active Directory

    * In the left-hand menu, select "Azure Active Directory".

1. Register a new application

    * In the Azure Active Directory pane, select "App Registrations" and then "New Registration".
    * Provide a meaningful name for the application, select the appropriate account type, and leave the "Redirect URI" blank, then click "Register".
    * After the app is registered, you'll be taken to the app's "Overview" page. The "Application (client) ID" displayed here is your client ID.

1. Create a new client secret

    * In the left-hand menu of the app's pane, select "Certificates & secrets". Then click "New client secret". Provide a description, select the expiration time, and click "Add".
    * After the secret is created, its value will be displayed. This value is your client secret. Copy and store it securely. You won't be able to retrieve the secret value later.

Now when prompted by this application for the client id and client secret you can use the information you've just generated to authenticate to Azure Key Vault. Please note that where possible, Managed Identities are the recommended approach.

## Run the App

from the `/PhantomPulse` directory, run `dotnet run`. Follow the prompts in the console window.

