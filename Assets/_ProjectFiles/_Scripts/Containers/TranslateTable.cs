using UnityEngine;
using System;
using System.Collections.Generic;

public sealed class TranslateTable
{
	private const int _headlineIndex = 0;
	private const int _textCodesLineIndex = 1;
	private const int _languagesLineIndexOffset = 2;

	private readonly CsvFormatter _csvFormatter;
	private readonly string _localPath;

	private Dictionary<string, int> _languageIndexes;
	private string[] _textCodes;
	private string[] _tableLines;

	private string Headline => _tableLines[_headlineIndex];
	private string TextCodesLine => _tableLines[_textCodesLineIndex];

	public TranslateTable(CsvFormatter csvFormatter, string localPath)
	{
		_localPath = localPath;
		_csvFormatter = csvFormatter;
	}

	public void InitCacheData()
	{
		if (_tableLines is null)
		{
			_tableLines = LoadTable();
		}
		if (_languageIndexes is null)
		{
			_languageIndexes = FormatLanguagesIndexes();
		}
		if (_textCodes is null)
		{
			_textCodes = SplitTextCodesLine();
		}
	}

	public void CleanCacheData()
	{
		_tableLines = null;
		_languageIndexes = null;
		_textCodes = null;
	}

	public Dictionary<string, string> FormatLanguage(string currentLanguageID, string defaultLanguageID)
	{
		string[] defaultLanguageTexts = SplitLanguageLine(defaultLanguageID);
		string[] currentLanguageTexts = SplitLanguageLine(currentLanguageID);
		var language = new Dictionary<string, string>(_textCodes.Length);
		for (int i = 0; i < _textCodes.Length; i++)
		{
			string text;
			if (CheckTextValidacity(currentLanguageTexts, i))
			{
				text = currentLanguageTexts[i];
			}
			else if (CheckTextValidacity(defaultLanguageTexts, i))
			{
				text = defaultLanguageTexts[i];
			}
			else
			{
				text = _textCodes[i];
			}
			language.Add(_textCodes[i].Trim(), text);
		}
		return language;
	}

	private bool CheckTextValidacity(string[] texts, int textIndex)
	{
		return texts.Length > textIndex && texts[textIndex] != string.Empty;
	}

	private Dictionary<string, int> FormatLanguagesIndexes()
	{
		string[] languageIDs = _csvFormatter.SplitLine(Headline);
		var languageIndexes = new Dictionary<string, int>(languageIDs.Length);
		for (int i = 0; i < languageIDs.Length; i++)
		{
			if (languageIDs[i] != string.Empty)
			{
				if (!languageIndexes.ContainsKey(languageIDs[i]))
				{
					int languageIndex = _languagesLineIndexOffset + i;
					languageIndexes.Add(languageIDs[i].Trim(), languageIndex);
				}
				else
				{
					throw new ArgumentException();
				}
			}
			else
			{
				throw new ArgumentException();
			}
		}
		return languageIndexes;
	}

	private string[] LoadTable()
	{
		var csvTable = Resources.Load<TextAsset>(_localPath);
		return _csvFormatter.SplitTable(csvTable.text);
	}

	private string[] SplitLanguageLine(string languageID)
	{
		if (_languageIndexes.ContainsKey(languageID))
		{
			int languageIndex = _languageIndexes[languageID];
			string languageLine = _tableLines[languageIndex];
			return _csvFormatter.SplitLine(languageLine);
		}
		else
		{
			throw new ArgumentException();
		}
	}

	private string[] SplitTextCodesLine()
	{
		string[] textCodes = _csvFormatter.SplitLine(TextCodesLine);
		textCodes[textCodes.Length - 1] = TrimFinalChar(textCodes[textCodes.Length - 1]); // отрефакторить эту хуйню
		return textCodes;
	}

	private string TrimFinalChar(string text)
	{
		return text.Substring(0, text.Length - 1);
	}
}
