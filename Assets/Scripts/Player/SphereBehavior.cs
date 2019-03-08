using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class SphereBehavior : MonoBehaviour
{

    [SerializeField] private Transform m_start;
    [SerializeField] private Transform m_end;
    
    /*Obs: These distances will be calculated as square magnitudes.
     *        => It's faster, and the division remains consistent.
     */
    private float m_totalDist = 0.0f;
    private float m_dist = 0.0f;
    [SerializeField] private float monitor;

    void Awake() {

        m_totalDist = (m_start.position - m_end.position).sqrMagnitude;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

        UpdateDistance();
        monitor = m_dist / m_totalDist;
    }

    void UpdateDistance() { m_dist = (this.gameObject.transform.position - m_end.position).sqrMagnitude; }

    public float GetDistance() {
        
        return Mathf.Clamp01(m_dist/m_totalDist);
    }
}
