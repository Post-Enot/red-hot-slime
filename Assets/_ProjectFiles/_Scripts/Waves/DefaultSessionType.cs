using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SessionType", menuName = "Session Types/Default Session Type", order = 1)]
public sealed class DefaultSessionType : SessionType
{
	[SerializeField] private Wave _defaultWave;
	[SerializeField] private Wave _chillWave;
	[SerializeField] private SerializableWeightedList<Wave> _bonusWaves;

	[Space]

	[SerializeField] private int _default�ontractingWavesCount;
	[SerializeField] private int _bonusContractingWavesCount;

	private int WavesCount => _bonusContractingWavesCount + _default�ontractingWavesCount;
	[NonSerialized] private bool _isPreviousWaveWasChilled;
	private int _waveNumber;

	public override Wave GetNextWave()
	{
		Wave wave = ChooseNextWave();
		wave.InitDifficultyLevel(DifficultyLevel);
		return wave;
	}

	private Wave ChooseNextWave()
	{
		_waveNumber += 1;
		if (_waveNumber > WavesCount)
		{
			_waveNumber = 1;
		}
		if (_isPreviousWaveWasChilled)
		{
			_isPreviousWaveWasChilled = false;
			return _waveNumber <= _default�ontractingWavesCount ? _defaultWave : _bonusWaves.AccidentallyChoose();
		}
		else
		{
			_isPreviousWaveWasChilled = true;
			return _chillWave;
		}
	}
}
