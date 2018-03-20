using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {

    public int m_scene;
    AsyncOperation loadScene;

    // Use this for initialization
    void Start () {
        loadScene = SceneManager.LoadSceneAsync(m_scene);
        loadScene.allowSceneActivation = false;
        StartCoroutine(PreLoad());
    }
	
	// Update is called once per frame
	void Update () {
    }

    IEnumerator PreLoad()
    {
        while (loadScene.progress < 0.9f)
        {
            yield return new WaitForSeconds(0.1f);
        }

        loadScene.allowSceneActivation = true;
    }
}