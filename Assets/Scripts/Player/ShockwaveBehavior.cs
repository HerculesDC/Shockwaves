using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveBehavior : MonoBehaviour
{
    private ShockWaveTypes m_type;

    [SerializeField] private float m_maxForce;
    [SerializeField] private float m_maxDist;
    [SerializeField] private float m_expansion;

    //Reminder: Materials can only be retrieved through the renderer.
    private Material m_material;
        private Color m_color = Color.black;
        private float m_alpha = 0.0f;

    [SerializeField] private GameObject target;
                     private Rigidbody target_rb = null;

    [SerializeField] private float m_forceFactor; //serialized for visualization

    Ray ray;

    void Awake() {

        //GameObject.Destroy(this.gameObject);

        m_type = ShockWaveTypes.STANDARD;

        m_material = this.gameObject.GetComponent<Renderer>().material;
            m_color = m_material.color;
            m_alpha = m_color.a;
    }

    // Start is called before the first frame update
    void Start()
    {
       
        RaycastHit hit;

        if (target) {

            target_rb = target.GetComponent<Rigidbody>();

            ray.direction = target.transform.position - this.gameObject.transform.position;
            ray.origin = this.gameObject.transform.position;
            
            if (Physics.Raycast(ray, out hit, m_maxDist)) {

                m_forceFactor = hit.distance / m_maxDist;

                ray.direction.Normalize();
                //Debug.Log(hit.distance/ m_expansion);
                //StartCoroutine(StrikeBall(hit.distance));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localScale *= 1 + m_expansion;
        /*
        if (m_color.a <= 0) Destroy(this.gameObject);

        m_alpha -= m_expansion;
            m_color.a = m_alpha;
            m_material.color = m_color;
         */
    }

    IEnumerator StrikeBall(float distance) {

        yield return new WaitForSeconds(distance/m_expansion);
        target_rb.AddForce((ray.direction - this.gameObject.transform.position) * m_maxForce * distance / m_maxDist);
    }
}
