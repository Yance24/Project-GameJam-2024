using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootProjectile : EnemyAction
{
    public GameObject projectilePrefab;
    public override void execute(){
        base.execute();
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = enemy.transform.position;
        projectile.GetComponent<Rigidbody2D>().rotation = YEuler.countAngle(enemy.transform.position,enemy.player.position);
        finish();
    }
}
