# Esame – Progetti di Sviluppo Full-Stack (PostgreSQL · C# API · Angular)

Questo documento descrive i tre progetti d’esame con i relativi requisiti di base e i task aggiuntivi.
---

# 🧾 **Prova 1 – To-Do List**

### **Database (PostgreSQL)**
Crea la tabella:
```sql
CREATE TABLE todo (
  id SERIAL PRIMARY KEY,
  title VARCHAR(255) NOT NULL,
  completed BOOLEAN DEFAULT FALSE,
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
```
API (C#)

Implementa un’API con i seguenti endpoint:

GET /todos – restituisce tutti i todo

POST /todos – aggiunge un nuovo todo

DELETE /todos/{id} – elimina un todo per ID

Frontend (Angular)
Componente per visualizzare la lista dei todo

Form per aggiungere un nuovo todo

Servizio che comunica con l’API per le operazioni CRUD

## **Task aggiuntivo 1**
Aggiungi tabella category (id, name)

Crea relazione uno-a-molti tra category e todo

Popola la tabella category con alcune categorie predefinite

##  **Task aggiuntivo 2**
Nel frontend aggiungi un filtro a tendina per categoria

Mostra solo i todo della categoria selezionata

📇 Prova 2 – Gestione Contatti
Database (PostgreSQL)
Crea la tabella:

```sql
CREATE TABLE contact (
  id SERIAL PRIMARY KEY,
  first_name VARCHAR(100),
  last_name VARCHAR(100),
  email VARCHAR(255),
  phone VARCHAR(50)
);
```
API (C#)
Endpoint richiesti:

GET /contacts – elenco contatti

POST /contacts – aggiunta nuovo contatto

DELETE /contacts/{id} – elimina un contatto per ID

Frontend (Angular)
Interfaccia per visualizzare la lista dei contatti

Form per aggiungere nuovi contatti

Servizio Angular per comunicare con le API

Task extra 1
Crea tabella group (id, name)

Crea relazione molti-a-molti tra contact e group tramite una tabella ponte (contact_group)

Task extra 2
Aggiungi nel frontend un filtro a tendina per gruppo

Mostra solo i contatti appartenenti al gruppo selezionato

✍️ Prova 3 – Mini-Blog
Database (PostgreSQL)
Crea la tabella:

```sql
CREATE TABLE post (
  id SERIAL PRIMARY KEY,
  title VARCHAR(255) NOT NULL,
  body TEXT,
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
```
API (C#)
Endpoint richiesti:

GET /posts – elenco dei post

POST /posts – aggiungi un nuovo post

DELETE /posts/{id} – elimina un post per ID

Frontend (Angular)
Componente per visualizzare la lista dei post

Form per creare un nuovo post

Servizio Angular per le chiamate API

Task extra 1
Aggiungi tabella comment (id, post_id FK, author, content, created_at)

Crea relazione molti-a-uno (un post → più commenti)

Inserisci alcuni commenti di esempio

Task extra 2
Nel frontend, mostra sotto ogni post la lista dei commenti

Aggiungi un piccolo form per inserire un nuovo commento (POST /comments)

✅ Note generali
Ogni progetto deve includere:

Script SQL per la creazione del database

Backend in C# (ASP.NET Core)

Frontend in Angular

I task aggiuntivi sono facoltativi ma consigliati per approfondire le relazioni tra entità e la gestione dei filtri nel frontend.