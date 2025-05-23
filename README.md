# 🛒 mon-ecommerce

![Bannière e-commerce](https://images.unsplash.com/photo-1515168833906-d2a3b82b302b?auto=format&fit=crop&w=1200&q=80)

Ce projet est une API e-commerce développée en .NET 8 (ASP.NET Core) dans le but d'améliorer mes compétences en développement backend, conception d'API REST, et bonnes pratiques de structuration de projet.

## 🎯 Objectifs pédagogiques

- 🚀 Approfondir mes connaissances sur ASP.NET Core et Entity Framework Core
- 🧩 Mettre en place une architecture propre et évolutive
- 🛡️ Expérimenter la validation des données, la pagination, le seed de données, la documentation Swagger
- ☁️ Préparer le projet pour un futur déploiement (Cloudflare, Azure, etc.)
- 🛠️ Découvrir les bonnes pratiques pour la gestion d'un projet e-commerce (modélisation, relations, contrôleurs REST, etc.)

## ✨ Fonctionnalités principales

- 📦 Gestion des produits (CRUD)
- 👤 Gestion des utilisateurs (CRUD)
- 🧾 Gestion des commandes (CRUD)
- 🧺 Gestion des items de commande (OrderItem) pour lier produits et commandes
- ✅ Validation des données (DataAnnotations)
- 📄 Pagination sur les endpoints principaux
- 📚 Documentation interactive via Swagger
- 🌱 Seed de données automatique au démarrage

## 🛠️ Stack technique

- .NET 8 / ASP.NET Core Web API
- Entity Framework Core (InMemory pour le développement)
- Swagger (Swashbuckle)

## ▶️ Lancer le projet

1. Ouvre un terminal dans le dossier `Api`
2. Exécute :
   ```bash
   dotnet run
   ```
3. L'API sera disponible sur `https://localhost:5001` ou `http://localhost:5000`

## 🧪 Tester l'API

- Accède à Swagger UI : [https://localhost:5001/swagger](https://localhost:5001/swagger)
- Tu peux tester tous les endpoints (produits, utilisateurs, commandes, items de commande) directement depuis l'interface Swagger.

## 🙋‍♂️ Pourquoi ce projet ?

Ce projet est réalisé dans une démarche d'apprentissage personnel. Il me permet de :
- Pratiquer la modélisation de données et la gestion des relations
- Expérimenter des patterns d'API REST
- Me préparer à des projets plus complexes et à des déploiements cloud

N'hésitez pas à me faire des retours ou à proposer des améliorations !