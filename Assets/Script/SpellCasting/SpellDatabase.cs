using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpellRecipe{
    public GameObject spells;
    public List<SigilHandler> connectingSigilsID;
    public Material sigilEffect;
}

public class SpellDatabase : MonoBehaviour
{
    public static SpellDatabase instance{private set; get;}
    [SerializeField]
    public List<SpellRecipe> storedSpells;

    void Start(){
        if(!instance) instance = this;
        else Destroy(this);
    }
}
