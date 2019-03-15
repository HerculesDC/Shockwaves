using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class ArrowBehavior : MonoBehaviour
{
    //Arrow's "intrinsic" variables
    private LineRenderer m_line = null;         //this line
    private Vector2 m_target;                   //line's control vector
    private readonly uint POINTCOUNT = 2u;      //number of control points
    private Vector3[] m_positions;              //control points
    [SerializeField] private float m_height;    //height from the ball
    private readonly float m_maxLength = 1.5f;  //maximum length of the line
    private float m_width = 1.0f;               //intended as line's starting width

    private GameObject m_ball;                  //the object the arrow's gonna accompany
    private SphereBehavior m_sphere;            //this is needed to get the distance to the endpoint

    private Transform m_end;                    //the level's endpoint
    

    void Awake() {

        m_ball = GameObject.Find("Ball");
            m_sphere = m_ball.GetComponent<SphereBehavior>();

        m_end = GameObject.Find("Endpoint").transform;
            m_target = Vector3.zero;

        m_line = this.gameObject.GetComponent<LineRenderer>();

        m_positions = new Vector3[POINTCOUNT];
    }

    // Start is called before the first frame update
    void Start() {

        if (!m_ball) {
            m_ball = GameObject.Find("Ball");
            m_sphere = m_ball.GetComponent<SphereBehavior>();
        }

        if (!m_end) m_end = GameObject.Find("Endpoint").transform; 
    }

    // Update is called once per frame
    void Update() {
        
        if (m_ball) {

            this.gameObject.transform.position = m_ball.transform.position;

            Realign();
            Widen();
            Reposition();
        }
    }

    void Realign() {

        m_target.x = m_end.position.x - m_ball.transform.position.x;
        m_target.y = m_end.position.z - m_ball.transform.position.z;
        m_target.Normalize();
        m_target = m_target * m_maxLength * (0.5f + m_sphere.GetDistance());
    }

    void Widen() {

        m_width = m_sphere.GetDistance();
            m_line.startWidth = Mathf.Clamp(m_width, 0.5f, 1.0f);
    }

    void Reposition() {

        //these Vectors 3 are defined in terms of gameObject space. Do not forget that.
        m_positions[0] = new Vector3(0, m_ball.transform.position.y + m_height, 0);
        m_positions[1] = new Vector3(m_positions[0].x + m_target.x, m_positions[0].y, m_positions[0].z + m_target.y);

        m_line.SetPositions(m_positions);
    }
}
