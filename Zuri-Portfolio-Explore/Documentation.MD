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
      "firstName": "Scotty",
      "lastName": "Milton",
      "provider": "Tressie",
      "skills": [],
      "projects": 0
    },
    {
      "firstName": "Charlene",
      "lastName": "Marcia",
      "provider": "Lolita",
      "skills": [],
      "projects": 0
    },
    {
      "firstName": "Adolphus",
      "lastName": "Maddison",
      "provider": "Demond",
      "skills": [],
      "projects": 0
    },
    {
      "firstName": "Erica",
      "lastName": "Stewart",
      "provider": "Coralie",
      "skills": [
        "Bailee"
      ],
      "projects": 0
    },
    {
      "firstName": "Jeanie",
      "lastName": "Roderick",
      "provider": "Winnifred",
      "skills": [],
      "projects": 0
    },
    {
      "firstName": "Aurore",
      "lastName": "Austen",
      "provider": "Casimir",
      "skills": [],
      "projects": 0
    },
    {
      "firstName": "Korey",
      "lastName": "Rosario",
      "provider": "Louvenia",
      "skills": [
        "Samara"
      ],
      "projects": 0
    },
    {
      "firstName": "Casimer",
      "lastName": "Alison",
      "provider": "Elenora",
      "skills": [
        "Joan"
      ],
      "projects": 0
    },
    {
      "firstName": "Sarah",
      "lastName": "Vaughn",
      "provider": "Kyra",
      "skills": [],
      "projects": 0
    },
    {
      "firstName": "Quentin",
      "lastName": "Kaleb",
      "provider": "Anya",
      "skills": [],
      "projects": 0
    },
    {
      "firstName": "Catharine",
      "lastName": "Isabella",
      "provider": "Geovanny",
      "skills": [],
      "projects": 0
    },
    {
      "firstName": "Oceane",
      "lastName": "Nikko",
      "provider": "Jamaal",
      "skills": [],
      "projects": 0
    },
    {
      "firstName": "Frederick",
      "lastName": "Frida",
      "provider": "Deonte",
      "skills": [
        "Kale"
      ],
      "projects": 0
    },
    {
      "firstName": "Frederick",
      "lastName": "Jaclyn",
      "provider": "Noemi",
      "skills": [],
      "projects": 0
    },
    {
      "firstName": "Jayde",
      "lastName": "Oral",
      "provider": "Marguerite",
      "skills": [
        "Lonnie"
      ],
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
      "firstName": "Frederick",
      "lastName": "Jaclyn",
      "provider": "Noemi",
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