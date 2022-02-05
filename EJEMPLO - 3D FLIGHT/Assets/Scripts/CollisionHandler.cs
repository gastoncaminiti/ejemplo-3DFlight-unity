using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionVFX;
    private float loadDelay = 1f;


    private void OnTriggerEnter(Collider other)
    {
        CrashBehaviour(other);
    }

    private void CrashBehaviour(Collider other)
    {
        GetComponent<PlayerControls>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        collisionVFX.Play();
        Invoke("ReloadLevel", loadDelay);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
