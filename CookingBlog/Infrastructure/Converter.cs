using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace CookingBlog.Infrastructure;

public static class Converter
{
    public static string ToJson(this object? item)
    {
        return item == null ? "{}" : JsonConvert.SerializeObject(item);
    }

    public static string ToXml<T>(this T body)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var writer = new StringWriter();
        serializer.Serialize(writer, body);

        return writer.ToString();
    }

    public static T FromJson<T>(this string source)
    {
        return JsonConvert.DeserializeObject<T>(source, new JsonSerializerSettings
        {
            Error = (_, args) => { args.ErrorContext.Handled = true; }
        })!;
    }

    public static T FromJson<T>(this Stream stream) where T : class
    {
        return (new DataContractJsonSerializer(typeof(T)).ReadObject(stream) as T)!;
    }
}
