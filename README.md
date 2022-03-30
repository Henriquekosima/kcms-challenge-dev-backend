# kcms-challenge-dev-backend

C# API using Atlas MongoDB!

# How to Use

Clone the repository and run it locally in your machine, the database credentials are stored in the appsettings.
You can test it with the swagger with the following url: https://localhost:5001/swagger/index.html or you can test it with Postman or similar Apps, sending requests to the following ULR: https://localhost:5001/{EndPoints}.


# EndPoints

<!-- TABLE_GENERATE_START -->

| Action  | EndPoints | Method |
| ------------- | ------------- | ------------- |
| Create Category  | /Category  | POST  |
| List Category  | /Category/{CategoryID}  | GET  |
| Delete Category  | /Category/{CategoryID}  | DELETE  |
| Update Category  | /Category/{CategoryID}  | PUT  |
| Create a Product in one Category  | /Product  | POST  |
| List Products from Category  | /Product/ListProductsByCategory/{CategoryID}  | GET  |
| List Product  | /Product/{ProductID}  | GET  |
| Delete Product  | /Product/{ProductID}  | DELETE  |
| Update Category from Product  | /Product/{ProductID}  | PUT  |

<!-- TABLE_GENERATE_END -->

# Requests

Category - Create
```
{
  "name": "string"
}
```

Category - Update
```
{
  "name": "string"
}
```

Product - Create
```
{
  "description": "string",
  "categoryID": "string"
}
```
Product - Update
```
{
  "name": "string"
}
```


