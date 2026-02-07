# Comics Story Builder – WinForms Comic Editor & Viewer

A Windows Forms desktop application that allows users to visually create, edit, save, export, and view multi-page comics using draggable assets, speech bubbles, and persistent database storage.

---

## Table of Contents
- About
- Getting Started
- Prerequisites
- Build and Run
- Features
- Data Persistence & SQL Design
- Comic Export & Viewer
- Project Structure
- Technologies Used
- License

---

## About

**Comics Story Builder** is a C# Windows Forms application designed to function as a lightweight comic editor and viewer.

Users can visually construct comic pages by placing character images and text bubbles onto a canvas, resize and move elements freely, 

and save each page into a structured SQLite database. Comics can later be reopened for editing, 

validated for continuity, exported as image files, and viewed using a dedicated reader interface.

The project focuses heavily on **UI interaction**, **relational database design**, and **deterministic data loading**, demonstrating how visual editors can be backed by a normalized SQL schema.

---

## Getting Started

The application is intended to be run locally using Visual Studio and does not require any external services or internet access.

---

## Prerequisites

Before running the project, ensure you have:

- Windows operating system
- Visual Studio 2022 (recommended)
- .NET Desktop Development workload
- SQLite (via System.Data.SQLite NuGet package)

---

## Build and Run

1. Clone or download the repository:

```bash
git clone https://github.com/yourusername/Comics-Story-Builder.git
```

2. Open the solution in Visual Studio:
- Go to **File → Open → Project/Solution**
- Select the `.sln` file

3. Restore NuGet packages if prompted (Visual Studio usually does this automatically).

4. Build and run the application.

---

## Features

- Visual comic editor with drag-and-drop style asset placement
- Multiple character and speech bubble assets
- Resizable and movable elements using mouse interaction
- Comic selection and editing mode
- Full comic validation before export
- Dedicated viewer form for exported comics

---

## Data Persistence & SQL Design

The application uses **SQLite** as a local relational database to persist all comic data.

### Database Structure

- **Comics**
  - Stores unique comic identifiers

- **Pages**
  - Linked to a comic
  - Stores page numbers
  - Enforces uniqueness per comic/page

- **Elements**
  - Stores all visual elements (images and text)
  - Tracks position, size, z-order, and parent-child relationships

---

## Comic Export & Viewer

Completed comics can be exported directly from the database.

### Export Process

- Pages are validated to ensure continuity (no missing pages)
- Each page is rendered off-screen using `System.Drawing.Graphics`
- Pages are exported as sequential PNG files:

```
ComicId_page_01.png
ComicId_page_02.png
...
```

### Viewer

A separate **View** form acts as a comic reader:

- Loads only pages for the selected comic
- Deterministic file loading using Comic ID + page number
- Scales pages automatically for display

This separation ensures that viewing logic is isolated from editing logic.

---

## Project Structure

- **Form1** – Main editor interface
- **View** – Comic viewer / reader
- **SQLite database** – Persistent storage (`ComicM2.db`)
- **Assets** – Character images and speech bubbles

The project follows a clear separation between:
- UI interaction
- Database logic
- Rendering/export logic

---

## Technologies Used

- **C#** (.NET, Windows Forms)
- **WinForms** for desktop UI
- **SQLite** for relational data storage
- **System.Data.SQLite** for database access
- **SQL** (schema design, joins, constraints, validation queries)

---

## License

This project is provided for educational and portfolio demonstration purposes.

It is not licensed for commercial use without explicit permission from the author.

