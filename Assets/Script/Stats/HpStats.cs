using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpStats : MonoBehaviour
{
    public float hp;

    public string Hp{
        get{return ""+Mathf.Floor(hp);}
    }
}
