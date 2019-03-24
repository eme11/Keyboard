using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dictionary : MonoBehaviour {

	private List<string> _content;
	public InputField _input;
	public Button _button;
	public Button _suggestion1;
	public Button _suggestion2;
	public Button _suggestion3;
	public Button _suggestion4;
	public Button _suggestion5;
	public Button _suggestion6;

	// Use this for initialization
	void Start () {
		_content = new List<string> ();
		_content.Add ("dummy");
		_content.Add ("hello");
		_content.Add ("world");
		_content.Add ("foo");
		_content.Add ("bar");
		_content.Add ("baaar");
		_content.Add ("barr");
		_content.Add ("babbr");
		_content.Add ("babyy");
		_content.Add ("barrrrrr");
		_content.Add ("baar");

		_button = GetComponent<Button> ();
		_button.onClick.AddListener(OnClickTask);

		_input = GameObject.Find ("SearchWord").GetComponent<InputField> ();
		_input.onValueChanged.AddListener (delegate {
			OnInputFieldTask ();
		});
	}

	void OnInputFieldTask(){
		string word = _input.text;
		List<string> possibileMatches = findSuggestions (word);
		// Debug.Log ("1." + possibileMatches [0]);
		handleUIElements (possibileMatches);
	}

	void OnClickTask()
	{
		string word = _input.text;
		List<string> possibileMatches = findSuggestions (word);
		Debug.Log ("1." + possibileMatches [0]);
		handleUIElements (possibileMatches);
	}

	private void ClearTextFieldOfBUtton(Button button){
		Text tmp = button.GetComponentInChildren<Text>();
		tmp.text = "";
	}

	private void AddTextToFieldOfButton(Button button, string suggestion){
		Text tmp = button.GetComponentInChildren<Text>();
		tmp.text = suggestion;
	}

	private void clearUI(){
		ClearTextFieldOfBUtton (_suggestion1);
		ClearTextFieldOfBUtton (_suggestion2);
		ClearTextFieldOfBUtton (_suggestion3);
		ClearTextFieldOfBUtton (_suggestion4);
		ClearTextFieldOfBUtton (_suggestion5);
		ClearTextFieldOfBUtton (_suggestion6);
	}

	void handleUIElements(List<string> dropDown)
	{
		Debug.Log ("UI");
		clearUI ();

		int count = 0;
		foreach (string tmp in dropDown) {
			++count;
			if (count == 1)
				AddTextToFieldOfButton (_suggestion1, tmp);
			else if (count == 2)
				AddTextToFieldOfButton (_suggestion2, tmp);
			else if (count == 3)
				AddTextToFieldOfButton (_suggestion3, tmp);
			else if (count == 4)
				AddTextToFieldOfButton (_suggestion4, tmp);
			else if (count == 5)
				AddTextToFieldOfButton (_suggestion5, tmp);
			else if (count == 6)
				AddTextToFieldOfButton (_suggestion6, tmp);
			else
				break;
		}
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
			if (currentWord.Substring(0,length < currentWord.Length ? length : currentWord.Length ).Equals(word))
			{
				Debug.Log ("found something");
				possibleMatches.Add(currentWord);
			}
		}
		return possibleMatches;
	}

	void Update(){
	}

}
