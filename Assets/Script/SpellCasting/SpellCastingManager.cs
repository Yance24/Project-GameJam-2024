using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpellCastingManager : MonoBehaviour
{
    public List<GameObject> sigilsObjects;
    public List<RectTransform> sigilPositions;
    public RectTransform sigilSpawn;

    private List<GameObject> spawnedSigils = new List<GameObject>();
    bool sigilSpawned = false;

    [DllImport("user32.dll")]
    private static extern bool SetCursorPos(int X, int Y);

    void Update(){
        if(Input.GetMouseButtonDown(0) && !sigilSpawned){
            //spawn sigil
            // Debug.Log("sigil spawned!");
            sigilSpawned = true;
            // MoveCursor();
            spawnSigils();
        }

        if(Input.GetMouseButtonUp(0) && sigilSpawned){
            //despawn sigil
            // Debug.Log("sigil despawned!");
            sigilSpawned = false;
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
}
