using UnityEngine;
using System.Collections;
using System.Runtime.ConstrainedExecution;
using System.Collections.Generic;
using System;

/// <summary>
/// Handles localized texts assigned in CSV
/// </summary>
public class LocaleTextData {

    /// <summary>
    /// The locale CSV data.
    /// </summary>
    private readonly CSVData LocaleCSVData;

    /// <summary>
    /// The index of the invalid.
    /// </summary>
    private const int InvalidIndex = -1;

    /// <summary>
    /// The index of the locale info column.
    /// </summary>
    private int localeKeyColumnIndex = 0;

    /// <summary>
    /// The index of the text key row.
    /// </summary>
    private int textKeyRowIndex = 1;

    /// <summary>
    /// The locale key.
    /// </summary>
    private string localeKey = null;

    /// <summary>
    /// The row index for set locale.
    /// </summary>
    private int localeTextRowIndex = InvalidIndex;

    /// <summary>
    /// Initializes a new instance of the <see cref="LocaleCSVData"/> class.
    /// </summary>
    public LocaleTextData(CSVData localeCSVData)
    {
        if (localeCSVData == null)
        {
            Debug.LogError("Locale CSV data is null");
            return;
        }

        LocaleCSVData = localeCSVData;
    }

    /// <summary>
    /// Sets the locale.
    /// </summary>
    /// <param name="localeKey">Locale key.</param>
    public void SetLocale(string localeKey)
    {
        this.localeKey = localeKey;
        localeTextRowIndex = LocaleCSVData.GetRowIndex(this.localeKey, localeKeyColumnIndex);
    }

    /// <summary>
    /// Sets the index of the locale data column.
    /// 
    /// Set this if the column index is not default value (1)
    /// </summary>
    /// <param name="columnIndex">Column index.</param>
    public void SetLocaleDataColumnIndex(int columnIndex)
    {
        localeKeyColumnIndex = columnIndex;
    }

    /// <summary>
    /// Sets the index of the localized text key row.
    /// 
    /// Set this if the row index is not default value (1)
    /// </summary>
    /// <param name="rowIndex">Row index.</param>
    public void SetLocalizedTextKeyRowIndex(int rowIndex)
    {
        textKeyRowIndex = rowIndex;
    }

    /// <summary>
    /// Gets the localized text.
    /// </summary>
    /// <returns>The localized text.</returns>
    /// <param name="textKey">Text key.</param>
    public string GetLocalizedText(string textKey)
    {
        return GetLocalizedText(localeKey, textKey);
    }

    /// <summary>
    /// Gets the localized text.
    /// </summary>
    /// <returns>The localized text.</returns>
    /// <param name="localeKey">Locale key.</param>
    /// <param name="textKey">Text key.</param>
    public string GetLocalizedText(string localeKey, string textKey)
    {
        int localeTextRowIndex = 
            string.Equals(this.localeKey, localeKey)
                ? this.localeTextRowIndex
                : LocaleCSVData.GetRowIndex(localeKey, this.localeKeyColumnIndex);

        // Error if invalid locale data
        if (String.IsNullOrEmpty(localeKey)
            || localeTextRowIndex == InvalidIndex)
        {
            Debug.LogError("Invalid key data. [key] " + localeKey + ", [rowIndex] " + localeTextRowIndex);
            return null;
        }

        return LocaleCSVData.GetValueAtRow(localeTextRowIndex, textKey, this.textKeyRowIndex);
    }
}
