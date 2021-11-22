# Spreetail Multi-Value Dictionary App

## Available Commands

| Command | Description |
| - | - |
| Keys | Returns all the keys in the dictionary |
| Members *<key>* | Returns the collection of strings for the given key. |
| Add *<key> <value>* | Adds a value to a collection for a given key |
| Remove *<key> <value>* | Removes a member from a key |
| RemoveAll *<key>* | Removes all members for a key and removes the key from the dictionary |
| Clear | Removes all keys and all members from the dictionary |
| KeyExists *<key>*| Returns whether a key exists or not |
| MemberExsists *<key> <value>*| Returns whether a member exists within a key |
| AllMembers | Returns all the members in the dictionary. |
| Items | Returns all keys in the dictionary and all of their members |

##System Requirements
 - .NET 6.0 Runtime
 - .NET 6.0 SDK
 
## How to Run
From the root directory `dotnet run --project .\Spreetail.MultiValueDictionary.Console\Spreetail.MultiValueDictionary.Console.csproj`