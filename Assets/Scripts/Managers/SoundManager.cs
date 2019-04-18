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
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        switch (GameManager.GM_State) { //Tied to GameState because it makes sense

            case GameState.LEVEL_1:
                m_audioSource.clip = m_audioClips[0];
                if (!m_audioSource.isPlaying)m_audioSource.Play();
                break;
            case GameState.LEVEL_2:
                m_audioSource.clip = m_audioClips[1];
                if (!m_audioSource.isPlaying) m_audioSource.Play();
                break;
            case GameState.LEVEL_3:
                m_audioSource.clip = m_audioClips[2];
                if (!m_audioSource.isPlaying) m_audioSource.Play();
                break;
            default: m_audioSource.Stop(); break;
        }

	}
}
