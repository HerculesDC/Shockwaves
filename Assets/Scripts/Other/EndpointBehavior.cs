using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndpointBehavior : MonoBehaviour
{

    private bool m_reached;
    public bool Reached { get { return m_reached; } }

    // Start is called before the first frame update
    void Start()
    {
        m_reached = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.name == "Ball") m_reached = true;
    }

    void OnCollisionExit(Collision collision) {

        if (collision.gameObject.name == "Ball") m_reached = false;
    }
}
