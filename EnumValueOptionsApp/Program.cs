// See https://aka.ms/new-console-template for more information

using EnumValueOptionsApp;
Console.WriteLine("=========================================");
Console.WriteLine("Shallow/Single Depth");

// EnumDescriptor for ProfilesEnum and then Loop through all values of ProfilesEnum
EnumDescriptor ProfilesEnumDescriptor = ProfilesEnumReflection.Descriptor.FindTypeByName<EnumDescriptor>(typeof(ProfilesEnum).Name);
foreach (ProfilesEnum profile_enum in Enum.GetValues(typeof(ProfilesEnum)))
{
    // Get descriptor for each value of ProfilesEnum
    EnumValueDescriptor enum_value_descriptor = ProfilesEnumDescriptor.FindValueByNumber((int) profile_enum);

    // Get name of the enumeration value and print name of the enumeration value
    string selector_value = enum_value_descriptor.GetOptions().GetExtension<string>(EnumValueOptionsExtensions.EnumName);
    Console.WriteLine(selector_value);
}

Console.WriteLine("=========================================");
Console.WriteLine("Deeply-Nested Object");

// Dealing with deeply nested enumerable values

// Create HashSet to store names of nested enumeration values
HashSet<string> nested_hashset_types = new();

// Get an array of all values of Nested.Types.Type enumeration
Array enum_value_array = Enum.GetValues(typeof(Nested.Types.Type));

// Get all message descriptors -> methods are in ProtobufDescriptorExtensions.cs
IEnumerable<MessageDescriptor> message_descriptors = NestedReflection.Descriptor.GetAllMessages();

// Select the EnumDescriptor for Nested.Types.Type enumeration and then Loop through EnumDescriptors for Nested.Types.Type enumeration
IEnumerable<EnumDescriptor> nested_types_enum_descriptors = message_descriptors.Select(x => x.FindDescriptor<EnumDescriptor>(nameof(Nested.Types.Type)));
foreach (EnumDescriptor NestedTypeEnumDescriptor in nested_types_enum_descriptors)
{
    // Loop through values of Nested.Types.Type enumeration
    foreach (Nested.Types.Type type_enum in enum_value_array)
    {
        // Get descriptor for each value of Nested.Types.Type enumeration
        EnumValueDescriptor enum_value_descriptor = NestedTypeEnumDescriptor.FindValueByNumber((int)type_enum);

        // Get name of the enumeration value and add to HashSet
        string selector_value = enum_value_descriptor.GetOptions().GetExtension<string>(EnumValueOptionsExtensions.EnumName);
        nested_hashset_types.Add(selector_value);
    }
}

// Loop through HashSet and print the name of the enumeration value
foreach (string nested_type_selector_value in nested_hashset_types)
{
    Console.WriteLine(nested_type_selector_value);
}

// Hold the console window open, it's only polite...
Console.ReadLine();
