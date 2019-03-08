using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

    private static SoundManager SM_instance;
    public static SoundManager SM_Instance { get { return SM_instance; } }

    [SerializeField] AudioSource m_audioSource;

    [SerializeField] AudioClip[] m_audioClips;

    void Awake() {

        if (!SM_instance) SM_instance = this;
        else if (SM_instance != this) Destroy(this.gameObject);

        m_audioSource = this.gameObject.GetComponent<AudioSource>();
        //m_audioClips = new AudioClip[];
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
