using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class ProjectileModifier : MonoBehaviour
{
    public float speed;
    public float damage;
    public bool isHarm;
    public float maxLifeSpan;
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
        rigidbody2d.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collider){
        if((collider.CompareTag("Player") && isHarm) || (collider.CompareTag("Enemy") && !isHarm)){
            collider.GetComponent<HpStats>().hp -= damage;
            GameObject afterI = Instantiate(afterImpact);
            afterI.transform.position = transform.position;
            Destroy(afterI,afterImpactLifeSpan);
            Destroy(gameObject);
        }
    }
}
