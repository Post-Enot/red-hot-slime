using UnityEngine;

public static class ErrorLog
{
	public static void SingletonInstanceError(string gameObjectName)
	{
		Debug.LogError($"More than one instance of the class {gameObjectName} exists");
	}

	public static void RepeatedVariableInit(string gameObjectName)
	{
		Debug.Log($"Repeated variable init on {gameObjectName} game object");
	}

	public static void RepeatedClassInit(GameObject gameObject)
	{
		Debug.LogError("Repeated class init", gameObject);
	}
}
