# Intermediate Buffer Service

## Description
A C# console service that manages an intermediate buffer with fixed slots.
Supports storing, retrieving, CSV import, logging, and state visualization.

## Features
- Fixed-size buffer
- Automatic slot selection
- Safe retrieval by ID
- CSV import with summary
- Logging & history
- Runnable console application

## TECHNOLOGY STACK
- Language: C#
- Framework: .NET Console Application
- UI: Console-based
- Persistence: In-memory

## PROJECT STRUCTURE
IntermediateBufferConsole
 Program.cs
 Models
  Workpiece.cs
  BufferSlot.cs
 Services
  IntermediateBuffer.cs
  BufferService.cs
  CsvImporter.cs

## How to Run
1. Open solution in Visual Studio
2. Place `workpieces.csv` next to executable
3. Run the application

## OR (without Visual Studio) - HOW TO RUN
1. Install the .NET SDK
2. Open a terminal in the project folder
3. Run: dotnet run

## CSV Format
Each line:
WorkpieceId,WorkpieceType

## Usage of AI
ChatGPT (free version) is used for generating boilerplate code for function which imports data from CSV file and for README document creation.