using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BindKeyToButton : MonoBehaviour {

	public KeyCode _keyCode;
	public Button _buttonToBind;
	public InputField _seatchBar;
	public Text _currentKey;
	public Button _addToDictionary;

	void Awake()
	{
		_buttonToBind = GetComponent<Button> ();
		_addToDictionary = GetComponent<Button> ();
	}
	void Start () {
		_buttonToBind.onClick.AddListener(OnClickTask);
		_seatchBar = GameObject.Find ("SearchWord").GetComponent<InputField> ();
	}

	void OnClickTask(){
		Debug.Log ("on click - key");
		string keyValue = getTextFromButton ();
		handleFullFading (keyValue);
		if (isBackSpace (keyValue))
			handleBackSpace ();
		else if (isEnter (keyValue)) {
			handleEnter ();
		} else _seatchBar.text += keyValue;

		string word = _seatchBar.text.ToString ();
		HandleEndOfTheWord (word);
	}

	private string GetLastCharacter(string word){
		int length = word.Length;
		Debug.Log ("length = " + length);
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
		string lastChar = GetLastCharacter (word);
		if (IsSpecialCase (lastChar)) {
			Debug.Log ("should add to dictionary");
			_addToDictionary.onClick.Invoke();
		}
	}

	private bool IsSpecialCase(string special){
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

	private bool isBackSpace(string keyVal){
		Debug.Log ("is backspace");
		return keyVal.Equals ("<----");		
	}

	private bool isEnter(string keyVal){
		Debug.Log ("is enter");
		return keyVal.Equals ("enter");
		//invoke enter
	}

	private void handleBackSpace(){
		Debug.Log ("handle backspace");
		string content = _seatchBar.text.ToString ();
		content = content.Substring (0, content.Length - 1);
		Debug.Log ("content= " + content);
		_seatchBar.text = content;
	}

	private void handleEnter(){
		Debug.Log ("handle enter");
		// _addToDictionary.onClick.Invoke ();
	}

	private string getTextFromButton(){
		Debug.Log ("get text from button");
		Text tmp = _buttonToBind.GetComponentInChildren<Text>();
		string keyVal = tmp.text.ToString ().ToLower ();
		switch (keyVal) {
		case "space":
			keyVal = " ";
			break;
		default:
			break;
		}
		return keyVal;
	}

	void Update () {
		if (Input.GetKeyDown (_keyCode)) { // when pressing
			_buttonToBind.onClick.Invoke ();
		}else if (Input.GetKeyUp(_keyCode)){
			
		}else if (Input.GetKey (_keyCode)) {
			//when holding the key for longer
			StartDrawing();
		}

	}

	void FadeColor()
	{
		Graphic graphic = GetComponent<Graphic> ();
		graphic.CrossFadeColor (Color.black, _buttonToBind.colors.fadeDuration, true, true);
	}
	void StartDrawing()
	{
		// TO DO : implement later
	}

	void handleFullFading(string keyValue){
		Debug.Log ("handle funn fading!");
		keyValue = keyValue == " " ? keyValue = "'  '" : keyValue;
		_currentKey.text = keyValue.ToUpper();
		// WaitForSeconds (1);
	}
}