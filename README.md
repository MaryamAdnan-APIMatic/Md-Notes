# Getting Started with MdNotes

## Getting Started

### Introduction

API for Markdown Notes app.

### Building

The generated code uses the Newtonsoft Json.NET NuGet Package. If the automatic NuGet package restore is enabled, these dependencies will be installed automatically. Therefore, you will need internet access for build.

* Open the solution (MdNotes.sln) file.

Invoke the build process using Ctrl + Shift + B shortcut key or using the Build menu as shown below.

The build process generates a portable class library, which can be used like a normal class library. The generated library is compatible with Windows Forms, Windows RT, Windows Phone 8, Silverlight 5, Xamarin iOS, Xamarin Android and Mono. More information on how to use can be found at the MSDN Portable Class Libraries documentation.

### Installation

The following section explains how to use the UNIREST library in a new project.

#### 1. Starting a new project

For starting a new project, right click on the current solution from the solution explorer and choose `Add -> New Project`.

![Add a new project in Visual Studio](https://apidocs.io/illustration/cs?workspaceFolder=MdNotes-CSharp&workspaceName=MdNotes&projectName=UNIREST&rootNamespace=UNIREST&step=addProject)

Next, choose `Console Application`, provide `TestConsoleProject` as the project name and click OK.

![Create a new Console Application in Visual Studio](https://apidocs.io/illustration/cs?workspaceFolder=MdNotes-CSharp&workspaceName=MdNotes&projectName=UNIREST&rootNamespace=UNIREST&step=createProject)

#### 2. Set as startup project

The new console project is the entry point for the eventual execution. This requires us to set the `TestConsoleProject` as the start-up project. To do this, right-click on the `TestConsoleProject` and choose `Set as StartUp Project` form the context menu.

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=MdNotes-CSharp&workspaceName=MdNotes&projectName=UNIREST&rootNamespace=UNIREST&step=setStartup)

#### 3. Add reference of the library project

In order to use the Tester library in the new project, first we must add a project reference to the `TestConsoleProject`. First, right click on the `References` node in the solution explorer and click `Add Reference...`

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=MdNotes-CSharp&workspaceName=MdNotes&projectName=UNIREST&rootNamespace=UNIREST&step=addReference)

Next, a window will be displayed where we must set the `checkbox` on `Tester.Tests` and click `OK`. By doing this, we have added a reference of the `Tester.Tests` project into the new `TestConsoleProject`.

![Creating a project reference](https://apidocs.io/illustration/cs?workspaceFolder=MdNotes-CSharp&workspaceName=MdNotes&projectName=UNIREST&rootNamespace=UNIREST&step=createReference)

#### 4. Write sample code

Once the `TestConsoleProject` is created, a file named `Program.cs` will be visible in the solution explorer with an empty `Main` method. This is the entry point for the execution of the entire solution. Here, you can add code to initialize the client library and acquire the instance of a Controller class. Sample code to initialize the client library and using Controller methods is given in the subsequent sections.

![Adding a project reference](https://apidocs.io/illustration/cs?workspaceFolder=MdNotes-CSharp&workspaceName=MdNotes&projectName=UNIREST&rootNamespace=UNIREST&step=addCode)

### Initialize the API Client

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `Environment` | Environment | The API environment. <br> **Default: `Environment.Production`** |
| `Timeout` | `TimeSpan` | Gets the http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |
| `OAuthClientId` | `string` | OAuth 2 Client ID |
| `OAuthRedirectUri` | `string` | OAuth 2 Redirection endpoint or Callback Uri |
| `OAuthToken` | `Models.OAuthToken` |  |

The API client can be initialized as follows:

```csharp
UNIREST.MdNotesClient client = new UNIREST.MdNotesClient.Builder()
    .ImplicitOAuthCredentials("OAuthClientId", "OAuthRedirectUri")
    .Environment(Environment.Production)
    .Build();
```

You must now authorize the client.

### Authorization

Your application must obtain user authorization before it can execute an endpoint call. The SDK uses *OAuth 2.0 Implicit Grant* to obtain a user's consent to perform an API request on user's behalf.

This process requires the presence of a client-side JavaScript code on the redirect URI page to receive the *access token* after the consent step is completed.

#### 1- Obtain user consent

To obtain user's consent, you must redirect the user to the authorization page. The `BuildAuthorizationUrl()` method creates the URL to the authorization page.

```csharp
string authUrl = client.Auth.BuildAuthorizationUrl();
```

#### 2- Handle the OAuth server response

Once the user responds to the consent request, the OAuth 2.0 server responds to your application's access request by redirecting the user to the redirect URI specified set in `Configuration`.

The redirect URI will receive the *access token* as the `token` argument in the URL fragment.

```
https://example.com/oauth/callback#token=XXXXXXXXXXXXXXXXXXXXXXXXX
```

The access token must be extracted by the client-side JavaScript code. The access token can be used to authorize any further endpoint calls by the JavaScript code.

## Client Class Documentation

### MdNotesClient Class

The gateway for the SDK. This class acts as a factory for the Controllers and also holds the configuration of the SDK.

#### Controllers

| Name | Description |
|  --- | --- |
| ServiceController | Gets ServiceController controller. |
| UserController | Gets UserController controller. |

#### Properties

| Name | Description | Type |
|  --- | --- | --- |
| Auth | Gets the AuthManager. | `AuthManager` |
| HttpClientConfiguration | Gets the configuration of the Http Client associated with this client. | `IHttpClientConfiguration` |
| Timeout | Gets the http client timeout. | `TimeSpan` |
| Environment | Gets the Current API environment. | `Environment` |

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `GetBaseUri(Server alias = Server.Default)` | Gets the URL for a particular alias in the current environment and appends it with template parameters. | `string` |
| `ToBuilder()` | Creates an object of the MdNotesClient using the values provided for the builder. | `Builder` |

## API Reference

### List of APIs

* [Service](#service)
* [User](#user)

### Service

#### Overview

##### Get instance

An instance of the `ServiceController` class can be accessed from the API Client.

```
ServiceController serviceController = client.ServiceController;
```

#### Get Status

```csharp
GetStatusAsync()
```

##### Response Type

[`Task<Models.ServiceStatus>`](#service-status)

##### Example Usage

```csharp
try
{
    ServiceStatus result = await serviceController.GetStatusAsync();
}
catch (ApiException e){};
```

### User

#### Overview

##### Get instance

An instance of the `UserController` class can be accessed from the API Client.

```
UserController userController = client.UserController;
```

#### Get User

```csharp
GetUserAsync()
```

##### Response Type

[`Task<Models.User>`](#user-1)

##### Example Usage

```csharp
try
{
    User result = await userController.GetUserAsync();
}
catch (ApiException e){};
```

## Model Reference

### Structures

* [Note](#note)
* [User](#user-1)
* [Service Status](#service-status)
* [O Auth Token](#o-auth-token)

#### Note

##### Class Name

`Note`

##### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `long` | Required | - |
| `Title` | `string` | Required | - |
| `Body` | `string` | Required | - |
| `UserId` | `long` | Required | - |
| `CreatedAt` | `string` | Required | - |
| `UpdatedAt` | `string` | Required | - |

##### Example (as JSON)

```json
{
  "id": 112,
  "title": "title4",
  "body": "body6",
  "user_id": 208,
  "created_at": "created_at2",
  "updated_at": "updated_at4"
}
```

#### User

##### Class Name

`User`

##### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Id` | `int` | Required | - |
| `Name` | `string` | Required | - |
| `Email` | `string` | Required | - |
| `CreatedAt` | `string` | Required | - |
| `UpdatedAt` | `string` | Required | - |

##### Example (as JSON)

```json
{
  "id": 112,
  "name": "name0",
  "email": "email6",
  "created_at": "created_at2",
  "updated_at": "updated_at4"
}
```

#### Service Status

##### Class Name

`ServiceStatus`

##### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `App` | `string` | Required | - |
| `Moto` | `string` | Required | - |
| `Notes` | `int` | Required | - |
| `Users` | `int` | Required | - |
| `Time` | `string` | Required | - |
| `Os` | `string` | Required | - |
| `PhpVersion` | `string` | Required | - |
| `Status` | `string` | Required | - |

##### Example (as JSON)

```json
{
  "app": "app2",
  "moto": "moto8",
  "notes": 134,
  "users": 202,
  "time": "time0",
  "os": "os8",
  "php_version": "php_version4",
  "status": "status8"
}
```

#### O Auth Token

OAuth 2 Authorization endpoint response

##### Class Name

`OAuthToken`

##### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AccessToken` | `string` | Required | Access token |
| `TokenType` | `string` | Required | Type of access token |
| `ExpiresIn` | `long?` | Optional | Time in seconds before the access token expires |
| `Scope` | `string` | Optional | List of scopes granted<br>This is a space-delimited list of strings. |
| `Expiry` | `long?` | Optional | Time of token expiry as unix timestamp (UTC) |

##### Example (as JSON)

```json
{
  "access_token": "access_token8",
  "token_type": "token_type2",
  "expires_in": null,
  "scope": null,
  "expiry": null
}
```

### Enumerations

* [O Auth Provider Error](#o-auth-provider-error)

#### O Auth Provider Error

OAuth 2 Authorization error codes

##### Class Name

`OAuthProviderErrorEnum`

##### Fields

| Name | Description |
|  --- | --- |
| `InvalidRequest` | The request is missing a required parameter, includes an unsupported parameter value (other than grant type), repeats a parameter, includes multiple credentials, utilizes more than one mechanism for authenticating the client, or is otherwise malformed. |
| `InvalidClient` | Client authentication failed (e.g., unknown client, no client authentication included, or unsupported authentication method). |
| `InvalidGrant` | The provided authorization grant (e.g., authorization code, resource owner credentials) or refresh token is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client. |
| `UnauthorizedClient` | The authenticated client is not authorized to use this authorization grant type. |
| `UnsupportedGrantType` | The authorization grant type is not supported by the authorization server. |
| `InvalidScope` | The requested scope is invalid, unknown, malformed, or exceeds the scope granted by the resource owner. |

### Exceptions

* [O Auth Provider](#o-auth-provider)

#### O Auth Provider

OAuth 2 Authorization endpoint exception

##### Class Name

`OAuthProviderException`

##### Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Error` | [`Models.OAuthProviderErrorEnum`](#o-auth-provider-error) | Required | Error code |
| `ErrorDescription` | `string` | Optional | Human-readable text providing additional information on error.<br>Used to assist the client developer in understanding the error that occurred. |
| `ErrorUri` | `string` | Optional | A URI identifying a human-readable web page with information about the error, used to provide the client developer with additional information about the error |

##### Example (as JSON)

```json
{
  "error": "invalid_request",
  "error_description": null,
  "error_uri": null
}
```

## Utility Classes Documentation

### ApiHelper Class

HttpRequest stores necessary information about the http request.

#### Properties

| Name | Description | Type |
|  --- | --- | --- |
| HttpMethod | The HTTP verb to use for this request. | `HttpMethod` |
| QueryUrl | The query url for the http request. | `string` |
| QueryParameters | Query parameters collection for the current http request. | `Dictionary<string, object>` |
| Headers | Headers collection for the current http request. | `Dictionary<string, string>` |
| FormParameters | Form parameters for the current http request. | `List<KeyValuePair<string, object>>` |
| Body | Optional raw string to send as request body. | `object` |
| Username | Optional username for Basic Auth. | `string` |
| Password | Optional password for Basic Auth. | `string` |

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `DeepCloneObject<T>(T obj)` | Creates a deep clone of an object by serializing it into a json string and then deserializing back into an object. | `T` |
| `JsonSerialize(object obj, JsonConverter converter = null)` | JSON Serialization of a given object. | `string` |
| `JsonDeserialize<T>(string json, JsonConverter converter = null)` | JSON Deserialization of the given json string. | `T` |

## Common Code Documentation

### HttpRequest Class

HttpResponse stores necessary information about the http response.

#### Properties

| Name | Description | Type |
|  --- | --- | --- |
| StatusCode | Gets the HTTP Status code of the http response. | `int` |
| Headers | Gets the headers of the http response. | `Dictionary<string, string>` |
| RawBody | Gets the stream of the body. | `Stream` |

#### Constructors

| Name | Description |
|  --- | --- |
| `HttpRequest(HttpMethod method, string queryUrl)` | Constructor to initialize the http request object. |
| `HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, string username, string password, Dictionary<string, object> queryParameters = null)` | Constructor to initialize the http request with headers and optional Basic auth params. |
| `HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, object body, string username, string password, Dictionary<string, object> queryParameters = null)` | Constructor to initialize the http request with headers, body and optional Basic auth params. |
| `HttpRequest(HttpMethod method, string queryUrl, Dictionary<string, string> headers, List<KeyValuePair<string, Object>> formParameters, string username, string password, Dictionary<string, object> queryParameters = null)` | Constructor to initialize the http request with headers, form parameters and optional Basic auth params. |

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `AddHeaders(Dictionary<string, string> HeadersToAdd)` | Concatenate values from a Dictionary to this object. | `Dictionary<string, string>` |
| `AddQueryParameters(Dictionary<string, object> queryParamaters)` | Concatenate values from a Dictionary to query parameters dictionary. | `void` |

### HttpResponse Class

HttpResponse stores necessary information about the http response.

#### Properties

| Name | Description | Type |
|  --- | --- | --- |
| StatusCode | Gets the HTTP Status code of the http response. | `int` |
| Headers | Gets the headers of the http response. | `Dictionary<string, string>` |
| RawBody | Gets the stream of the body. | `Stream` |

#### Constructors

| Name | Description |
|  --- | --- |
| `HttpResponse(int statusCode, Dictionary<string, string> headers, Stream rawBody)` | Initializes a new instance of the <see cref="HttpResponse"/> class. |

### HttpStringResponse Class

HttpStringResponse inherits from HttpResponse and has additional property of string body.

#### Properties

| Name | Description | Type |
|  --- | --- | --- |
| StatusCode | Gets the HTTP Status code of the http response. | `int` |
| Headers | Gets the headers of the http response. | `Dictionary<string, string>` |
| Body | Gets the raw string body of the http response. | `string` |

#### Constructors

| Name | Description |
|  --- | --- |
| ```HttpStringResponse(int statusCode, Dictionary<string, string> headers, Stream rawBody, string body)<br>        : base(statusCode, headers, rawBody)```<br>``` | Initializes a new instance of the <see cref="HttpStringResponse"/> class. |

### HttpContext Class

Represents the contextual information of HTTP request and response.

#### Properties

| Name | Description | Type |
|  --- | --- | --- |
| Request | Gets the http request in the current context. | `HttpRequest` |
| Response | Gets the http response in the current context. | `HttpResponse` |

#### Constructors

| Name | Description |
|  --- | --- |
| `HttpContext(HttpRequest request, HttpResponse response)` | Initializes a new instance of the <see cref="HttpContext"/> class. |

### IAuthManager Class

IAuthManager adds the authenticaion layer to the http calls.

#### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `Apply(HttpRequest httpRequest)` | Add authentication information to the HTTP Request. | `HttpRequest` |
| `ApplyAsync(HttpRequest httpRequest)` | Asynchronously add authentication information to the HTTP Request. | `Task<HttpRequest>` |

### ApiException Class

This is the base class for all exceptions that represent an error response from the server.

#### Properties

| Name | Description | Type |
|  --- | --- | --- |
| ResponseCode | Gets the HTTP response code from the API request. | `int` |
| HttpContext | Gets or sets the HttpContext for the request and response. | `HttpContext` |

#### Constructors

| Name | Description |
|  --- | --- |
| `ApiException(string reason, HttpContext context)` | Initializes a new instance of the <see cref="ApiException"/> class. |

