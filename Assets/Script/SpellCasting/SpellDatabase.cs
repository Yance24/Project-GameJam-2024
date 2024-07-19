using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpellRecipe{
    public GameObject spells;
    public List<GameObject> connectingSigils;
}

public class SpellDatabase : MonoBehaviour
{
    [SerializeField]
    public List<SpellRecipe> storedSpells;
}
