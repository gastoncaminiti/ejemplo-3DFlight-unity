using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathVfx;
    [SerializeField] private GameObject hitVfx;
    [SerializeField] private int hitScore = 100;
    [SerializeField] private int hitPoints = 300;
    private ScoreBoard scoreBoard;
    private Transform parentGameObject;
    private void Start()
    {
        scoreBoard = GameObject.FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnRuntime").transform;
    }
    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.IncreaseScore(hitScore);
        hitPoints -= hitScore;
        if (hitPoints < 0)
        {
            DestroyEnemy();
        }
        else
        {
            HitEnemy();
        }
    }

    private void HitEnemy()
    {
        GameObject newVfx = Instantiate(hitVfx, transform.position, Quaternion.identity);
        newVfx.transform.parent = parentGameObject;
    }

    private void DestroyEnemy()
    {
        GameObject newVfx = Instantiate(deathVfx, transform.position, Quaternion.identity);
        newVfx.transform.parent = parentGameObject;
        Destroy(gameObject);
    }
}
