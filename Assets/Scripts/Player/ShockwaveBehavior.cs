using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveBehavior : MonoBehaviour {

    [SerializeField] private ShockWaveTypes m_type;

    [SerializeField] private float m_maxForce;
    
    [SerializeField] private float m_expansion;
    [SerializeField] private float m_expansionToFade;

    [SerializeField] private float m_maxDist; //seralized for visualization
    [SerializeField] private float m_forceFactor; //serialized for visualization

    //Reminder: Materials can only be retrieved through the renderer.
    private Material m_material;
        private Color m_color = Color.black;
        private float m_alpha = 1.0f;

    [SerializeField] private GameObject target;
                     private Rigidbody target_rb = null;

    private Vector3 distance;
    private bool hit;

    void Awake() {

        m_type = ShockWaveTypes.STANDARD;

        this.gameObject.transform.localScale = Vector3.zero;

        m_material = this.gameObject.GetComponent<Renderer>().material;
            m_color = m_material.color;
            m_alpha = m_color.a;

        switch (GameManager.GM_State) {

            case (GameState.LEVEL_1): target = GameObject.Find("Ball_Wood"); break;
            case (GameState.LEVEL_2): target = GameObject.Find("Ball_Metal"); break;
            case (GameState.LEVEL_3): target = GameObject.Find("Ball_Ice"); break;
            default: target = null; break;
        }
        if (!target) Debug.Log("Something's up. Retrying at Start()...");

        m_maxDist = (m_expansion + m_expansionToFade) / m_expansion;

        distance = Vector3.zero;
        hit = false;
    }

    // Start is called before the first frame update
    void Start() {

        if (!target) {

            switch (GameManager.GM_State) {

                case (GameState.LEVEL_1): target = GameObject.Find("Ball_Wood"); break;
                case (GameState.LEVEL_2): target = GameObject.Find("Ball_Metal"); break;
                case (GameState.LEVEL_3): target = GameObject.Find("Ball_Ice"); break;
                default: target = null; break;
            }
            //Verifying that we may have something wrong...
            if (!target) Debug.Log("Something's not quite right...");
        }
    }

    // Update is called once per frame
    void FixedUpdate() {

        
        if (m_color.a <= 0) Destroy(this.gameObject);
        if (m_forceFactor < 0) m_forceFactor = 0;

        Expand();
        Detect();
        Fade();
    }

    void Expand() {

        this.gameObject.transform.localScale += Vector3.one * m_expansion;

        //USING AN AXIS AS A MEASURE, ADMITTING SPHERICAL EXPANSION
        if (m_forceFactor >= 0) m_forceFactor = (m_maxDist - this.gameObject.transform.localScale.x) / m_maxDist;
    }

    void Fade() {

        m_alpha -= m_expansion * m_expansionToFade;
            m_color.a = m_alpha;
            m_material.color = m_color;
    }

    void Detect() {

        if (target) {

            distance = target.transform.position - this.gameObject.transform.position;
            target_rb = target.GetComponent<Rigidbody>();

            //IMPORTANT: USING X AXIS TO REPRESENT RADIUS, ASSUMING A SPHERICAL SHOCKWAVE!!!
            //IT ALSO "DIGS INTO" THE BALL BEFORE PUSHING IT...
            if ((distance.sqrMagnitude <= (this.transform.localScale.x)) && !hit ) hit = Hit();
        }
    }

    bool Hit() {

        Vector3 direction = distance;
            direction.Normalize();

        target_rb.AddForce(direction * m_maxForce * m_forceFactor);

        return true;
    }
}