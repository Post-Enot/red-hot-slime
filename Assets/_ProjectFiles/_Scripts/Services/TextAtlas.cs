using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Data Forms/Game Settings", order = 2)]
public sealed class TextAtlas : ScriptableObject
{
	private TranslateTable _languagesCsvTable;
	private Dictionary<string, string> _language;

	public event Action OnLanguageChanged;

	public void InitTranslateTable(string localPath, CsvFormatter csvFormatter)
	{
		_languagesCsvTable = new TranslateTable(csvFormatter, localPath);
		_languagesCsvTable.InitCacheData();
	}

	public void ChangeLanguage(string languageID, string defaultLanguageID)
	{
		_language = _languagesCsvTable.FormatLanguage(languageID, defaultLanguageID);
	}

	public string GetTextByCode(string code)
	{
		if (_language.ContainsKey(code))
		{
			return _language[code];
		}
		else
		{
			throw new ArgumentException($"Can't find text with {code} code.");
		}
	}
}
