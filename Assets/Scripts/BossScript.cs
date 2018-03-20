using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour {

    //AsyncOperation loadScene;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(3);
            /*loadScene = SceneManager.LoadSceneAsync(4);
            loadScene.allowSceneActivation = false;
            StartCoroutine(PreLoad());*/
        }
    }
/*
    IEnumerator PreLoad()
    {
        while (loadScene.progress < 0.9f)
        {
            yield return new WaitForSeconds(0.1f);
        }

        loadScene.allowSceneActivation = true;
    }*/
}
