# Racing Calendar System

This repository contains the source code for the Racing Calendar System, a project developed as part of the ZTM Academy C#/.NET Bootcamp. The primary focus of this project is to explore and review generic collection types in C#, choosing the most appropriate collection for various application needs related to managing racing events and participants.

## Project Overview

The Racing Calendar System is designed to handle the complexities of race management including registering drivers to races, managing full race rosters, and maintaining a waiting list for drivers once race limits are reached. This project showcases the practical use of generic collections like `List<T>` and `Queue<T>` to solve real-world problems efficiently.

## Features

- **Race Management**: Allows creation of races with specific details such as date and track.
- **Driver Management**: Supports adding drivers to races with a cap of 5 drivers per race, utilizing waiting lists for additional drivers.
- **Dynamic Driver Handling**: Facilitates automatic promotion of drivers from the waiting list when space becomes available, and handles removal of drivers from races.
- **Console-Based Interface**: Displays detailed information about races and driver rosters directly in the console, demonstrating dynamic data handling.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your system to run the application.

### Running the Application

1. Clone the repository:
   ```bash
   git clone https://github.com/<your-username>/RaceCalendar.git

2. Navigate to the project directory:
   ```bash
   cd RaceCalendar

3. Build the project:
   ```bash
   dotnet build
   
4. Run the application:
   ```bash
   dotnet run

## Educational Purpose

This project serves as an educational tool to demonstrate the effective use of various generic collections in C#, emphasizing the decision-making process in selecting the right collection type for specific scenarios within software development.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
