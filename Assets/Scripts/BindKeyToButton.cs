using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BindKeyToButton : MonoBehaviour {

	public KeyCode _keyCode;
	public Button _buttonToBind;
	public InputField _seatchBar;
	public Text _currentKey;
	public Dictionary _dictionary;

	void Awake()
	{
		_buttonToBind = GetComponent<Button> ();
		_dictionary = GameObject.Find ("AddToDictionary").GetComponent<Dictionary> ();
	}
	void Start () {
		_buttonToBind.onClick.AddListener(OnClickTask);
		_seatchBar = GameObject.Find ("SearchWord").GetComponent<InputField> ();
	}

	void OnClickTask(){
		Debug.Log ("1");
		string keyValue = GetTextFromButton ();

		HandleShowingCurrentKey (keyValue);

		if (IsBackSpace (keyValue))
			HandleBackSpace ();
		else if (IsEnter (keyValue)) {
			HandleEnter ();
		} else _seatchBar.text += keyValue;
		Debug.Log ("6");

		string word = _seatchBar.text.ToString ();
		HandleEndOfTheWord (word);
	}

	private string GetLastCharacter(string word){
		Debug.Log ("7.1");
		int length = word.Length;
		string lastChar = "";
		switch (length) {
		case 0:
			Debug.Log ("is end of the word: empty");
			break;
		case 1:
			Debug.Log ("is end of the word: only on char");
			lastChar = word;
			break;
		default:
			Debug.Log ("More than one char");
			int tmp = length - 1;
			lastChar = word.Substring (tmp);
			break;
		}

		return lastChar;
	}

	private void HandleEndOfTheWord(string word){
		Debug.Log ("7.2");
		string lastChar = GetLastCharacter (word);
		if (IsSpecialCase (lastChar)) {
			AddToDictionary ();
		}
	}

	private bool IsSpecialCase(string special){
		Debug.Log ("7.2");
		if (special == "-")
			return true;
		else if (special == "*")
			return true;
		else if (special == "!")
			return true;
		else if (special == ":")
			return true;
		else if (special == ";")
			return true;
		else if (special == ",")
			return true;
		else if (special == ".")
			return true;
		else if (special == "?")
			return true;
		else if (special == " ")
			return true;
		else
			return false;
	}

	private bool IsBackSpace(string keyVal){
		Debug.Log ("4");
		return keyVal.Equals ("<----");		
	}

	private bool IsEnter(string keyVal){
		Debug.Log ("5");
		return keyVal.Equals ("enter");
	}

	private bool IsSpace(string keyVal){
		Debug.Log ("2.1");
		return keyVal.Equals ("space");
	}

	private void HandleBackSpace(){
		Debug.Log ("4.1");
		string content = _seatchBar.text.ToString ();
		content = content.Substring (0, content.Length - 1);
		_seatchBar.text = content;
	}

	private void HandleEnter(){
		Debug.Log ("5.1");
		AddToDictionary ();
	}

	private string GetTextFromButton(){
		Debug.Log ("2");
		Text tmp = _buttonToBind.GetComponentInChildren<Text>();
		string keyVal = tmp.text.ToString ().ToLower ();

		if (IsSpace (keyVal)) {
			keyVal = " ";
		}
		return keyVal;
	}

	void Update () {
		if (Input.GetKeyDown (_keyCode)) { // when pressing
			_buttonToBind.onClick.Invoke ();
		}
	}

	void StartDrawing()
	{
		// TO DO : implement later
	}

	void HandleShowingCurrentKey(string keyValue){
		Debug.Log ("3");
		string tmp = _keyCode.ToString()== "Return" ? "Enter" : _keyCode.ToString();
		_currentKey.text = tmp;
	}

	void AddToDictionary(){
		string word = _seatchBar.text.ToString ();
		_dictionary.AddToDictionary (word);
		_seatchBar.text = "";
	}

}