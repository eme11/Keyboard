using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BindKeyToButton : MonoBehaviour {

	public KeyCode _keyCode;
	public Button _buttonToBind;
	public InputField _seatchBar;
	public Button _search;

	void Awake()
	{
		_buttonToBind = GetComponent<Button> ();
	}
	void Start () {
		_buttonToBind.onClick.AddListener(OnClickTask);
		_seatchBar = GameObject.Find ("SearchWord").GetComponent<InputField> ();
	}

	void OnClickTask(){
		Debug.Log ("on click - key");
		string keyValue = getTextFromButton ();
		if (isBackSpace (keyValue))
			handleBackSpace ();
		else if (isEnter (keyValue)) {
			handleEnter ();
		} else _seatchBar.text += keyValue;			
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
		//_search.onClick.Invoke ();
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
		} else if (Input.GetKeyUp (_keyCode)) { // when releasing
			FadeColor ();
		} else if (Input.GetKey (_keyCode)) {
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
		Graphic graphic = GetComponent<Graphic> ();
		graphic.CrossFadeColor (Color.red, _buttonToBind.colors.fadeDuration, true, true);
	}
}