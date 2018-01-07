using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpdater : MonoBehaviour {

	public UnityEngine.UI.Text[] texts;
	public Dictionary<UnityEngine.UI.Text,string> keys;

	void Start(){
		initialize ();
	}

	public void initialize(){
		keys = new Dictionary<UnityEngine.UI.Text,string> ();
		foreach (var txt in texts) {
			keys.Add (txt, txt.text);
		}
	}

	public void updateTexts(string language = ""){
		foreach (var key in keys) {
			key.Key.text = Localizer.key (key.Value, language);
		}
	}
}
