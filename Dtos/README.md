### Data Object Contracts (DTO's):

```
    Dto is a design pattern used to tranfer data between software application
    subsystems, layers, or components specially in an microservices architecture.

    Its purpose is to encapsulate and transport data accross different parts of the system or microservices.

    Key characteristics:
        1. Simplified data represnetation
        2. Transfer between layers
        3. Avoid overhead of transferring unnecessary data.
        4. Reduces coupling of parts of the system.
        5. Control and limit of expossed information to different parts of the system.
```

```C#

// Example

// Original Entity representing a User in the database
public class UserEntity
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    // Other properties...
}

// Data Transfer Object for presenting user information to the UI
public class UserDTO
{
    public int Id { get; set; }
    public string Username { get; set; }
    // Other properties relevant to the UI...
}

```