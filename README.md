# 🍔 Good Hamburger API

API REST desenvolvida em ASP.NET Core (.NET 8) utilizando Clean Architecture, SOLID e DDD (nível simples).

---

## 🚀 Como rodar o projeto

### Pré-requisitos

* .NET 8 SDK instalado
* VS Code (recomendado)

### Rodando a aplicação

```bash
dotnet clean
dotnet build
dotnet run --project GoodHamburger.API
```

Acesse o Swagger:

```
http://localhost:xxxx/swagger
```

---

## 📦 Estrutura

/src

* Domain → regras de negócio
* Application → casos de uso
* Infrastructure → banco e repositórios
* API → controllers

---

## 🧠 Regras de negócio

* Pedido deve conter 1 sanduíche
* Pode conter 1 batata e 1 refrigerante
* Não permite itens duplicados

### Descontos:

* Combo completo → 20%
* Sanduíche + refrigerante → 15%
* Sanduíche + batata → 10%

---

## 🔧 Tecnologias

* ASP.NET Core
* Entity Framework (InMemory)
* Swagger
* Clean Architecture
* DDD

---

## 📌 Endpoints

* POST /orders
* GET /orders
* GET /orders/{id}
* PUT /orders/{id}
* DELETE /orders/{id}
* GET /menu

---

## 💡 Decisões técnicas

* Lógica de desconto no Domain (DDD)
* Repository Pattern
* Service layer para orquestração
* Controllers sem regra de negócio

---

## 🧪 Testes

(Recomendar adicionar xUnit futuramente)
