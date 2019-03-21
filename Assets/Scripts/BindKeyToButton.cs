using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BindKeyToButton : MonoBehaviour {

	public KeyCode _keyCode;
	public Button _buttonToBind; 
	// Use this for initialization
	void Awake()
	{
		_buttonToBind = GetComponent<Button> ();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (_keyCode)) {
			_buttonToBind.onClick.Invoke ();
		} else if (Input.GetKeyUp (_keyCode)) {
			FadeColor ();
		}
			
	}

	void FadeColor()
	{
		Graphic graphic = GetComponent<Graphic> ();
		graphic.CrossFadeColor (Color.black, _buttonToBind.colors.fadeDuration, true, true);
	}
}