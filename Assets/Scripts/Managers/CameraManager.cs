using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    private static CameraManager CM_instance = null;
    public static CameraManager CM_Instance { get { return CM_instance; } }

    [SerializeField] Vector3 offsets = Vector3.zero;

    private Camera cam;

    private GameObject go_tracker = null;

    private Transform target = null;

    [SerializeField] private GameManager gmInstance = null;
    [SerializeField] private SceneHandler sceneInstance = null;
    [SerializeField] private Scenes sceneTracker = Scenes.SCENE_COUNT;

    void Awake() {

        if (CM_instance == null) CM_instance = this;
        else if (CM_instance != this) CM_instance = this;

        cam = this.gameObject.GetComponent<Camera>();

        DontDestroyOnLoad(this.gameObject);

        gmInstance = GameManager.GM_instance;
        sceneInstance = SceneHandler.SC_Instance;

        go_tracker = GameObject.Find("Ball");
            target = go_tracker.GetComponent<Transform>();

        if (sceneInstance) sceneTracker = sceneInstance.SceneTracker;

        go_tracker = null;
    }

    // Use this for initialization
    void Start () {

        if (!gmInstance) gmInstance = GameManager.GM_instance;

        if (!sceneInstance) sceneInstance = SceneHandler.SC_Instance;
        else sceneTracker = sceneInstance.SceneTracker;

        TrackScene();
        ChangePerspective();
    }
	
	// Update is called once per frame
	void Update () {

        if (!go_tracker) go_tracker = GameObject.Find("Ball");
        else if (go_tracker && !target) target = go_tracker.GetComponent<Transform>();
        else if (go_tracker && target) {

            Reposition();
            this.gameObject.transform.LookAt(target);
        }

        TrackScene();
        ChangePerspective();
    }

    void TrackScene() {

        /*
        if (sceneTracker != sceneInstance.SceneTracker) {

            go_tracker = GameObject.Find("Ball");
                if (go_tracker) target = go_tracker.GetComponent<Transform>();
        }*/
    }

    void ChangePerspective() {
        
        if (!target)
            cam.orthographic = true;
        else 
            cam.orthographic = false;
    }

    void Reposition() {

        if (target) {
            this.gameObject.transform.position = target.position + offsets;
        }
    }
}
