using System;

public interface IRandomWeightable<T>
{
	public T AccidentallyChoose(Func<int, int, int> randomNumberGenerator, T alternativeResult = default);
}
