using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private static UIManager UI_instance = null;
    public static UIManager UI_Instance { get { return UI_instance; } }

    [SerializeField] private SceneHandler scInstance;
    private Scenes currentScene = Scenes.SCENE_COUNT;

    [SerializeField] private Canvas m_canvas;

    void Awake(){

        if (!UI_instance) UI_instance = this;
        else if (UI_instance != this) Destroy(this.gameObject);

        currentScene = scInstance.SceneTracker;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Ultimately, this will simply request Canvas changes inside the UI
        currentScene = scInstance.SceneTracker;

        //REVISE!!!
        /*
        if (currentScene == Scenes.SCENE_COUNT) {

            if (!m_textElement) m_textElement.SetActive(true);
        }
        */
	}

    //has to be transfered to the Canvas manager
    public void ActivateEnd() {

        //if (!m_textElement.activeInHierarchy) m_textElement.SetActive(true);
    }
}
