using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class ProjectileModifier : MonoBehaviour
{
    public float speed;
    public float damage;
    public bool isHarm;
    public Element element;
    public float maxLifeSpan;
    public bool destroyOnImpact;
    public GameObject afterImpact;
    public float afterImpactLifeSpan;

    private Rigidbody2D rigidbody2d;

    private bool isLaunched = false;

    // public void launch(){
    //     rigidbody2d = GetComponent<Rigidbody2D>();
    //     isLaunched = rigidbody2d;
    // }

    void Start(){
        rigidbody2d = GetComponent<Rigidbody2D>();
        isLaunched = rigidbody2d;
        Destroy(gameObject,maxLifeSpan);
    }

    void FixedUpdate(){
        if(rigidbody2d){
            rigidbody2d.velocity = transform.right * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if((collider.CompareTag("Player") && isHarm) || ((collider.CompareTag("Enemy") || collider.CompareTag("Boss")) && !isHarm)){
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
