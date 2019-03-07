using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {

    private static CanvasManager CM_instance;
    public static CanvasManager CM_Instance { get { return CM_instance; } }

    private static CanvasStates innerState;
    public static CanvasStates CS_State { get { return innerState; } }

    [SerializeField] private GameObject[] canvasObjects; // think of how to optimize this.

    void Awake() {

        if (CM_instance)
            CM_instance = this;
        else if (CM_instance != this)
            Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //what's the use of static in this case? Is it adequate???
    public static bool RequestChangeState(CanvasStates targetState) {

        if (targetState < CanvasStates.CANVAS_COUNT) innerState = targetState;

        return innerState == targetState;
    }
}
