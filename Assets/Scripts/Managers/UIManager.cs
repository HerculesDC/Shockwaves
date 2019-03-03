using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//THIS UIMANAGER IS ATTACHED TO THE CANVAS!!! WILL REQUIRE REWORKING
public class UIManager : MonoBehaviour {

    private static UIManager UI_instance = null;
    public static UIManager UI_Instance { get { return UI_instance; } }

    //private GameManager gmInstance = null;
    private SceneHandler scInstance = null;
    private Scenes currentScene = Scenes.SCENE_COUNT;

    private Canvas m_canvas;
    [SerializeField] private GameObject m_sliderElement;
    [SerializeField] private Slider m_slider;

    [SerializeField] private GameObject m_textElement;
    [SerializeField] private Text m_text;

    void Awake(){

        if (!UI_instance) UI_instance = this;

        //gmInstance = GameManager.GM_instance;
        scInstance = SceneHandler.SC_Instance;

        currentScene = scInstance.SceneTracker;

        m_slider = m_sliderElement.GetComponent<Slider>();

        m_text = m_textElement.GetComponent<Text>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        currentScene = scInstance.SceneTracker;

        if (m_sliderElement) m_slider.value = TestAreaManager.BallDistance;

        if (currentScene == Scenes.END) {

            if (m_sliderElement) m_sliderElement.SetActive(false);
            if (!m_textElement) m_textElement.SetActive(true);
        }
	}

    public void ActivateEnd() {

        if (m_sliderElement.activeInHierarchy) m_sliderElement.SetActive(false);
        if (!m_textElement.activeInHierarchy) m_textElement.SetActive(true);
    }
}
