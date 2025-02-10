#!/bin/bash

# Function to create a new .NET API project
create_dotnet_api_project() {
  project_name=$1
  dotnet new webapi -n "$project_name"
}

# List of project names
project_names=("ApiProject1" "ApiProject2" "ApiProject3" "ApiProject4" "ApiProject5")

# Loop through the project names and create each project
for project_name in "${project_names[@]}"; do
  create_dotnet_api_project "$project_name"
  echo "Created project: $project_name"
done

echo "All projects have been created."

# Make this script executable
chmod +x "$0"

# Run the script again (commented out)
exec "$0"
