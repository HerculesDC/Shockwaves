﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    private static CameraManager CM_instance = null;
    public static CameraManager CM_Instance { get { return CM_instance; } }

    [SerializeField] Vector3 offsets = Vector3.zero;

    [SerializeField] private Camera cam;

    [SerializeField] private GameObject go_tracker = null;

    [SerializeField] private Transform target = null;

    [SerializeField] private GameManager gmInstance;
    [SerializeField] private SceneHandler sceneInstance;
    [SerializeField] private UIManager uiInstance;
    [SerializeField] private Scenes sceneTracker = Scenes.SCENE_COUNT;

    void Awake() {

        if (CM_instance == null) CM_instance = this;
        else if (CM_instance != this) Destroy(this.gameObject);

        cam = this.gameObject.GetComponent<Camera>();

        DontDestroyOnLoad(this.gameObject);

        GameObject temp = GameObject.Find("Game_Manager");
            gmInstance = temp.GetComponent<GameManager>();
            sceneInstance = temp.GetComponentInChildren<SceneHandler>();
            uiInstance = temp.GetComponentInChildren<UIManager>();
        temp = null;

        go_tracker = GameObject.FindGameObjectWithTag("Ball");
            if (go_tracker) target = go_tracker.GetComponent<Transform>();

        if (sceneInstance) sceneTracker = SceneHandler.SceneTracker;

        go_tracker = null;
    }

    // Use this for initialization
    void Start () {

        TrackScene();
        ChangePerspective();
    }
	
	// Update is called once per frame
	void Update () {

        if (!go_tracker) go_tracker = GameObject.FindGameObjectWithTag("Ball");
        if (go_tracker) target = go_tracker.GetComponent<Transform>();
            Reposition();
        
        TrackScene();
        ChangePerspective();
    }

    void Retarget() { }

    void TrackScene() {

        sceneTracker = SceneHandler.SceneTracker;
    }

    void ChangePerspective() {
        
        //if (sceneTracker < Scenes.LEVEL_1 || sceneTracker > Scenes.LEVEL_3)
        if (!go_tracker)
            cam.orthographic = true;
        else 
            cam.orthographic = false;
    }

    void Reposition() {

        if (target) {

            this.gameObject.transform.position = target.position + offsets;
            this.gameObject.transform.LookAt(target);
        }
    }
}
