# Deployment

This section provides instructions for deploying the WordPress Learning Automation Toolkit to different environments, such as local, staging, and production.

## Local Deployment

To deploy the application locally, follow these steps:

1. Clone the repository:

   ```sh
   git clone https://github.com/DevOpsVisions/wordpress-automation-toolkit.git
   cd wordpress-automation-toolkit
   ```

2. Restore the .NET Core dependencies:

   ```sh
   dotnet restore
   ```

3. Build the project:

   ```sh
   dotnet build
   ```

4. Run the application:

   ```sh
   dotnet run
   ```

## Staging Deployment

To deploy the application to a staging environment, follow these steps:

1. Set up a staging server with the necessary prerequisites, such as .NET Core SDK and Google Chrome browser.

2. Clone the repository to the staging server:

   ```sh
   git clone https://github.com/DevOpsVisions/wordpress-automation-toolkit.git
   cd wordpress-automation-toolkit
   ```

3. Restore the .NET Core dependencies:

   ```sh
   dotnet restore
   ```

4. Build the project:

   ```sh
   dotnet build
   ```

5. Run the application:

   ```sh
   dotnet run
   ```

## Production Deployment

To deploy the application to a production environment, follow these steps:

1. Set up a production server with the necessary prerequisites, such as .NET Core SDK and Google Chrome browser.

2. Clone the repository to the production server:

   ```sh
   git clone https://github.com/DevOpsVisions/wordpress-automation-toolkit.git
   cd wordpress-automation-toolkit
   ```

3. Restore the .NET Core dependencies:

   ```sh
   dotnet restore
   ```

4. Build the project:

   ```sh
   dotnet build
   ```

5. Run the application:

   ```sh
   dotnet run
   ```

## GitHub Pages Deployment

To deploy the documentation to GitHub Pages, follow these steps:

1. Ensure that the `docfx.json` file is properly configured for generating the documentation.

2. Generate the documentation using DocFX:

   ```sh
   docfx
   ```

3. Commit the generated documentation to the `gh-pages` branch:

   ```sh
   git checkout gh-pages
   cp -r _site/* .
   git add .
   git commit -m "Update documentation"
   git push origin gh-pages
   ```

4. Access the documentation on GitHub Pages using the provided URL.
