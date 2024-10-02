# Blazor WebAssembly & .NET Core Web API Project

## Overview

This project consists of a **Blazor WebAssembly front-end** and a **.NET Core Web API** back-end. The Blazor application communicates with the Web API to perform asynchronous operations, including invoking APIs via both `GET` and `POST` methods. The Web API also supports Cross-Origin Resource Sharing (CORS) to allow calls from different domains or ports.

---

## Project Structure

- **Blazor WebAssembly (Frontend)**:
  - The Blazor app serves as the front-end, where users interact with the UI.
  - It makes HTTP requests (both `GET` and `POST` methods) to the frontend Web API.
  
- **ASP.NET Core Web API (Backend)**:
  - This API handles requests made from the Blazor front-end api.
  - Supports both `GET` and `POST` HTTP verbs.
  - Artificial delays are introduced in API calls to simulate long-running operations.

---

## Setup Instructions

### Prerequisites

- **.NET SDK 8.0 or later** installed.
- A modern web browser (preferably Chrome, Edge, or Firefox) for running the Blazor application.

### Steps to Run the Application

1. **Clone the repository**:
   ```
   git clone <repository-url>
   ```

2. **Navigate to the solution folder**:
   ```
   cd OneStream.Screening
   ```

3. **Run the Web API**:
   - Open a terminal and navigate to the Web API project folder.
   - Run the Web API:
     ```
     cd OneStream.Api.FrontendOne
     dotnet run

   - The Web API will be hosted at `https://localhost:7166`.

     cd OneStream.Api.BackendTwo
     dotnet run

   - The Web API will be hosted at `https://localhost:7002`.

     cd OneStream.Api.BackendThree
     dotnet run

   - The Web API will be hosted at `https://localhost:7023`.

4. **Run the Blazor WebAssembly App**:
   - Open a new terminal and navigate to the Blazor project folder.
   - Run the Blazor app:
     ```
     cd OneStream.Screening.Web
     dotnet run
     ```
   - The Blazor app will be hosted at `https://localhost:7114`.

5. **Test the Application**:
   - Open the Blazor WebAssembly app (`https://localhost:7114`).
   - Click the buttons in the UI to invoke the Web API and see the results reflected in the Blazor front-end.

---

## API Details

### 1. **GET Method**
   - **Endpoint**: `/api/My/GetData`
   - **Description**: Returns a simple JSON message and timestamp.
   - **Example Call**: 
     ```
     GET https://localhost:5001/api/My/GetData
     ```

### 2. **POST Method (Without Payload)**
   - **Endpoint**: `/api/My/PostData`
   - **Description**: This method does not take any payload and returns a message and timestamp.
   - **Example Call**:
     ```
     POST https://localhost:5001/api/My/PostData
     ```

---

## CORS Configuration

CORS is enabled in the **Web API** to allow the **Blazor WebAssembly** application (running on `https://localhost:7114`) to access the API (running on `https://localhost:7166`).

The CORS policy is configured in `Program.cs` of the Web API:

```csharp
// Register the CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("https://localhost:7114") // Blazor client URL
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});```

---

## How to Extend

1. **Add More Endpoints**: You can add more `GET`, `POST`, `PUT`, or `DELETE` methods to the Web API by creating new controller methods.

2. **UI Components in Blazor**: Blazor makes it easy to build interactive web UIs. You can create more components in the Blazor project and call new API methods from those components.

3. **Authentication and Authorization**: You can integrate **JWT** or **OAuth2** authentication for the API to secure the communication between the Blazor app and the Web API.

---

## Troubleshooting

1. **CORS Issues**:
   - Ensure that the Web API has CORS enabled and that the allowed origin (`https://localhost:5002` for Blazor) is correctly configured in the API's `Program.cs`.

2. **API Call Failures**:
   - If any API calls fail, check the console in the browser's developer tools for any CORS-related errors or network issues.

3. **SSL Issues**:
   - Make sure you are using `https://` in both the Blazor and API URLs. If you encounter SSL certificate warnings, you can manually trust the certificates for local development.

---

## Dependencies

- **.NET 8 SDK**
- **Blazor WebAssembly**
- **ASP.NET Core Web API**

---

## Unit Tests

The solution can be extended  for unit tests for the Web API methods. These tests can be written using the **XUnit** framework.

---

## License

This project is licensed under the MIT License.

---

## Contact

For any questions or issues, feel free to open an issue in the repository or contact the project maintainer.
