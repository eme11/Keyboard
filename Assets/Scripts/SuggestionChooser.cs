using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuggestionChooser : MonoBehaviour {

	public Button _suggestion;
	public InputField _searchBar;
	// Use this for initialization
	void Awake(){
		_suggestion = GetComponent<Button> ();
	}
	void Start () {
		_suggestion.onClick.AddListener(OnClickTask);
		_searchBar = GameObject.Find ("SearchWord").GetComponent<InputField> ();
	}

	private string ExtractTextFromButton(){
		Text tmp = _suggestion.GetComponentInChildren<Text>();
		return tmp.text.ToString ();
	}

	void OnClickTask(){
		string value = ExtractTextFromButton ();
		_searchBar.text = value;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
