using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private GameManager gmInstance = null;

    private Canvas m_canvas;
    [SerializeField] GameObject m_sliderElement;
    [SerializeField] private Slider m_slider;

    void Awake(){
        gmInstance = GameManager.GM_instance;
        m_slider = m_sliderElement.GetComponent<Slider>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        m_slider.value = TestAreaManager.BallDistance;
	}
}
