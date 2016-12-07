using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowLocaleSample : MonoBehaviour {

    [SerializeField]
    private Text textField;

	// Use this for initialization
	void Start () {
        textField.text =
            "Locale : "
            + TextManager.Instance.GetText(TextKey.SampleKey1);
	}	
}
