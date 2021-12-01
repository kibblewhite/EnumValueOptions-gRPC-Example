// See https://aka.ms/new-console-template for more information
using Google.Protobuf.Reflection;
using Options.Common;

Console.WriteLine("Hello, World!");

EnumDescriptor SystemRoleTypeTypeEnumDescriptor = ProfilesEnumReflection.Descriptor.FindTypeByName<EnumDescriptor>(typeof(ProfilesEnum).Name);
foreach (ProfilesEnum system_role_type in Enum.GetValues(typeof(ProfilesEnum)))
{
    EnumValueDescriptor enum_value_descriptor = SystemRoleTypeTypeEnumDescriptor.FindValueByNumber((int)system_role_type);
    var selector_value = enum_value_descriptor.GetOptions().GetExtension<string>(EnumValueOptionsExtensions.EnumName);
    Console.WriteLine(selector_value);
}

Console.ReadLine();
