using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] Transform target;
    [SerializeField] float range = 15f;

    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }
    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDist = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDist = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDist < maxDist)
            {
                closestTarget = enemy.transform;
                maxDist = targetDist;
            }

            target = closestTarget;
        }
    }
    void AimWeapon()
    {
        float targetDist = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if (targetDist < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }

        Debug.Log(targetDist + " " + range);
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
