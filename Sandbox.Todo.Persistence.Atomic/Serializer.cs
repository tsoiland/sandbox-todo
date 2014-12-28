namespace Sandbox.Todo.Persistence.Atomic
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public class Serializer
    {
        public Stream Serialize(object entity)
        {
            var binaryFormatter = new BinaryFormatter();
            var stream = new MemoryStream();
            binaryFormatter.Serialize(stream, entity);
            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        public object Deserialize(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var binaryFormatter = new BinaryFormatter();
            return binaryFormatter.Deserialize(stream);
        }
    }
}