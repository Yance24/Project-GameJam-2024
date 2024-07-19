using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpellCastingManager : MonoBehaviour
{
    public static SpellCastingManager instance{private set; get;}

    public List<GameObject> sigilsObjects;
    public List<RectTransform> sigilPositions;
    public RectTransform sigilSpawn;

    private List<GameObject> spawnedSigils = new List<GameObject>();
    private List<GameObject> connectedSigils = new List<GameObject>();


    bool sigilSpawned = false;
    public bool sigilLocked = false;



    [DllImport("user32.dll")]
    private static extern bool SetCursorPos(int X, int Y);

    void Awake(){
        if(!instance) instance = this;
        else Destroy(this);
    }

    void Update(){
        if(Input.GetMouseButtonDown(0) && !sigilSpawned){
            //spawn sigil
            sigilSpawned = true;
            // MoveCursor();
            spawnSigils();
        }

        if(Input.GetMouseButtonUp(0) && sigilSpawned){
            //despawn sigil
            // Debug.Log("sigil despawned!");
            despawnSigils();
        }
    }

    // void MoveCursor()
    // {
        
    //     Vector2 screenPosition;
    //     screenPosition.x = Screen.width/2;
    //     screenPosition.y = Screen.height/2;
    //     Debug.Log(screenPosition);
    //     SetCursorPos((int)screenPosition.x, (int)screenPosition.y);
    // }

    void spawnSigils(){
        for(int i = 0; i < sigilsObjects.Count; i++){
            spawnedSigils.Add(Instantiate(sigilsObjects[i],transform));
            spawnedSigils[i].GetComponent<RectTransform>().position = sigilSpawn.position;
            spawnedSigils[i].GetComponent<MoveUIToTarget>().setTarget(sigilPositions[i].anchoredPosition);
        }
    }

    public void addConnectedSigils(GameObject gameObject){
        connectedSigils.Add(gameObject);
    }

    void despawnSigils(){
        sigilLocked = true;
        for(int i = 0; i < spawnedSigils.Count; i++){
            spawnedSigils[i].GetComponent<MoveUIToTarget>().setTarget(sigilSpawn.anchoredPosition);
            Destroy(spawnedSigils[i],0.5f);
        }
        spawnedSigils = new List<GameObject>();
        connectedSigils = new List<GameObject>();
        Invoke("reloadSigils",0.5f);
    }

    void reloadSigils(){
        sigilSpawned = false;
        sigilLocked = false;
    }
}
