using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteDictionaryButton : MonoBehaviour {

	public Button _delete;
	public Dictionary _dictionary;
	// Use this for initialization
	void Start () {
		_delete = GetComponent<Button> ();
		_dictionary = GameObject.Find ("AddToDictionary").GetComponent<Dictionary> ();

		_delete.onClick.AddListener(OnClickTask);
	}

	void OnClickTask(){
		_dictionary.DeleteAll ();
	}
	

}
