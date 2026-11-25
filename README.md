# CaffeStock API

CaffeStock is a .NET 10 backend for tracking café inventory. A stock entry records a product name, its article type (for example, Coffee Beans), the unit price and the quantity on hand. The API calculates the entry’s total value as `price × quantity` whenever the entry is created or updated.

Built with ASP.NET Core Minimal APIs, Entity Framework Core and SQLite.

## Run locally

Install the .NET 10 SDK, then run:

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

## Example: update the quantity after a stock count

Suppose stock entry 7 represents bags of espresso beans. Read `GET /api/stock/7` first to get its current name, article type and unit price. If the count changes to eight bags, send the complete update below, substituting IDs and values from your own database.

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

The ID in the URL selects the stock entry. Keep its existing `articleId` to retain the type, or choose another ID from `GET /api/article` to change it. A successful update returns `204 No Content`. Read the entry again to see the new quantity and the recalculated `totalPrice` of 280.
