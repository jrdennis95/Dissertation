using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    public Button m_button1, m_button2;
	// Use this for initialization
	void Start () {
        m_button1.onClick.AddListener(TaskOnClick1);
        m_button2.onClick.AddListener(TaskOnClick2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void TaskOnClick1()
    {
        m_button1.onClick.RemoveAllListeners();
        m_button2.onClick.RemoveAllListeners();
        SceneManager.LoadScene(1);
    }

    private void TaskOnClick2()
    {
        m_button1.onClick.RemoveAllListeners();
        m_button2.onClick.RemoveAllListeners();
        SceneManager.LoadScene(0);
    }
}
