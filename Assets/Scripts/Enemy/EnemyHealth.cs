using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    [SerializeField] int curHP = 0;

    Enemy enemy;
    // Start is called before the first frame update
    void OnEnable()
    {
        curHP = maxHP;
    }
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        curHP--;

        if(curHP <= 0)
        {
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
}
