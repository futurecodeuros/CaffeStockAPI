# CaffeStock API

I work behind a bar, and counting stock is part of my job. I built CaffeStock to keep track of what’s on the shelf, how much is left and what it’s worth.

## Requirements

Install the .NET 10 SDK. The API uses ASP.NET Core Minimal APIs and Entity Framework Core with SQLite. The first run restores the packages automatically. There’s no separate database server to set up.

## Run locally

```sh
git clone https://github.com/futurecodeuros/CaffeStockAPI.git
cd CaffeStockAPI/CaffeStockAPI
dotnet run --launch-profile http
```

The application applies database migrations on startup and stores inventory in `CaffeStock.db`. Open [the stock list](http://localhost:5081/api/stock) to see the current inventory as JSON.

## API routes

| Resource | List or create | Read, update or delete one |
| --- | --- | --- |
| Stock entries | `GET /api/stock` · `POST /api/stock` | `GET`, `PUT`, `DELETE` at `/api/stock/{id}` |
| Article types | `GET /api/article` · `POST /api/article` | `GET`, `PUT`, `DELETE` at `/api/article/{id}` |

## Updating a stock count

Say you count eight bags of espresso beans at the end of a shift. Use the IDs from your own database when trying this request.

```http
PUT http://localhost:5081/api/stock/7
Content-Type: application/json

{
  "name": "Colombian Supremo 1kg",
  "articleId": 3,
  "price": 35.00,
  "quantity": 8
}
```

The ID in the URL picks the stock entry. Keep its current `articleId` when updating the count, or use a different one to change the type.
