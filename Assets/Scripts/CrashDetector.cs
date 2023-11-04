using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float dieAfter = 1;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip clipSFX;
    bool isCrashed = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && !isCrashed)
        {
            isCrashed = true;
            FindAnyObjectByType<PlayerController>().DisableControll();         
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(clipSFX);
            Invoke("ReloadScene", dieAfter);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
