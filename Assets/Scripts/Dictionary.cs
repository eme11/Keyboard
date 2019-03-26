using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dictionary : MonoBehaviour {

	private List<string> _content;
	public InputField _input;
	public Button _addNewWord;
	public Button _suggestion1;
	public Button _suggestion2;
	public Button _suggestion3;
	public Button _suggestion4;
	public Button _suggestion5;
	public Button _suggestion6;

	// Use this for initialization
	void Start () {
		_content = new List<string> ();
		Load ();

		_addNewWord = GetComponent<Button> ();
		_addNewWord.onClick.AddListener(OnClickTask);

		_input = GameObject.Find ("SearchWord").GetComponent<InputField> ();
		_input.onValueChanged.AddListener (delegate {
			OnInputFieldTask ();
		});
	}

	void OnInputFieldTask(){
		string word = _input.text;
		List<string> possibileMatches = FindSuggestions (word);
		handleUIElements (possibileMatches);
	}

	void OnClickTask()
	{
		// TO DO : make button add
		string word = _input.text.ToString() ;
		AddToDictionary (word);
		_input.text = "";
	}

	private void ClearTextFieldOfBUtton(Button button){
		Text tmp = button.GetComponentInChildren<Text>();
		tmp.text = "";
	}

	private void AddTextToFieldOfButton(Button button, string suggestion){
		Text tmp = button.GetComponentInChildren<Text>();
		tmp.text = suggestion;
	}

	private void ClearUI(){
		ClearTextFieldOfBUtton (_suggestion1);
		ClearTextFieldOfBUtton (_suggestion2);
		ClearTextFieldOfBUtton (_suggestion3);
		ClearTextFieldOfBUtton (_suggestion4);
		ClearTextFieldOfBUtton (_suggestion5);
		ClearTextFieldOfBUtton (_suggestion6);
	}

	void handleUIElements(List<string> dropDown)
	{
		ClearUI ();

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
		

	public List<string> FindSuggestions(string word)
	{
		if (word == null) {
			return null;
		}
		List<string> possibleMatches = new List<string> ();
		int length = word.Length;
		foreach (string currentWord in _content) {
			if (currentWord.Substring(0,length < currentWord.Length ? length : currentWord.Length ).Equals(word))
			{
				possibleMatches.Add(currentWord);
			}
		}
		return possibleMatches;
	}

	public void AddToDictionary(string word){
		Debug.Log ("5.2");

		int counter = PlayerPrefs.GetInt ("size", 0);
		++counter;

		_content.Add (word);

		PlayerPrefs.SetString ("dictionary" + counter, word);
		PlayerPrefs.SetInt ("size", counter);

		PlayerPrefs.Save ();
	}

	public void Load(){
		int counter = PlayerPrefs.GetInt ("size", 0);

		for (int i = 0; i <= counter; ++i) {
			Debug.Log ("1.Loading data= " + i);

			string word = PlayerPrefs.GetString ("dictionary" + i);
			Debug.Log ("2. The Value= " + word);
			_content.Add (word);
		}
	}

	public void DeleteAll(){
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.Save ();
		_content.Clear ();
		ClearUI ();

	}

}
