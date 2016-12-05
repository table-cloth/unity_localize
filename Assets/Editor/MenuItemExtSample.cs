using UnityEngine;
using UnityEditor;
using System.Collections;

/// <summary>
/// Menu item extensions sample
/// </summary>
public class MenuItemExtSample : MonoBehaviour {

	/// <summary>
	/// Create "New Empty Prefab" menu in Assets -> Create
	/// This method will create empty prefab
	/// If prefab with same name already exists, it will NOT create new prefab
	/// </summary>
	[MenuItem("Assets/Create/New Empty Prefab")]
	public static void CreateEmptyPrefab ()
	{
		string name = "target";
		string outputPath = "Assets/Prefab.prefab";

		GameObject gameObject = EditorUtility.CreateGameObjectWithHideFlags (name, HideFlags.HideInHierarchy);

		PrefabUtility.CreatePrefab (outputPath, gameObject);

		Editor.DestroyImmediate (gameObject);
	}

	/// <summary>
	/// Creates "Menu1" menu in "CustomMenu/FakeMenu"
	/// </summary>
	[MenuItem("CustomMenu/FakeMenu/Menu1")]
	public static void Menu1 ()
	{
	}

	/// <summary>
	/// Creates "Menu2" menu in "CustomMenu/FakeMenu"
	/// </summary>
	[MenuItem("CustomMenu/FakeMenu/Menu2")]
	public static void Menu2 ()
	{
	}

	/// <summary>
	/// Create "CheckedMenu" in "CustomMenu"
	/// </summary>
	[MenuItem("CustomMenu/CheckedMenu")]
	public static void CheckMenu ()
	{
		string menuPath = "CustomMenu/CheckedMenu";
		bool isChecked = Menu.GetChecked (menuPath);
		Menu.SetChecked (menuPath, !isChecked);
	}
		
	/// <summary>
	/// Creates "MenuPriority2" menu in "CustomMenu/FakeMenu"
	/// Menu with priority, will be shown on top compared with menu without priority
	/// Menu with lower priority will be shown on top
	/// 
	/// If the priority differes more than 10, menu will be shown separated with line
	/// </summary>
	[MenuItem("CustomMenu/FakeMenu/MenuPriority2", false, 2)]
	public static void MenuPriority2 ()
	{
	}

	/// <summary>
	/// Creates "MenuPriority1" menu in "CustomMenu/FakeMenu"
	/// Menu with priority, will be shown on top compared with menu without priority
	/// Menu with lower priority will be shown on top
	/// 
	/// If the priority differes more than 10, menu will be shown separated with line
	/// </summary>
	[MenuItem("CustomMenu/FakeMenu/MenuPriority1", false, 1)]
	public static void MenuPriority1 ()
	{
	}

	/// <summary>
	/// Creates "MenuPriority1" menu in "CustomMenu/FakeMenu"
	/// Menu with priority, will be shown on top compared with menu without priority
	/// Menu with lower priority will be shown on top
	/// 
	/// If the priority differes more than 10, menu will be shown separated with line
	/// </summary>
	[MenuItem("CustomMenu/FakeMenu/MenuPriority13", false, 13)]
	public static void MenuPriority13 ()
	{
	}

	/// <summary>
	/// Creates "Shortcut_Shift_F1" in "CustomShortcutMenu"
	/// This menu can be activated by pressing #F1 (Shift + F1)
	/// 
	/// Menu name & shortcut key is declared as following
	/// [Menuitem("<MenuPath> <ShortcutKey>")]
	/// 
	/// [Shortcut Keys]
	/// %	        : Ctrl / Cmd
	/// #	        : Shift
	/// &	        : Alt / Option
	/// F1 ... F12  : Function Key
	/// HOME        : Home Key
	/// END         : End Key
	/// PGUP        : PageUp Key
	/// PGDN        : PageDown Key
	/// KP0 ... KP9 : Number Key 0 ~ 9
	/// KP.         : .
	/// KP+         : +
	/// KP-         : -
	/// KP*         : *
	/// KP/         : /
	/// KP=         : =
	/// </summary>
	[MenuItem("CustomShortcutMenu/Shortcut_Shift_F1 #F1")]
	public static void Shortcut_Shift_F1 ()
	{
		Debug.Log ("Shortcut Shift + F1 Pressed");
	}
}
