namespace EnumValueOptionsApp;

/// <summary>
/// Extension class for working with FileDescriptor and MessageDescriptor
/// </summary>
/// <remarks>https://github.com/protocolbuffers/protobuf/issues/10696#issuecomment-1274313835</remarks>
public static class ProtobufDescriptorExtensions
{
    /// <summary>
    /// Extension method for getting all messages (including nested types) from a FileDescriptor
    /// </summary>
    /// <param name="fileDescriptor">The FileDescriptor to get messages from</param>
    /// <returns>An enumerable collection of MessageDescriptors</returns>
    public static IEnumerable<MessageDescriptor> GetAllMessages(this FileDescriptor fileDescriptor) =>
        fileDescriptor.MessageTypes.SelectMany(GetNestedTypesAndSelf);

    /// <summary>
    /// Extension method for getting all nested types and self from a MessageDescriptor
    /// </summary>
    /// <param name="messageDescriptor">The MessageDescriptor to get nested types from</param>
    /// <returns>An enumerable collection of MessageDescriptors</returns>
    public static IEnumerable<MessageDescriptor> GetNestedTypesAndSelf(this MessageDescriptor messageDescriptor) =>
        Enumerable.Repeat(messageDescriptor, 1).Concat(messageDescriptor.NestedTypes.SelectMany(GetNestedTypesAndSelf));
}
