using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//WILL HAVE TO CREATE A BASE CLASS LATER, WITH THIS CODE

public class TestAreaManager : MonoBehaviour {

    private UIManager m_UI;

    [SerializeField] private GameObject m_sphere;
                     private SphereBehavior m_sBehaviour;
                     private Rigidbody m_sRB;

    [SerializeField] private float m_threshold;

    [SerializeField] private EndpointBehavior m_endpoint;

    private static float ballDistance = 0.0f;
    public static float BallDistance { get { return ballDistance; } }

    void Awake() {

        m_UI = UIManager.UI_Instance;

        m_sBehaviour = m_sphere.GetComponent<SphereBehavior>();
        m_sRB =  m_sphere.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start() {

        if (!m_UI) m_UI = UIManager.UI_Instance;
    }

    // Update is called once per frame
    void Update() {

        ballDistance = m_sBehaviour.GetDistance();

        if (m_sRB.velocity.sqrMagnitude <= m_threshold) { //using square magnitude for efficiency

            if (CheckEnd()) {

                if (m_UI) m_UI.ActivateEnd();
            }   
        }
    }

    public bool CheckEnd() {

        return m_endpoint.Reached;
    }
}
