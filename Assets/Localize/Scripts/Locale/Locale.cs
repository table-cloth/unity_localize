using UnityEngine;
using System.Collections;

/// <summary>
/// Const Values for localization related
/// Make sure same key is used in csv
/// If the key does not match, text data from csv will be invalid
/// </summary>
public class Locale {

    /// <summary>
    /// Japanese Locale Key
    /// </summary>
    public const string JA = "JA";

    /// <summary>
    /// English Locale Key
    /// </summary>
    public const string EN = "EN";

    /// <summary>
    /// Vietnamese Locale Key
    /// </summary>
    public const string VN = "VN";

    /// <summary>
    /// Gets the locale key, referring to the systemLanguage.
    /// </summary>
    /// <returns>The system locale key.</returns>
    public static string GetSystemLocaleKey()
    {
        switch (Application.systemLanguage.ToString())
        {
            case "Japanese":
                return JA;

            case "Vietnamese":
                return VN;

            case "English":
            default:
                return EN;
        }
    }
}
