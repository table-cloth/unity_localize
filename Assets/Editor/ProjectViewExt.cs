using UnityEditor;
using UnityEngine;
using System.IO;

/// <summary>
/// Project view extentios
/// </summary>
public class ProjectViewExt : CommonViewExt {

	/// <summary>
	/// Initialize this instance.
	/// </summary>
	[InitializeOnLoadMethod]
	static new void Initialize()
	{
		EditorApplication.projectWindowItemOnGUI += OnGUI;
	}

	/// <summary>
	/// Call each GUI extend events from here
	/// </summary>
	/// <param name="guid">GUID.</param>
	/// <param name="selectionRect">Selection rect.</param>
	static void OnGUI(string guid, Rect selectionRect)
	{
		SwitchColorPerLine (selectionRect);
		ShowExtensionInfo (guid, selectionRect);
	}

	static void ShowExtensionInfo(string guid, Rect selectionRect)
	{
		string assetPath = AssetDatabase.GUIDToAssetPath (guid);
		string extension = Path.GetExtension (assetPath);

		// Do nothing with ones with no extension info
		if (string.IsNullOrEmpty (extension))
		{
			return;
		}

		GUIStyle label = EditorStyles.label;
		GUIContent content = new GUIContent (extension);
		float width = label.CalcSize (content).x;

		// make it align parent right
		Rect pos = selectionRect;
		pos.x = pos.xMax - width;
		pos.width = width;

		Color color = GUI.contentColor;
		GUI.contentColor = EXTENSION_TEXT_COLOR;
		GUI.Label (pos, extension);
		GUI.contentColor = color;
	}
}
