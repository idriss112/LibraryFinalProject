# 📚 Système de Gestion de Bibliothèque — Application WinForms (.NET 8)

Une application Windows Forms moderne permettant la gestion complète d’une bibliothèque, développée avec **.NET 8**, **Entity Framework Core (Code‑First)** et une **architecture 4‑tiers professionnelle**.

[![.NET](https://img.shields.io/badge/.NET-8.0-purple)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12-blue)](https://learn.microsoft.com/dotnet/csharp/)
[![WinForms](https://img.shields.io/badge/Windows%20Forms-Modern%20UI-green)]()
[![EF Core](https://img.shields.io/badge/Entity%20Framework%20Core-Code--First-orange)]()
[![License](https://img.shields.io/badge/Licence-MIT-green)](LICENSE)

---

## 📋 Table des Matières
- [Aperçu](#aperçu)
- [Fonctionnalités](#fonctionnalités)
- [Stack Technique](#stack-technique)
- [Architecture](#architecture)
- [Démarrage](#démarrage)
- [Modèle de Données](#modèle-de-données)
- [Pénalités & Règles Métier](#pénalités--règles-métier)
- [Améliorations Futures](#améliorations-futures)
- [Contribution](#contribution)
- [Licence](#licence)

---

## 🎯 Aperçu

Cette application de gestion de bibliothèque permet d’administrer facilement les livres, auteurs et emprunts dans une interface **modernisée style Windows 2026**.  
Le projet utilise **Entity Framework Core** avec une approche **Code‑First**, ainsi qu’une **architecture 4‑tiers propre et maintenable**.

### 🎛️ Fonctionnalités Clés
- Gestion complète des **livres** (CRUD)
- Gestion des **auteurs** (CRUD)
- Gestion des **emprunts** + calcul automatique des pénalités
- Architecture **4‑tiers** : UI → BLL → DAL → Models
- Base de données SQL Server générée via **migrations EF Core**
- Interface moderne, responsive et cohérente

---

## ✨ Fonctionnalités

### 📚 Gestion des Livres
- Ajouter, modifier, supprimer un livre  
- Associer un ou plusieurs auteurs  
- Filtrer par titre, auteur ou disponibilité  
- Marquage automatique si un livre est emprunté  

### ✍️ Gestion des Auteurs
- Gérer les auteurs  
- Relation plusieurs‑à‑plusieurs (livres ↔ auteurs)  

### 📄 Gestion des Emprunts
- Enregistrer un emprunt  
- Enregistrer un retour  
- Calcul automatique des pénalités (1$/jour de retard par défaut)  
- Vérification automatique de disponibilité  

### 🔐 Authentification
- Login administrateur simple  
- Blocage de l’accès sans connexion  

### 🖥️ Interface Moderne
- Style Windows 2026 (couleurs, coins arrondis, hover effects)  
- DataGridView modernisé  
- Menu latéral propre et ergonomique  

---

## 🛠️ Stack Technique

### Backend
- **C# 12**
- **.NET 8**
- **Entity Framework Core 8**
- **SQL Server LocalDB**

### Frontend (UI)
- **Windows Forms (.NET 8)**
- Contrôles personnalisés (coins arrondis, styles modernes)
- DataGridView stylisée

### Architecture
- **4‑Tiers** :
  - `Library.Models` → entités
  - `Library.DAL` → EF Core, DbContext, Repositories
  - `Library.BLL` → logique métier
  - `Library.UI` → interface utilisateur WinForms

---

## 🏗️ Architecture

```
LibrarySolution/
├── Library.Models/       # Entités : Book, Author, Borrowing, AuthorBook
│
├── Library.DAL/          # Accès aux données
│   ├── LibraryContext.cs
│   ├── Repositories/
│   └── Migrations/
│
├── Library.BLL/          # Logique métier
│   ├── BookManager.cs
│   ├── AuthorManager.cs
│   └── BorrowingManager.cs
│
└── Library.UI/           # Interface Windows Forms
    ├── LoginForm.cs
    ├── MainForm.cs
    ├── BooksForm.cs
    ├── AuthorsForm.cs
    └── BorrowingsForm.cs
```

---

## 🚀 Démarrage

### 1️⃣ Cloner le dépôt
```bash
git clone https://github.com/votre-utilisateur/library-management.git
cd library-management
```

### 2️⃣ Restaurer les packages
```bash
dotnet restore
```

### 3️⃣ Appliquer les migrations EF Core
```bash
Add-Migration InitialCreate
Update-Database
```

### 4️⃣ Lancer l’application
Dans Visual Studio → exécuter **Library.UI**.

---

## 🗄️ Modèle de Données

### 📘 Book
- Id  
- Title  
- PublicationYear  
- ISBN  
- IsAvailable  

### ✍️ Author
- Id  
- FirstName  
- LastName  
- Nationality  

### 📄 Borrowing
- BorrowerName  
- BorrowDate  
- ReturnDueDate  
- ReturnActualDate  
- Penalty  

### 🔗 AuthorBook
Relation plusieurs‑à‑plusieurs.

---

## ⚖️ Pénalités & Règles Métier
- Un livre ne peut être emprunté que s’il est disponible  
- Retour obligatoire après la date d’emprunt  
- Pénalité = jours de retard × 1$  
- Un livre redevient disponible uniquement après enregistrement du retour  

---

## 🧪 Améliorations Futures
- Ajout d’un tableau de bord statistique  
- Export PDF/Excel  
- Recherche avancée  
- API REST optionnelle  
- Système d’utilisateurs complet  

---

## 🤝 Contribution

Les contributions sont les bienvenues !

1. Forker le dépôt  
2. Créer une branche :  
```bash
git checkout -b feature/NouvelleFonctionnalite
```
3. Commiter vos modifications  
4. Ouvrir une Pull Request  

---

## 📝 Licence
Projet sous licence MIT — voir le fichier **LICENSE**.

---

## 👤 Auteur
**Driss Laaziri**  
GitHub : https://github.com/idriss112  
Email : idrisslaaziri@gmail.com  

---

Construit avec ❤️ en utilisant **WinForms & Entity Framework Core**.
