using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set; }

	private void Awake() {
		instance = this;
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
