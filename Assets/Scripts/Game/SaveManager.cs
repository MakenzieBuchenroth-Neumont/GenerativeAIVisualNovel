using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class SaveManager : MonoBehaviour {
	public enum DataLabel {
		TEST_STRING
	}

	public static SaveManager instance {get; private set;}

	//Data
	private string testString;

	private void Start() {
		instance = this;
		UpdateData();
	}
	private void UpdateData() {
		testString = PlayerPrefs.GetString(DataLabel.TEST_STRING.ToString(), "");
	}

	private void setString(DataLabel data, string newString) {
		PlayerPrefs.SetString(data.ToString(), newString);
		UpdateData();
	}


	private string getString(DataLabel data) {
		switch (data) {
			default:
			case DataLabel.TEST_STRING:
				return testString;
		}
	}
}
