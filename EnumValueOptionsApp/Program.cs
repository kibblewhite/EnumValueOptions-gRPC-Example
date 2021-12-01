// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

EnumDescriptor ProfilesEnumDescriptor = ProfilesEnumReflection.Descriptor.FindTypeByName<EnumDescriptor>(typeof(ProfilesEnum).Name);
foreach (ProfilesEnum profile_enum in Enum.GetValues(typeof(ProfilesEnum)))
{
    EnumValueDescriptor enum_value_descriptor = ProfilesEnumDescriptor.FindValueByNumber((int) profile_enum);
    var selector_value = enum_value_descriptor.GetOptions().GetExtension<string>(EnumValueOptionsExtensions.EnumName);
    Console.WriteLine(selector_value);
}

Console.ReadLine();
