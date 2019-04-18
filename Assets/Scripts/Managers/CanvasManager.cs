﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

    private static CanvasManager CM_instance;
    public static CanvasManager CM_Instance { get { return CM_instance; } }

    private static CanvasState m_innerState;
    public static CanvasState CS_State { get { return m_innerState; } }

    [SerializeField] private GameObject[] canvasObjects; // think of how to optimize this.

    [SerializeField] private float offset;

    private bool m_titleShifted = false;

    private bool m_levelStarted = false;
    private float m_elapsedTime = 0.0f;

    void Awake() {

        if (!CM_instance) CM_instance = this;
        else if (CM_instance != this) Destroy(this.gameObject);

        foreach (GameObject c in canvasObjects) { c.SetActive(false); }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckState(); //THIS CHECK ASSUMES CANVAS GAME OBJECTS IN A CERTAIN ORDER!
    }

    void CheckState() {

        switch (m_innerState) {

            case (CanvasState.START):     DisplayTitle();    break;
            case (CanvasState.SETUP):     DisplaySetup();    break;
            case (CanvasState.LEVEL):     DisplayLevel();    break;
            case (CanvasState.LEVEL_END): DisplayLevelEnd(); break;
            case (CanvasState.END):       DisplayEnd();      break;
            default: break;
        }

    }

    void DisplayTitle() {

        if (!canvasObjects[0].activeInHierarchy) canvasObjects[0].SetActive(true);
    }

    void DisplaySetup() { //removed IF checks, cause I already expect a result

        canvasObjects[0].SetActive(true);

        if (!m_titleShifted) {

            RectTransform temp = canvasObjects[0].GetComponent<Text>().rectTransform;
            temp.position += Vector3.up * offset;

            m_titleShifted = true;
        }

        canvasObjects[1].SetActive(true);
        canvasObjects[2].SetActive(true);

    }

    void DisplayLevel() {

        m_levelStarted = true;

        if (canvasObjects[0].activeInHierarchy)  canvasObjects[0].SetActive(false);
        if (canvasObjects[1].activeInHierarchy)  canvasObjects[1].SetActive(false);
        if (canvasObjects[2].activeInHierarchy)  canvasObjects[2].SetActive(false);
        //FROM LEVEL TO LEVEL, this has to be reset
        if (canvasObjects[5].activeInHierarchy)  canvasObjects[5].SetActive(false);
      
        canvasObjects[4].SetActive(true);

        UpdateTimer();
    }

    void DisplayLevelEnd() {

        m_levelStarted = false;
        canvasObjects[5].SetActive(true);
    }

    void UpdateTimer() {

        Text txt = null;

        if (canvasObjects[4].activeInHierarchy) {

            txt = canvasObjects[4].GetComponent<Text>();
        }

        if (m_levelStarted) {

            m_elapsedTime += Time.deltaTime;
            if (txt) txt.text = "Time: " + m_elapsedTime.ToString("F2");
        }
    }

    void ResetTimer() { m_elapsedTime = 0.0f; }

    void DisplayEnd() {

        if (canvasObjects[4].activeInHierarchy) canvasObjects[4].SetActive(false);
        if (canvasObjects[5].activeInHierarchy) canvasObjects[5].SetActive(false);

        canvasObjects[6].SetActive(true);
    }

    //what's the use of static in this case? Is it adequate???
    public bool RequestCanvasChange(CanvasState targetState) {

        if (targetState < CanvasState.CANVAS_COUNT) {

            if (m_innerState == CanvasState.LEVEL_END && targetState == CanvasState.LEVEL) {

                ResetTimer();
            }
            m_innerState = targetState;
        }
        return m_innerState == targetState;
    }
}
