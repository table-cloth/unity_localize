using UnityEditor;
using UnityEngine;
using System.Linq;

/// <summary>
/// Hierarchy view extensions
/// </summary>
public class HierarchyExt : CommonViewExt {

	/// <summary>
	/// Initialize this instance.
	/// </summary>
	[InitializeOnLoadMethod]
	public new static void Initialize()
	{
		EditorApplication.hierarchyWindowItemOnGUI += OnGUI;
	}

	/// <summary>
	/// Call each GUI extend events from here
	/// </summary>
	/// <param name="instanceID">Instance ID.</param>
	/// <param name="selectionRect">Selection rect.</param>
	static void OnGUI(int instanceID, Rect selectionRect)
	{
		SwitchColorPerLine (selectionRect);
		ShowAlertOnComponentWarning (instanceID, selectionRect);
		ShowAttachedComponents (instanceID, selectionRect);
	}

	/// <summary>
	/// Shows the alert on component warning.
	/// </summary>
	/// <param name="instanceID">Instance I.</param>
	/// <param name="selectionRect">Selection rect.</param>
	static void ShowAlertOnComponentWarning(int instanceID, Rect selectionRect)
	{
		GameObject gameObject = EditorUtility.InstanceIDToObject (instanceID) as GameObject;
		if (gameObject == null)
		{
			return;
		}

		bool isWarningValid = gameObject.GetComponents<MonoBehaviour> ().Any (c => c == null);
		if (!isWarningValid)
		{
			return;
		}

		Rect pos = selectionRect;
		pos.x = ALERT_WARNING_MARGIN_LEFT;
		pos.width = ALERT_WARNING_WIDTH;

		Color color = GUI.contentColor;
		GUI.contentColor = ALERT_WARNING_TEXT_COLOR;
		GUI.Label (pos, ALERT_WARNING_TEXT);
		GUI.contentColor = color;
	}

	/// <summary>
	/// Shows the attached components.
	/// </summary>
	/// <param name="instanceID">Instance I.</param>
	/// <param name="selectionRect">Selection rect.</param>
	static void ShowAttachedComponents(int instanceID, Rect selectionRect)
	{
		GameObject gameObject = EditorUtility.InstanceIDToObject (instanceID) as GameObject;
		if (gameObject == null)
		{
			return;
		}

		Rect pos = selectionRect;
		pos.x = pos.xMax - COMPONENT_ICON_WIDTH;
		pos.width = COMPONENT_ICON_WIDTH;
		pos.height = COMPONENT_ICON_HEIGHT;

		// get list of attached components
		System.Collections.Generic.IEnumerable<Component> components = 
			gameObject
				.GetComponents<Component> ()
				.Where (c => c != null)
				.Where (c => !(c is Transform))
				.Reverse ();

		foreach (Component component in components)
		{
			Texture image = AssetPreview.GetMiniThumbnail (component);
			if (image == null && component is MonoBehaviour)
			{
				MonoScript monoScript = MonoScript.FromMonoBehaviour (component as MonoBehaviour);
				string assetPath = AssetDatabase.GetAssetPath (monoScript);
				image = AssetDatabase.GetCachedIcon (assetPath);
			}

			if (image == null)
			{
				continue;
			}

			Color color = GUI.color;
			GUI.color = IsEnabled (component)
				? COMPONENT_COLOR_ENABLED
				: COMPONENT_COLOR_DISABLED;
			GUI.DrawTexture (pos, image, ScaleMode.ScaleToFit);
			GUI.color = color;
			pos.x -= pos.width;

		}
	}

	/// <summary>
	/// Determines if is enabled the specified component.
	/// </summary>
	/// <returns><c>true</c> if is enabled the specified component; otherwise, <c>false</c>.</returns>
	/// <param name="component">Component.</param>
	private static bool IsEnabled(Component component)
	{
		System.Reflection.PropertyInfo propertyInfo = GetPropertyInfo (component);
		if (propertyInfo == null)
		{
			return true;
		}

		return (bool) propertyInfo.GetValue(component, null);
	}

	/// <summary>
	/// Gets the property info.
	/// </summary>
	/// <returns>The property info.</returns>
	/// <param name="component">Component.</param>
	private static System.Reflection.PropertyInfo GetPropertyInfo(Component component)
	{
		if (component == null)
		{
			return null;
		}

		System.Type type = component.GetType ();
		System.Reflection.PropertyInfo propertyInfo = type.GetProperty (KEY_ENABLED, typeof(bool));

		return propertyInfo;
	}
}
