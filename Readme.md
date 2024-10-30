
# Messaging Integration Library

This library provides a default approach to integrate messaging functionality into your system, allowing consumers to listen to specific topics and handle messages effectively.

## Getting Started

To use this library, follow the steps below to configure the necessary components in your project.

### Prerequisites

-   .NET Core 6.0+ (or compatible version)
-   Access to a messaging broker, such as Kafka

## Installation

Add the library to your project:

`dotnet add package YourMessagingLibraryName` 

## Usage

### Step 1: Add the Library in Your Project

Once the library is added, configure your consumers by creating a static class with an extension method as follows:

1.  Create a new file in your project (e.g., `ConsumerConfiguration.cs`).
2.  Define your consumers and topic settings.


```csharp 
using Microsoft.Extensions.DependencyInjection;

public static class ConsumerConfiguration
{
    public static void AddConsumers(this IServiceCollection services)
    {
        var consumers = new Consumers();

        services.AddSingleton(new List<IConsumerSettings>
        {
            new ConsumerSettings<YourDataClass>("your-topic", consumers.ConsumeYourDataFunction)
        });
    }
}
``` 

### Step 2: Register Consumers in the Builder

In your application's `Program.cs` or `Startup.cs`, register the consumers using the extension method created in Step 1:

```csharp
builder.Services.AddConsumers();
``` 

### Step 3: Add the Hosted Service

Add the hosted service to start processing messages automatically:

```csharp
builder.Services.AddHostedService<Consumer>();
```

### Step 4: Configure Messaging Settings

Add the necessary configuration details in your `appsettings.json` file:

``` json
{
  "Messaging": {
    "GroupId": "this-service",
    "Servers": "localhost:9092"
  }
}
``` 

## Example Configuration

In this example, we use the `ConsumerSettings` class to specify topics and consumer logic:

-   **GroupId**: Specifies the consumer group this service belongs to.
-   **Servers**: Lists the servers (e.g., Kafka brokers) that this service connects to.
