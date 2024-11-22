using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class SaveManager : MonoBehaviour {
	public enum DataLabel {
		TEST_STRING,
		MESSAGES
	}

	public static SaveManager instance {get; private set;}

	//Data
	private string testString;
	private string Messages;

	private void Awake() {
		instance = this;
		PlayerPrefs.DeleteAll();
		UpdateData();
	}
	private void UpdateData() {
		testString = PlayerPrefs.GetString(DataLabel.TEST_STRING.ToString(), "");
		Messages = PlayerPrefs.GetString(DataLabel.MESSAGES.ToString(), "");
	}

	public void setString(DataLabel data, string newString) {
		PlayerPrefs.SetString(data.ToString(), newString);
		UpdateData();
	}


	public string getString(DataLabel data) {
		switch (data) {
			default:
			case DataLabel.TEST_STRING:
				return testString;
			case DataLabel.MESSAGES:
				return Messages;
		}
	}
}
