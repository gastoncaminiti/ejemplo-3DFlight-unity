using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathVfx;
    [SerializeField] private Transform parent;
    [SerializeField] private int hitScore  = 100;
    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.IncreaseScore(hitScore);
        DestroyEnemy();
    }

    private void DestroyEnemy()
    {
        GameObject newVfx = Instantiate(deathVfx, transform.position, Quaternion.identity);
        newVfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
