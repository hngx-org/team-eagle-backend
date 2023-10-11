# Documentation

## Portfolios

<summary>
This Endpoint is to fetch all the portfolios on the platform.
</summary>

<details>

### Get All Portfolios

- **GET** : `/api/explore/GetAllPortfolio` returns 
  ```
  {
  "data": [
    {
    "profileUrl": "Tremayne",
    "firstName": "Lincoln",
    "lastName": "Elinore",
    "address": "Uptonside, Oman",
    "provider": "Rhett",
    "location": "Uptonside",
    "ranking": "Beginner",
    "track": "Mobile",
    "tag": "British Indian Ocean Territory (Chagos Archipelago)",
    "skills": [],
    "projects": 0
  },
  {
    "profileUrl": "Tremayne",
    "firstName": "Lincoln",
    "lastName": "Elinore",
    "address": "Uptonside, Oman",
    "provider": "Rhett",
    "location": "Uptonside",
    "ranking": "Beginner",
    "track": "Mobile",
    "tag": "British Indian Ocean Territory (Chagos Archipelago)",
    "skills": [],
    "projects": 0
  }
    
  ],
  "message": "Items retireved successfully",
  "isSuccessful": true,
  "statusCode": 200
    }
  ```

- **GET** : `/api/explore/search/Jaclyn` returns
```
{
  "data": [
    {
    "profileUrl": "Tremayne",
    "firstName": "Lincoln",
    "lastName": "Elinore",
    "address": "Uptonside, Oman",
    "provider": "Rhett",
    "location": "Uptonside",
    "ranking": "Beginner",
    "track": "Mobile",
    "tag": "British Indian Ocean Territory (Chagos Archipelago)",
    "skills": [],
    "projects": 0
  }
  ],
  "message": "Items retireved successfully",
  "isSuccessful": true,
  "statusCode": 200
}
``` 


</details>
<summary>
This documentation provides information about the Portfolio API and how to use the `GetAllPortfolioFilter` endpoint.
</summary>

<detail>

## Table of Contents

- [Endpoint](#endpoint)
- [HTTP Method](#http-method)
- [Request](#request)
- [Response](#response)
- [Examples](#examples)

## Endpoint

- **URL**: `/api/portfolios/filter`
- **Description**: Get portfolios based on specified filters.

## HTTP Method

- **Method**: GET

## Request

### Query Parameters

- `Skill` (optional, string): Filter portfolios by skill.
- `Country` (optional, string): Filter portfolios by country.
- `Track` (optional, string): Filter portfolios by track.
- `Ranking` (optional, string): Filter portfolios by ranking.
- `Tag` (optional, string): Filter portfolios by tag.
- `Location` (optional, string): Filter portfolios by location.
- `Provider` (optional, string): Filter portfolios by provider.
- `RoleId` (optional, int): Filter portfolios by role ID.

## Response

### Successful Response

- **Status Code**: 200 OK
- **Content-Type**: application/json

#### Example Response

```json
{
  "status": "success",
  "message": "Items retrieved successfully",
  "data": [
    {
    "profileUrl": "Tremayne",
    "firstName": "Lincoln",
    "lastName": "Elinore",
    "address": "Uptonside, Oman",
    "provider": "Rhett",
    "location": "Uptonside",
    "ranking": "Beginner",
    "track": "Mobile",
    "tag": "British Indian Ocean Territory (Chagos Archipelago)",
    "skills": [],
    "projects": 0
  },
    {
    "profileUrl": "Tremayne",
    "firstName": "Lincoln",
    "lastName": "Elinore",
    "address": "Uptonside, Oman",
    "provider": "Rhett",
    "location": "Uptonside",
    "ranking": "Beginner",
    "track": "Mobile",
    "tag": "British Indian Ocean Territory (Chagos Archipelago)",
    "skills": [],
    "projects": 0
  }
    // ... other portfolio entries
  ]
}
```

### Error Response

- **Status Code**: 400 Bad Request
- **Content-Type**: application/json

#### Example Error Response

```json
{
  "status": "error",
  "message": "Invalid input. Please check your parameters.",
  "data": null
}
```

## Examples

### Request Example

- **Endpoint**: `/api/portfolios/filter?Skill=Skill1&Country=USA&RoleId=1`
- **Description**: Filter portfolios by skill (Skill1), country (USA), and role ID (1).

### Response Example

- **Status Code**: 200 OK
- **Content-Type**: application/json

#### Response Body

```json
{
  "status": "success",
  "message": "Items retrieved successfully",
  "data": [
    {
    "profileUrl": "Tremayne",
    "firstName": "Lincoln",
    "lastName": "Elinore",
    "address": "Uptonside, Oman",
    "provider": "Rhett",
    "location": "Uptonside",
    "ranking": "Beginner",
    "track": "Mobile",
    "tag": "British Indian Ocean Territory (Chagos Archipelago)",
    "skills": [],
    "projects": 0
  }
  ]
}
```

</detail>