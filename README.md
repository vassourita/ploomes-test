<!-- Generator: Widdershins v4.0.1 -->

<h1 id="ploomestest-api">PloomesTest API</h1>

> Developed for a technical test. This doc has been generated based on the OpenApi Specification.

This is a simple REST API for a single resource, where you can create, see, update, and delete items.

Swagger endpoints:

[Swagger UI](https://ploomestest-webapi.azurewebsites.net/)

[Swagger Json Docs](https://ploomestest-webapi.azurewebsites.net/swagger/v1/swagger.json)

Useful endpoints to test the API:

[CPF generator](https://www.4devs.com.br/gerador_de_cpf)

[CNPJ generator](https://www.4devs.com.br/gerador_de_cnpj)

<br/>
<br/>

<h1 id="ploomestest-api-client">Client</h1>

# `POST /api/clients`

*Creates a new client.*

> Body parameter

```json
{
  "federalDocument": "12345678000190",
  "name": "Ploomes",
  "email": "example@ploomes.com",
  "phone": "11912234556",
  "address": "Rua Ferreira de Araujo, Pinheiros, 79",
  "city": "São Paulo",
  "state": "SP",
  "zipCode": "05428000",
  "country": "Brasil"
}
```

<h3 id="post__api_clients-parameters">Parameters</h3>

| Name | In   | Type                                      | Required | Description                       |
| ---- | ---- | ----------------------------------------- | -------- | --------------------------------- |
| body | body | [CreateClientDto](#schemacreateclientdto) | false    | The payload to create the client. |

> Example responses

> 201 Response

```json
{
  "id": "497f6eca-6276-4993-bfeb-53cbbbba6f08",
  "type": 1,
  "typeName": "company",
  "federalDocument": "12345678000190",
  "name": "Ploomes",
  "email": "example@ploomes.com",
  "phone": "11912234556",
  "address": "Rua Ferreira de Araujo, Pinheiros, 79",
  "city": "São Paulo",
  "state": "SP",
  "zipCode": "05428000",
  "country": "Brasil",
  "createdAt": "2019-08-24T14:15:22Z",
  "updatedAt": "2019-08-24T14:15:22Z"
}
```

<h3 id="post__api_clients-responses">Responses</h3>

| Status | Meaning                                                          | Description | Schema                        |
| ------ | ---------------------------------------------------------------- | ----------- | ----------------------------- |
| 201    | [Created](https://tools.ietf.org/html/rfc7231#section-6.3.2)     | Success     | [Client](#schemaclient)       |
| 400    | [Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1) | Bad Request | [ErrorList](#schemaerrorlist) |

<aside class="success">
This operation does not require authentication
</aside>

<br/>
<br/>

# `GET /api/clients`

*Gets all clients within the given page, page size, query and client type.*

<h3 id="get__api_clients-parameters">Parameters</h3>

| Name     | In    | Type           | Required | Description                                                                                   |
| -------- | ----- | -------------- | -------- | --------------------------------------------------------------------------------------------- |
| page     | query | integer(int32) | false    | The page number.                                                                              |
| pageSize | query | integer(int32) | false    | The page size.                                                                                |
| query    | query | string         | false    | The company name to be searched.                                                              |
| type     | query | string         | false    | The company type to be filtered. Must be 'person' or 'company', otherwise it will be ignored. |

> Example responses

> 200 Response

```json
[
  {
    "id": "497f6eca-6276-4993-bfeb-53cbbbba6f08",
    "type": 1,
    "typeName": "company",
    "federalDocument": "12345678000190",
    "name": "Ploomes",
    "email": "example@ploomes.com",
    "phone": "11912234556",
    "address": "Rua Ferreira de Araujo, Pinheiros, 79",
    "city": "São Paulo",
    "state": "SP",
    "zipCode": "05428000",
    "country": "Brasil",
    "createdAt": "2019-08-24T14:15:22Z",
    "updatedAt": "2019-08-24T14:15:22Z"
  }
]
```

<h3 id="get__api_clients-responses">Responses</h3>

| Status | Meaning                                                 | Description | Schema |
| ------ | ------------------------------------------------------- | ----------- | ------ |
| 200    | [OK](https://tools.ietf.org/html/rfc7231#section-6.3.1) | Success     | Inline |

<h3 id="get__api_clients-responseschema">Response Schema</h3>

Status Code **200**

| Name              | Type                                   | Required | Restrictions | Description                                                                             |
| ----------------- | -------------------------------------- | -------- | ------------ | --------------------------------------------------------------------------------------- |
| *anonymous*       | [[Client](#schemaclient)]              | false    | none         | [Client entity definition.]                                                             |
| » id              | string(uuid)                           | true     | read-only    | Client's unique identifier.                                                             |
| » type            | [ClientType](#schemaclienttype)(int32) | true     | none         | Client type definition. The length of the federal document will define the client type. |
| » typeName        | string                                 | true     | read-only    | Client's type.                                                                          |
| » federalDocument | string                                 | true     | none         | Client's CPF or CNPJ.                                                                   |
| » name            | string                                 | true     | none         | Client's name.                                                                          |
| » email           | string                                 | true     | none         | Client's email address.                                                                 |
| » phone           | string                                 | true     | none         | Client's phone number.                                                                  |
| » address         | string                                 | true     | none         | Client's address.                                                                       |
| » city            | string                                 | true     | none         | Client's city.                                                                          |
| » state           | string                                 | true     | none         | Client's state.                                                                         |
| » zipCode         | string                                 | true     | none         | Client's zip code.                                                                      |
| » country         | string                                 | true     | none         | Client's country.                                                                       |
| » createdAt       | string(date-time)                      | true     | none         | Client's creation date.                                                                 |
| » updatedAt       | string(date-time)                      | true     | none         | Client's last update date.                                                              |

#### Enumerated Values

| Property | Value |
| -------- | ----- |
| type     | 0     |
| type     | 1     |

<aside class="success">
This operation does not require authentication
</aside>

<br/>
<br/>

# `GET /api/clients/{id}`

*Gets the client with the given id.*

<h3 id="getclientbyid-parameters">Parameters</h3>

| Name | In   | Type         | Required | Description    |
| ---- | ---- | ------------ | -------- | -------------- |
| id   | path | string(uuid) | true     | The client id. |

> Example responses

> 200 Response

```json
{
  "id": "497f6eca-6276-4993-bfeb-53cbbbba6f08",
  "type": 1,
  "typeName": "company",
  "federalDocument": "12345678000190",
  "name": "Ploomes",
  "email": "example@ploomes.com",
  "phone": "11912234556",
  "address": "Rua Ferreira de Araujo, Pinheiros, 79",
  "city": "São Paulo",
  "state": "SP",
  "zipCode": "05428000",
  "country": "Brasil",
  "createdAt": "2019-08-24T14:15:22Z",
  "updatedAt": "2019-08-24T14:15:22Z"
}
```

<h3 id="getclientbyid-responses">Responses</h3>

| Status | Meaning                                                        | Description | Schema                                  |
| ------ | -------------------------------------------------------------- | ----------- | --------------------------------------- |
| 200    | [OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)        | Success     | [Client](#schemaclient)                 |
| 404    | [Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4) | Not Found   | [ProblemDetails](#schemaproblemdetails) |

<aside class="success">
This operation does not require authentication
</aside>

<br/>
<br/>

# `DELETE /api/clients/{id}`

*Deletes the client with the given id.*

<h3 id="delete__api_clients_{id}-parameters">Parameters</h3>

| Name | In   | Type         | Required | Description                         |
| ---- | ---- | ------------ | -------- | ----------------------------------- |
| id   | path | string(uuid) | true     | The id of the client to be deleted. |

<h3 id="delete__api_clients_{id}-responses">Responses</h3>

| Status | Meaning                                                         | Description | Schema                                  |
| ------ | --------------------------------------------------------------- | ----------- | --------------------------------------- |
| 204    | [No Content](https://tools.ietf.org/html/rfc7231#section-6.3.5) | Success     | None                                    |
| 404    | [Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)  | Not Found   | [ProblemDetails](#schemaproblemdetails) |

<aside class="success">
This operation does not require authentication
</aside>

<br/>
<br/>

# `PUT /api/clients/{id}`

*Updates the client with the given id.*

> Body parameter

```json
{
  "federalDocument": "12345678000190",
  "name": "Ploomes",
  "email": "contact@ploomes.com",
  "phone": "11999999999",
  "address": "Rua Ferreira de Araujo, Pinheiros, 80",
  "city": "São Paulo",
  "state": "SP",
  "zipCode": "05428000",
  "country": "Brasil"
}
```

<h3 id="put__api_clients_{id}-parameters">Parameters</h3>

| Name | In   | Type                                      | Required | Description                         |
| ---- | ---- | ----------------------------------------- | -------- | ----------------------------------- |
| id   | path | string(uuid)                              | true     | The id of the client to be updated. |
| body | body | [UpdateClientDto](#schemaupdateclientdto) | false    | The payload to update the client.   |

> Example responses

> 200 Response

```json
{
  "id": "497f6eca-6276-4993-bfeb-53cbbbba6f08",
  "type": 1,
  "typeName": "company",
  "federalDocument": "12345678000190",
  "name": "Ploomes",
  "email": "contact@ploomes.com",
  "phone": "11999999999",
  "address": "Rua Ferreira de Araujo, Pinheiros, 80",
  "city": "São Paulo",
  "state": "SP",
  "zipCode": "05428000",
  "country": "Brasil",
  "createdAt": "2019-08-24T14:15:22Z",
  "updatedAt": "2019-08-24T14:15:22Z"
}
```

<h3 id="put__api_clients_{id}-responses">Responses</h3>

| Status | Meaning                                                          | Description | Schema                        |
| ------ | ---------------------------------------------------------------- | ----------- | ----------------------------- |
| 200    | [OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)          | Success     | [Client](#schemaclient)       |
| 400    | [Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1) | Bad Request | [ErrorList](#schemaerrorlist) |

<aside class="success">
This operation does not require authentication
</aside>

# Schemas

<h2 id="tocS_Client">Client</h2>
<!-- backwards compatibility -->
<a id="schemaclient"></a>
<a id="schema_Client"></a>
<a id="tocSclient"></a>
<a id="tocsclient"></a>

```json
{
  "id": "497f6eca-6276-4993-bfeb-53cbbbba6f08",
  "type": 1,
  "typeName": "company",
  "federalDocument": "12345678000190",
  "name": "Ploomes",
  "email": "example@ploomes.com",
  "phone": "11912234556",
  "address": "Rua Ferreira de Araujo, Pinheiros, 79",
  "city": "São Paulo",
  "state": "SP",
  "zipCode": "05428000",
  "country": "Brasil",
  "createdAt": "2019-08-24T14:15:22Z",
  "updatedAt": "2019-08-24T14:15:22Z"
}

```

Client entity definition.

### Properties

| Name            | Type                            | Required | Restrictions | Description                                                                             |
| --------------- | ------------------------------- | -------- | ------------ | --------------------------------------------------------------------------------------- |
| id              | string(uuid)                    | true     | read-only    | Client's unique identifier.                                                             |
| type            | [ClientType](#schemaclienttype) | true     | none         | Client type definition. The length of the federal document will define the client type. |
| typeName        | string                          | true     | read-only    | Client's type.                                                                          |
| federalDocument | string                          | true     | none         | Client's CPF or CNPJ.                                                                   |
| name            | string                          | true     | none         | Client's name.                                                                          |
| email           | string                          | true     | none         | Client's email address.                                                                 |
| phone           | string                          | true     | none         | Client's phone number.                                                                  |
| address         | string                          | true     | none         | Client's address.                                                                       |
| city            | string                          | true     | none         | Client's city.                                                                          |
| state           | string                          | true     | none         | Client's state.                                                                         |
| zipCode         | string                          | true     | none         | Client's zip code.                                                                      |
| country         | string                          | true     | none         | Client's country.                                                                       |
| createdAt       | string(date-time)               | true     | none         | Client's creation date.                                                                 |
| updatedAt       | string(date-time)               | true     | none         | Client's last update date.                                                              |

<h2 id="tocS_CreateClientDto">CreateClientDto</h2>
<!-- backwards compatibility -->
<a id="schemacreateclientdto"></a>
<a id="schema_CreateClientDto"></a>
<a id="tocScreateclientdto"></a>
<a id="tocscreateclientdto"></a>

```json
{
  "federalDocument": "12345678000190",
  "name": "Ploomes",
  "email": "example@ploomes.com",
  "phone": "11912234556",
  "address": "Rua Ferreira de Araujo, Pinheiros, 79",
  "city": "São Paulo",
  "state": "SP",
  "zipCode": "05428000",
  "country": "Brasil"
}

```

Payload used to create a client.

### Properties

| Name            | Type          | Required | Restrictions | Description                                                                                                          |
| --------------- | ------------- | -------- | ------------ | -------------------------------------------------------------------------------------------------------------------- |
| federalDocument | string        | true     | none         | Client's CPF or CNPJ. Must be unique. Should contain only digits (11 or 14). The length will define the client type. |
| name            | string        | true     | none         | Client's name.                                                                                                       |
| email           | string(email) | true     | none         | Client's email address.                                                                                              |
| phone           | string        | true     | none         | Client's phone number. Should contain only digits and the region code, up to a maximum of 11 digits.                 |
| address         | string        | true     | none         | Client's address.                                                                                                    |
| city            | string        | true     | none         | Client's city.                                                                                                       |
| state           | string        | true     | none         | Client's state.                                                                                                      |
| zipCode         | string        | true     | none         | Client's zip code.                                                                                                   |
| country         | string        | true     | none         | Client's zip country.                                                                                                |

<h2 id="tocS_ErrorList">ErrorList</h2>
<!-- backwards compatibility -->
<a id="schemaerrorlist"></a>
<a id="schema_ErrorList"></a>
<a id="tocSerrorlist"></a>
<a id="tocserrorlist"></a>

```json
{
  "errors": [
    "Invalid federal document. Try a valid CPF or CNPJ, without punctuation"
  ]
}

```

A validation errors list.

### Properties

| Name   | Type     | Required | Restrictions | Description |
| ------ | -------- | -------- | ------------ | ----------- |
| errors | [string] | true     | none         | none        |

<h2 id="tocS_ProblemDetails">ProblemDetails</h2>
<!-- backwards compatibility -->
<a id="schemaproblemdetails"></a>
<a id="schema_ProblemDetails"></a>
<a id="tocSproblemdetails"></a>
<a id="tocsproblemdetails"></a>

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string"
}

```

Error details of a failed 404 request.


### Properties

| Name                     | Type                | Required | Restrictions | Description |
| ------------------------ | ------------------- | -------- | ------------ | ----------- |
| **additionalProperties** | any                 | false    | none         | none        |
| type                     | string¦null         | false    | none         | none        |
| title                    | string¦null         | false    | none         | none        |
| status                   | integer(int32)¦null | false    | none         | none        |
| detail                   | string¦null         | false    | none         | none        |
| instance                 | string¦null         | false    | none         | none        |

<h2 id="tocS_UpdateClientDto">UpdateClientDto</h2>
<!-- backwards compatibility -->
<a id="schemaupdateclientdto"></a>
<a id="schema_UpdateClientDto"></a>
<a id="tocSupdateclientdto"></a>
<a id="tocsupdateclientdto"></a>

```json
{
  "federalDocument": "12345678000190",
  "name": "Ploomes",
  "email": "example@ploomes.com",
  "phone": "11912234556",
  "address": "Rua Ferreira de Araujo, Pinheiros, 79",
  "city": "São Paulo",
  "state": "SP",
  "zipCode": "05428000",
  "country": "Brasil"
}

```

Payload used to update a client.

### Properties

| Name            | Type               | Required | Restrictions | Description                                                                                                          |
| --------------- | ------------------ | -------- | ------------ | -------------------------------------------------------------------------------------------------------------------- |
| federalDocument | string¦null        | false    | none         | Client's CPF or CNPJ. Must be unique. Should contain only digits (11 or 14). The length will define the client type. |
| name            | string¦null        | false    | none         | Client's name.                                                                                                       |
| email           | string(email)¦null | false    | none         | Client's email address.                                                                                              |
| phone           | string¦null        | false    | none         | Client's phone number. Should contain only digits and the region code, up to a maximum of 11 digits.                 |
| address         | string¦null        | false    | none         | Client's address.                                                                                                    |
| city            | string¦null        | false    | none         | Client's city.                                                                                                       |
| state           | string¦null        | false    | none         | Client's state.                                                                                                      |
| zipCode         | string¦null        | false    | none         | Client's zip code.                                                                                                   |
| country         | string¦null        | false    | none         | Client's zip country.                                                                                                |

