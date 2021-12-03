public sealed class CsvFormatter
{
	public char LineSeparator => _lineSeparator;
	public char CellSeparator => _cellSeparator;

	private char _lineSeparator;
	private char _cellSeparator;

	public CsvFormatter(char lineSeparator, char cellSeparator)
	{
		_lineSeparator = lineSeparator;
		_cellSeparator = cellSeparator;
	}

	public string[] SplitTable(string table) => table.Split(_lineSeparator);
	public string[] SplitLine(string line) => line.Split(_cellSeparator);
}
