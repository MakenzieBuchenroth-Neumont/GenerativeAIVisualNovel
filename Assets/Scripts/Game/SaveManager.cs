using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class SaveManager : MonoBehaviour {

	public enum DataLabel {
		TEST_STRING,
		MESSAGES,
		MESSAGES1,
		MESSAGES2,
		MESSAGES3
	}

	public static SaveManager instance {get; private set;}

	//Data
	private string testString;
	private string Messages;

	private void Awake() {
		instance = this;
		DontDestroyOnLoad(instance);
	}
	private void UpdateData() {
		testString = PlayerPrefs.GetString(DataLabel.TEST_STRING.ToString(), "");
		Messages = PlayerPrefs.GetString(DataLabel.MESSAGES.ToString(), "");
	}

	public void setString(DataLabel data, string newString) {
		PlayerPrefs.SetString(data.ToString(), newString);
		PlayerPrefs.Save();
	}

	public void loadSave(int save) {
		switch (save) {
			case 1:
				Messages = PlayerPrefs.GetString(DataLabel.MESSAGES1.ToString(), "");
				break;
			case 2:
				Messages = PlayerPrefs.GetString(DataLabel.MESSAGES2.ToString(), "");
				break;
			case 3:
				Messages = PlayerPrefs.GetString(DataLabel.MESSAGES3.ToString(), "");
				break;
			case 4:
				Messages = "";
				break;
		}

		Loader.Load(Loader.scenes.General);
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
