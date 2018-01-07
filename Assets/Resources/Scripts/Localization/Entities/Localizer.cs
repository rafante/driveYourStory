using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Localizer {

	private static Localizer _instance;
	private Dictionary<string,LangTerm[]> langs;
	public const string baseLanguage = "pt-BR";
	public string curLanguage;

	private Localizer(LanguagesText langsTxt){
		langs = new Dictionary<string,LangTerm[]> ();
		foreach (var lang in langsTxt.languages) {
			langs.Add (lang.langCode, lang.terms);
			Debug.Log (lang.langCode + ":" + lang.terms);
		}
	}

	public LangTerm[] getTerms(string language = ""){
		if (language.Equals (""))
			curLanguage = baseLanguage;
		else
			curLanguage = language;
		return langs [curLanguage];
	}

	public static string key(string key, string lang = ""){
		var localizer = get();
		LangTerm[] terms = localizer.getTerms (lang);
		foreach (var term in terms) {
			if (term.key.Equals (key))
				return term.value;
		}
		return key;
	}

	public static Localizer get(){
		if (_instance != null)
			return _instance;
		var texts = Resources.Load<TextAsset> ("Scripts/Localization/texts");
		return get (texts.text);
	}

	public static Localizer get(string texts, bool isFile = false){
		if (isFile) {
			texts = "";
			StreamReader reader = new StreamReader (texts);
			texts = reader.ReadToEnd ();
			reader.Close ();
		}
		if (_instance == null) {
			var langs = JsonUtility.FromJson<LanguagesText> (texts);
			_instance = new Localizer (langs);
		}
		return _instance;
	}
}	
