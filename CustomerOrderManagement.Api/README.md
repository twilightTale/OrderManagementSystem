# Order Management Api
* Api 1: Insert customer order details to the ‘Order’ table
    * Sample Input
### /api/Order/Submit
```json
{
  "ProductId": 4,
  "CustomerId": 5,
  "OrderDate": "2020-11-21T23:56:38Z",
  "ShippedDate": null,
  "Quantity": 11,
  "PricePaid": 8.43
}
```


* Api 2: Get all the pending orders which are not yet shipped to the customers.
### /api/order/pending

* Api 3: Get the list of products with AverageCustomerRating in the order of highest to lowest ratings.
### /api/product/get
