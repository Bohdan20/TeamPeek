# TeamPeek: Premier League Squad Lookup

## Description
TeamPeek is a web-based POC application that allows users to search for any team from the 2024/25 English Premier League season and view detailed squad information. Users can search by team name or nickname (e.g., "The Hammers" for West Ham United) and view each player's profile picture, first name, surname, date of birth, and playing position. The project demonstrates full-stack development using React (frontend), C#/.NET (backend), integration with a 3rd-party sports API, and automated deployment via CI/CD.

## How to Run

### Prerequisites
- Node.js (v18+)
- .NET 9 SDK
- [TheSportsDB access](https://www.thesportsdb.com/api.php)

### 1. Start the Backend
```
cd TeamPeek.Server
dotnet restore
dotnet run
```

### 2. Start the Frontend
```
cd teampeek.client
npm install
npm run dev
```

## High-Level Design Document
See the [High-Level Design PDF](HighLevelDesign.pdf) for architecture diagrams and detailed design.

## Solution Overview
- **Frontend (React):** Provides a user interface for searching teams and displaying squad details. Handles user input, communicates with the backend, and renders player information in a responsive layout.
- **Backend (C#/.NET):** Exposes a REST API endpoint to receive team queries, maps nicknames to official team names, fetches squad data from a 3rd-party sports API, and returns formatted player details to the frontend.
- **3rd-Party Integration:** Uses a sports data provider (e.g., TheSportsDB) to retrieve up-to-date squad information.
- **CI/CD:** Automated build and deployment pipeline using GitHub Actions and Azure Web Apps. See `.github/workflows/release.yml` for details.

## Technical Considerations
- Nickname mapping support is limited or missing by most of free 3rd-Party APIs and thus was implemented from scratch. The nicknames dataset is limited and will require further work
- Normalizes and validates player data from the external API.
- Implements error handling for invalid teams or API issues.
- UI was implemented with a @mui/material to speed up the development.
