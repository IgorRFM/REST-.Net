# Gallery API

- [Gallery API](#buber-art-api)
  - [Create art](#create-art)
    - [Create art Request](#create-art-request)
    - [Create art Response](#create-art-response)
  - [Get art](#get-art)
    - [Get art Request](#get-art-request)
    - [Get art Response](#get-art-response)
  - [Update art](#update-art)
    - [Update art Request](#update-art-request)
    - [Update art Response](#update-art-response)
  - [Delete art](#delete-art)
    - [Delete art Request](#delete-art-request)
    - [Delete art Response](#delete-art-response)

## Create art

### Create art Request

```js
POST /arts
```

```json
{
    "title": "Butterfly Parade",
    "description": "Uma mulher loira com cabelos tingidos em verde - a personagem 'Jolyne' da obra JJBA - com uma peça de roupa de borboleta",
    "publishDate": "2025-04-08",
    "artistName": "Igor Ribeiro",
    "artistSocial": "@Artigor_",
    "tags": [
        "fanart",
        "digital art",
        "half body",
        "jolyne"
    ],
    "type": [
        "illustration"
    ]
}
```

### Create art Response

```js
201 Created
```

```yml
Location: {{host}}/arts/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "lastModifiedDateTime": "2025-04-06T12:00:00",
    "title": "Butterfly Parade",
    "description": "Uma mulher loira com cabelos tingidos em verde - a personagem 'Jolyne' da obra JJBA - com uma peça de roupa de borboleta",
    "publishDate": "2025-04-08",
    "artistName": "Igor Ribeiro",
    "artistSocial": "@Artigor_",
    "tags": [
        "fanart",
        "digital art",
        "half body",
        "jolyne"
    ],
    "type": [
        "illustration"
    ]
}
```

## Get art

### Get art Request

```js
GET /arts/{{id}}
```

### Get art Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "lastModifiedDateTime": "2025-04-06T12:00:00",
    "title": "Butterfly Parade",
    "description": "Uma mulher loira com cabelos tingidos em verde - a personagem 'Jolyne' da obra JJBA - com uma peça de roupa de borboleta",
    "publishDate": "2025-04-08",
    "artistName": "Igor Ribeiro",
    "artistSocial": "@Artigor_",
    "tags": [
        "fanart",
        "digital art",
        "half body",
        "jolyne"
    ],
    "type": [
        "illustration"
    ]
}
```

## Update art

### Update art Request

```js
PUT /arts/{{id}}
```

```json
{
    "title": "Butterfly Parade",
    "description": "Uma mulher loira com cabelos tingidos em verde - a personagem 'Jolyne' da obra JJBA - com uma peça de roupa de borboleta",
    "publishDate": "2025-04-08",
    "artistName": "Igor Ribeiro",
    "artistSocial": "@Artigor_",
    "tags": [
        "fanart",
        "digital art",
        "half body",
        "jolyne"
    ],
    "type": [
        "illustration"
    ]
}
```

### Update art Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/arts/{{id}}
```

## Delete art

### Delete art Request

```js
DELETE /arts/{{id}}
```

### Delete art Response

```js
204 No Content
```