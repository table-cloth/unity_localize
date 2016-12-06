using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    private const string LocalizeFileName = "UnityLocalizeSample";
    private const string LangJA = "JA";
    private CSVData csvData = null;
    private LocaleTextData localeTextData;

	// Use this for initialization
	void Start () {
        csvData = CSVReader.LoadFromAssets(LocalizeFileName);
        localeTextData = new LocaleTextData(csvData);
//        string text = textData.GetValueAt(0, 1);
//        Debug.Log("text: " + text);

        localeTextData.SetLocale(Locale.JA);
        string jaText = localeTextData.GetLocalizedText(TextKey.SampleKey1);
        string enText = localeTextData.GetLocalizedText(Locale.EN, TextKey.SampleKey1);

        Debug.Log("JA: " + jaText);
        Debug.Log("EN: " + enText);
	}
}
