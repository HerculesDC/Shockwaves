using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {

    private static CanvasManager CM_instance;
    public static CanvasManager CM_Instance { get { return CM_instance; } }

    private static CanvasStates m_innerState;
    public static CanvasStates CS_State { get { return m_innerState; } }

    [SerializeField] private GameObject[] canvasObjects; // think of how to optimize this.

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

            case (CanvasStates.START): DisplayTitle(); break;
            case (CanvasStates.SETUP): DisplaySetup(); break;
            default: break;
        }

    }

    void DisplayTitle() {

        if (!canvasObjects[0].activeInHierarchy) canvasObjects[0].SetActive(true);
    }

    void DisplaySetup() {

        if (!canvasObjects[0].activeInHierarchy) canvasObjects[0].SetActive(true);
        else {
            Vector3 titlePosition = canvasObjects[0].transform.position;
            //if this runs endlessly, will make the title climb indefinitely...
        }

    }

    //what's the use of static in this case? Is it adequate???
    public static bool RequestChangeState(CanvasStates targetState) {

        if (targetState < CanvasStates.CANVAS_COUNT) m_innerState = targetState;

        return m_innerState == targetState;
    }
}
