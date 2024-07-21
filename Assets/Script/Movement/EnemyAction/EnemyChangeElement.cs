using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChangeElement : EnemyAction
{
    private HpStats stats;
    public override void execute()
    {
        base.execute();
        stats = enemy.GetComponent<HpStats>();
        switch(stats.elementWeakness){
            case Element.fire:
                stats.elementWeakness = Element.ice;
            break;

            case Element.ice:
                stats.elementWeakness = Element.earth;
            break;

            case Element.earth:
                stats.elementWeakness = Element.fire;
            break;

            default:
                stats.elementWeakness = Element.fire;
            break;
        }
        finish();
    }
}
