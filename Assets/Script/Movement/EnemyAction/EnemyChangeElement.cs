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
                stats.changeElement(Element.ice);
            break;

            case Element.ice:
                stats.changeElement(Element.earth);
            break;

            case Element.earth:
                stats.changeElement(Element.fire);
            break;

            default:
                stats.changeElement(Element.fire);
            break;
        }
        finish();
    }
}
