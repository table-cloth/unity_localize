using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;

/// <summary>
/// CSV reader.
/// </summary>
public class CSVReader
{
    private const string CSVFileExtension = ".csv";
    private static readonly string[] CSVCellSeparator = { "," };

    /// <summary>
    /// Loads from assets.
    /// </summary>
    /// <returns>The from assets.</returns>
    /// <param name="fileName">File name.</param>
    public static CSVData LoadFromAssets(String fileName)
    {
        CSVData data = new CSVData();
        
        TextAsset textAsset = Resources.Load<TextAsset>(fileName);
        TextReader textReader = new StringReader(textAsset.text);

        // Skim through all colums
        String lineText = null;
        int columnIndex = 0;
        while ((lineText = textReader.ReadLine()) != null)
        {
            // Skip if row content is empty
            string[] rowContentsArray = lineText.Split(CSVCellSeparator, StringSplitOptions.None);
            if (rowContentsArray == null || rowContentsArray.Length <= 0)
            {
                columnIndex ++;
                continue;
            }

            Dictionary<int, string> rowDictionary = new Dictionary<int, string>();
            for (int i = 0; i < rowContentsArray.Length; i++)
            {
                rowDictionary.Add(i, rowContentsArray[i]);
            }

            data.AddData(columnIndex, rowDictionary);

            columnIndex ++;
        }

        Resources.UnloadAsset(textAsset);
        textAsset = null;
        textReader = null;

        return data;
    }
}
