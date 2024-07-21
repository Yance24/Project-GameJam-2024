using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticProjectileModifier : MonoBehaviour
{
    public float damage;
    public bool isHarm;
    public Element element;
    public float maxLifeSpan;
    public bool destroyOnImpact;
    public GameObject afterImpact;
    public float afterImpactLifeSpan;


    private bool isLaunched = false;

    // public void launch(){
    //     rigidbody2d = GetComponent<Rigidbody2D>();
    //     isLaunched = rigidbody2d;
    // }

    void Start(){
        transform.position = MouseUtil.mousePositionToWorld();
        Destroy(gameObject,maxLifeSpan);
    }

    void OnTriggerEnter2D(Collider2D collider){
        if((collider.CompareTag("Player") && isHarm) || (collider.CompareTag("Enemy") && !isHarm)){
            HpStats hpStats = collider.GetComponent<HpStats>();
            // Debug.Log("check Damage");
            if(hpStats.elementWeakness == element){
                // Debug.Log("Take Damage");
                hpStats.CurrentHp -= damage;
            }
            if(afterImpact){
                GameObject afterI = Instantiate(afterImpact);
                afterI.transform.position = transform.position;
                Destroy(afterI,afterImpactLifeSpan);
            }
            if(destroyOnImpact) Destroy(gameObject);
        }else if(collider.CompareTag("Wall")){
            if(afterImpact){
                GameObject afterI = Instantiate(afterImpact);
                afterI.transform.position = transform.position;
                Destroy(afterI,afterImpactLifeSpan);
            }
            if(destroyOnImpact) Destroy(gameObject);
        }

        
    }
}
