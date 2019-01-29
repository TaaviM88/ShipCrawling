using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class FootStepScript : MonoBehaviour
{
    public float stepRate = 0.5f;
    public float stepCoolDown;
    //public AudioClip footStep;
    [SerializeField] private AudioClip[] m_FootstepSounds;
    private AudioSource m_AudioSource;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        stepCoolDown -= Time.deltaTime;
        if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f)
        {
            //audio.pitch = 1f + Random.Range(-0.2f, 0.2f);
            //audio.PlayOneShot(footStep, 0.9f);
            stepCoolDown = stepRate;
            PlayFootStepAudio();
        }
    }

    private void PlayFootStepAudio()
    {
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        int n = Random.Range(1, m_FootstepSounds.Length);
        m_AudioSource.clip = m_FootstepSounds[n];
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;
    }
}