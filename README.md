# EnumValueOptions - A gRPC Example

This code uses the Google Protocol Buffers library to work with enumerations.

It first retrieves the descriptor for the ProfilesEnum enumeration using the FindTypeByName method of the EnumDescriptor class.
Then it loops through all the values of the ProfilesEnum enumeration, retrieves the descriptor for each value, and prints the name of the enumeration value.

Next, it deals with deeply nested enumerable values. It creates a new HashSet to store the names of the nested enumeration values, and then retrieves an array of all the values of the Nested.Types.Type enumeration.
Then, it uses the GetAllMessages method, which is defined in the ProtobufDescriptorExtensions class, to get all the message descriptors and selects the EnumDescriptor for the Nested.Types.Type enumeration.

It then loops through the EnumDescriptors for the Nested.Types.Type enumeration and for each of the values of the Nested.Types.Type enumeration, retrieves the descriptor for that value, gets the name of the enumeration value, and adds it to the HashSet.

Finally, it loops through the HashSet and writes the names of the nested enumeration values to the console.


## ProtobufDescriptorExtensions

These methods are extension methods that are used to get all messages (including nested types) from a FileDescriptor and all nested types and self from a MessageDescriptor.
The GetAllMessages method takes a FileDescriptor as input, and returns an enumerable collection of MessageDescriptors by calling the SelectMany method on the MessageTypes property of the FileDescriptor and passing in the GetNestedTypesAndSelf method.
The GetNestedTypesAndSelf method takes a MessageDescriptor as input, and returns an enumerable collection of MessageDescriptors by concatenating the result of calling SelectMany on the NestedTypes property of the MessageDescriptor and passing in the GetNestedTypesAndSelf method with the Enumerable.Repeat method called on the messageDescriptor with parameter of 1.


## See it in action...

Inspect the source at:
- `EnumValueOptionsApp/Program.cs`
