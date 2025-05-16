using System;
using TMPro;
using UnityEngine;

public class chatTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TextMeshPro;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChatGPTManager.instance.OnResponseEvent += newResponse;
    }

	private void newResponse(object sender, ChatGPTManager.onResponseEventArgs e) {
        m_TextMeshPro.text = e.response;
	}




	// Update is called once per frame
	void Update()
    {
        
    }
}
