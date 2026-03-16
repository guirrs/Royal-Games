# Royal Games

A high-performance, secure backend API for managing a game database, currently under active development. This project serves as a practical implementation of modern backend architecture, featuring relational database design, secure authentication, and a scalable RESTful API.

---

# Tech Stack

### Backend
- Language/Framework: ASP.NET Core
  
- Database: SQL Server

- Architecture: RESTful API with Role-Based Access Control

### Frontend
- Framework: Next.js

### Infrastructure
- Deployment Platform: Microsoft Azure
---

# Project Roadmap

- [x] Backend API: Fully implemented CRUD for Users, Genres, Platforms, Games, and Classifications with Authorization.
  
- [ ] Frontend Integration: Developing the Next.js dashboard to interface with the REST endpoints.
        
- [ ] Cloud Deployment: Deploying the full-stack application to Microsoft Azure.
---

# API Features

The API is designed for security and scalability, providing a full CRUD suite for the following entities, all protected by Authorize policies:

- **Users**: Manage system access and profiles.

  
- **Genres**: Categorize games by genre.

  
- **Platforms**: Track game availability across hardware.

  
- **Games**:Manage core game library entities.

  
- **Classifications**: Handle parental/age rating data.
  
---

# How to Run
### Prerequisites
​- ​.NET 8.0 SDK or higher installed.

​- SQL Server instance (LocalDB or Docker container).

### ​Setup Instructions
​- Clone the repository: git clone https://github.com/guirrs/Royal-Games.git

​- Configure Database:
Update your connection string in appsettings.json to point to your local SQL Server instance.

​- Run Migrations: dotnet ef database update

​- Execute the API: cd Royal-Games
dotnet run







