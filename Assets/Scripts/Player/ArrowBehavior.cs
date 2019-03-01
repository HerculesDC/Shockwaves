using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class ArrowBehavior : MonoBehaviour
{
    [SerializeField] private float m_height;
    [SerializeField] private float m_length;

    [SerializeField] private Transform m_ball;
    [SerializeField] private Transform m_end;

    private LineRenderer m_line = null;
    private readonly uint POINTCOUNT = 2u; //for control

    private Vector3[] m_positions;

    

    void Awake() {

        m_line = this.gameObject.GetComponent<LineRenderer>();

        m_positions = new Vector3[POINTCOUNT];
        
        /* included in case of need
        m_ball = GameObject.Find("Ball").transform;
        m_end = GameObject.Find("Endpoint").transform;
        */
    }
    // Start is called before the first frame update
    void Start()
    {

        /* included in case of need
        if (!m_ball) {
           
            m_ball = GameObject.Find("Ball").transform;
            m_end = GameObject.Find("Endpoint").transform;
        } */
    }

    // Update is called once per frame
    void Update()
    {
        
        if (m_ball) {

            this.gameObject.transform.position = m_ball.position;

            Vector3 target = m_end.position - m_ball.position;
            target.Normalize();
            target = target * m_length;

            m_positions[0] = new Vector3(0, m_ball.transform.position.y + m_height, 0);
            m_positions[1] = new Vector3(m_positions[0].x + target.x, m_positions[0].y, m_positions[0].z + target.z);

            m_line.SetPositions(m_positions);
        }
        
    }
}
