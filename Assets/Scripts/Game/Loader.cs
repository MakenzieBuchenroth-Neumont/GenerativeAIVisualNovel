
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
	private static scenes TargetScene;

	public enum scenes {
		loadingScreen,
		General
	}

	public static void Load(scenes targetScene) {
		Loader.TargetScene = targetScene;
		SceneManager.LoadScene(scenes.loadingScreen.ToString());
	}

	public static void LoaderCallback() {
		SceneManager.LoadScene(Loader.TargetScene.ToString());
	}
}
