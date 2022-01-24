using System.IO;
using System.Xml.Serialization;

public class XmlSaver<T> where T : new()
{
	public void Save(string filePathWithoutFileExtension, T serializedObject)
	{
		var _serializer = new XmlSerializer(typeof(T));
		string filePath = $"{filePathWithoutFileExtension}.xml";
		var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
		_serializer.Serialize(fileStream, serializedObject);
		fileStream.Close();
	}

	public T Upload(string filePathWithoutFileExtension)
	{
		var _serializer = new XmlSerializer(typeof(T));
		string filePath = $"{filePathWithoutFileExtension}.xml";
		if (File.Exists(filePath))
		{
			var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			var deserializedObject = (T)_serializer.Deserialize(fileStream);
			fileStream.Close();
			return deserializedObject;
		}
		else
		{
			return new T();
		}
	}
}
