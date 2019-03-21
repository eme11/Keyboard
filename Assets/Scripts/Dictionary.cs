using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dictionary : MonoBehaviour {

	private List<string> _content;
	public InputField _input;
	public Button _button;
	public Dropdown _suggestions;
	// Use this for initialization
	void Start () {
		_content = new List<string> ();
		_content.Add ("dummy");
		_content.Add ("hello");
		_content.Add ("world");
		_content.Add ("foo");
		_content.Add ("bar");

		_button = GetComponent<Button> ();
		_button.onClick.AddListener(OnClickTask);

		_input = GameObject.Find ("SearchWord").GetComponent<InputField> ();
	}

	void OnClickTask()
	{
		string word = _input.text;
		List<string> possibileMatches = findSuggestions (word);
		Debug.Log ("1." + possibileMatches [0]);
		handleUIElements (possibileMatches);
	}

	void handleUIElements(List<string> dropDown)
	{
		if (dropDown.Count <= 0) {
			return;
		}

		Debug.Log ("UI");
		_suggestions.enabled = true;
		_suggestions.ClearOptions ();
		_suggestions.AddOptions (dropDown);
		_suggestions.RefreshShownValue ();
		_suggestions.Show ();
	}
		

	public List<string> findSuggestions(string word)
	{
		if (word == null) {
			Debug.Log ("empty");
			return null;
		}
		List<string> possibleMatches = new List<string> ();
		int length = word.Length;
		foreach (string currentWord in _content) {
			if (currentWord.Substring(0,length).Equals(word))
			{
				Debug.Log ("found something");
				possibleMatches.Add(currentWord);
			}
		}
		return possibleMatches;
	}

}
