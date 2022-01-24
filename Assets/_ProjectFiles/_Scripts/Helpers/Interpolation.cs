using UnityEngine;

public sealed class Interpolation
{
	public Vector3 Start { get; private set; }
	public Vector3 Final { get; private set; }
	public float StartTime { get; private set; }

	public Interpolation() { }

	public Interpolation(Vector3 start, Vector3 final, bool isInit = false)
	{
		Start = start;
		Final = final;
		if (isInit)
		{
			Init();
		}
	}

	public Vector3 CalculateLerp(in float factor = 1)
	{
		float step = (Time.time - StartTime) * factor;
		float x = Mathf.Lerp(Start.x, Final.x, step);
		float y = Mathf.Lerp(Start.y, Final.y, step);
		float z = Mathf.Lerp(Start.z, Final.z, step);
		return new Vector3(x, y, z);
	}

	public Vector3 CalculateSmoosthStep(in float factor = 1)
	{
		float step = (Time.time - StartTime) * factor;
		float x = Mathf.SmoothStep(Start.x, Final.x, step);
		float y = Mathf.SmoothStep(Start.y, Final.y, step);
		float z = Mathf.SmoothStep(Start.z, Final.z, step);
		return new Vector3(x, y, z);
	}

	public bool IsInProgress(Vector3 CurrentValue)
	{
		return !(CurrentValue == Final);
	}

	public void Init()
	{
		StartTime = Time.time;
	}

	public void Init(Vector3 start, Vector3 final)
	{
		Start = start;
		Final = final;
		StartTime = Time.time;
	}
}