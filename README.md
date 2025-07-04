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