using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager {

    private static TextManager instance = null;
    public static TextManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TextManager();
            }
            return instance;
        }
    }

    private const string LocalizeFileName = "UnityLocalizeSample";

    private CSVData csvData = null;
    private LocaleTextData localeTextData;

    /// <summary>
    /// Initializes a new instance of the <see cref="TextManager"/> class.
    /// </summary>
    public TextManager ()
    {
        csvData = CSVReader.LoadFromAssets(LocalizeFileName);
        localeTextData = new LocaleTextData(csvData);
	}

    /// <summary>
    /// Gets the text in the set locale.
    /// </summary>
    /// <returns>The text.</returns>
    /// <param name="textKey">Text key.</param>
    public string GetText(string textKey)
    {
        return localeTextData.GetLocalizedText(textKey);
    }
}
