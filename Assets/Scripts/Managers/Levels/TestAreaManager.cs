using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAreaManager : MonoBehaviour { 

    [SerializeField] private GameObject m_sphere;
                     private SphereBehavior m_sBehaviour;
                     private Rigidbody m_sRB;

    [SerializeField] private EndpointBehavior m_endpoint;

    private static float ballDistance = 0.0f;

    public static float BallDistance { get { return ballDistance; } }

    void Awake() {

        m_sBehaviour = m_sphere.GetComponent<SphereBehavior>();
        m_sRB =  m_sphere.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        ballDistance = m_sBehaviour.GetDistance();

        //using square magnitude for efficiency
        if (m_sRB.velocity.sqrMagnitude == 0) CheckEnd();
    }

    public bool CheckEnd() {

        return m_endpoint.Reached;
    }
}
