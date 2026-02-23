# Microsoft Contact Indexing System

A command-line contact management system built in C# for the Microsoft Summer Internship 2026 application. 

This project follows OOP and SOLID principles to handle basic CRUD operations for contacts, storing all data persistently in a local JSON file. 

## Features
- Add, Edit, Delete, and View individual contacts.
- List all stored contacts.
- Search for contacts by name.
- Filter contacts by their creation date.
- Auto-generated sequential IDs and timestamped creation dates.
- Input validation for emails and phone numbers.

## Architecture
The application is separated into different layers to ensure the Single Responsibility and Dependency Inversion principles:
- **Models:** Defines the `Contact` entity.
- **Data:** Handles file I/O operations (`JsonContactStorage`).
- **Services:** Contains the core business logic and state management (`ContactManager`).
- **UI:** Isolates console interactions and input validation away from the core logic.

## How to Run

**Prerequisites:** You need the .NET 9.0 SDK (or later) installed on your machine.

1. Clone the repository.
2. Open your terminal and navigate to the project directory(.csproj).
3. Run the application using the following command:
   ```bash
   dotnet run