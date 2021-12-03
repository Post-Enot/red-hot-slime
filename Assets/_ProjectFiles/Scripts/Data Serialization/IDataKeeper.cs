public interface IDataKeeper
{
	public void SaveData<T>(string serializationKey, T serializedDataContainer);
	public T UploadData<T>(string serializationKey);
}
