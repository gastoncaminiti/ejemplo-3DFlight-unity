using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathVfx;
    [SerializeField] private GameObject hitVfx;
    [SerializeField] private Transform parent;
    [SerializeField] private int hitScore = 100;
    [SerializeField] private int hitPoints = 300;
    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.IncreaseScore(hitScore);
        hitPoints -= hitScore;
        if (hitPoints < 0)
        {
            DestroyEnemy();
        }else
        {
            GameObject newVfx = Instantiate(hitVfx, transform.position, Quaternion.identity);
            newVfx.transform.parent = parent;
        }
    }

    private void DestroyEnemy()
    {
        GameObject newVfx = Instantiate(deathVfx, transform.position, Quaternion.identity);
        newVfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
