using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveStarter : MonoBehaviour {

    /* THIS CAN BE CHANGED LATER TO ALLOW FOR CHARGE-UP SHOCKWAVES
     *      ALSO CONSIDER MULTIPLE SHOCKWAVES
     */

    private Camera m_cam = null;

    [SerializeField] private GameObject m_shockwave;
                     private GameObject m_shockInstance = null;

    private Touch m_touch;

    private RaycastHit m_hit;
    private Ray m_ray;

    [SerializeField] private float m_heightCorrection;
                     private Vector3 m_target = Vector3.zero;    
    

    void Awake() {

        m_cam = this.gameObject.GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() { //OBS: May need refining

        if (GameManager.GM_State != GameState.GAME_END) {

            if (GameManager.GM_State != GameState.LEVEL_END) {

                if (Input.touchCount > 0) {

                    m_touch = Input.GetTouch(0);
                    m_ray = m_cam.ScreenPointToRay(m_touch.position);

                    if (m_touch.phase == TouchPhase.Began && !m_shockInstance) StartShockwave(m_touch.position);
                }
                else {

                    m_ray = m_cam.ScreenPointToRay(Input.mousePosition);
                    if (Input.GetMouseButtonDown(0) /*&& !m_shockInstance*/) StartShockwave(Input.mousePosition);
                }
            }
        }
    }

    void StartShockwave(Vector3 input_position) {

        if (Physics.Raycast(m_ray, out m_hit)) {

            if (m_hit.collider.tag == "Ground") {

                m_target = m_hit.point + (Vector3.up * m_heightCorrection); //to prevent shockwaves from launching the ball upwards

                m_shockInstance = GameObject.Instantiate(m_shockwave, m_target, Quaternion.identity) as GameObject;
            }
        }
    }
}
