# TgShop 🤖🛒

<details>
<summary>🇬🇧 English version</summary>

## Overview
A simple e-commerce Telegram bot built with **C# (.NET 6)** and **Entity Framework Core**. All products are stored in local `.txt` files and delivered directly through the bot inside Telegram.

---

## 🚀 Features

- 🛒 Product catalog with categories  
- 👤 User system (Telegram user ID + balance only)  
- 💳 Purchase and order processing  
- 📦 TXT-based inventory storage (one line = one item)  
- 🔄 Automatic stock removal after purchase  
- 📩 Instant digital delivery via Telegram  
- ⚠️ Insufficient balance / out-of-stock handling  
- 🤖 Fully interactive Telegram bot interface  

---

## 🛠️ Tech Stack

- C# (.NET 6 Console Application)
- Telegram Bot API (`Telegram.Bot` v18)
- Entity Framework Core 7
- SQL Server (only user balance storage)
- Local TXT files (product storage system)

---

## 🗄️ Database Model

The database stores only user balance information:

- Telegram User ID  
- Balance  

No product or inventory data is stored in SQL Server.

---

## ⚙️ How It Works

1. User starts the bot in Telegram  
2. Browses product categories  
3. Selects a product  
4. System validates:
   - user balance (SQL Server)
   - product availability (TXT file)
5. If purchase is valid:
   - one line (item) is read from TXT file  
   - item is sent to the user  
   - balance is updated in database  
   - line is removed from file  
6. If purchase is invalid:
   - bot returns an error message  

</details>

---

<details>
<summary>🇷🇺 Русская версия</summary>

## Обзор
Простой e-commerce Telegram бот, созданный на **C# (.NET 6)** и **Entity Framework Core**. Вся продукция хранится в локальных `.txt` файлах и выдаётся через Telegram-бота.

---

## 🚀 Возможности

- 🛒 Каталог товаров с категориями  
- 👤 Пользователи (только Telegram ID + баланс)  
- 💳 Обработка покупок и заказов  
- 📦 Хранение товаров в `.txt` файлах (одна строка = один товар)  
- 🔄 Автоматическое удаление товара после покупки  
- 📩 Мгновенная цифровая выдача через Telegram  
- ⚠️ Проверка баланса и наличия товара  
- 🤖 Интерактивный Telegram интерфейс  

---

## 🛠️ Технологии

- C# (.NET 6 Console Application)
- Telegram Bot API (`Telegram.Bot` v18)
- Entity Framework Core 7
- SQL Server (только баланс пользователей)
- TXT файлы (основное хранилище товаров)

---

## 🗄️ База данных

В базе данных хранится только информация о пользователях:

- Telegram User ID  
- Баланс  

Товары и инвентарь в базе не хранятся.

---

## ⚙️ Как работает система

1. Пользователь запускает бота  
2. Выбирает категорию товаров  
3. Выбирает товар  
4. Проверка:
   - баланс пользователя (SQL Server)
   - наличие товара (TXT файл)
5. Если покупка успешна:
   - товар считывается из файла  
   - отправляется пользователю  
   - баланс списывается  
   - строка удаляется  
6. Если покупка невозможна:
   - выводится сообщение об ошибке  

</details>