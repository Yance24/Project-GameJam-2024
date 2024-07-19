using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class SpellCastingManager : MonoBehaviour
{
    public static SpellCastingManager instance{private set; get;}

    public List<GameObject> sigilsObjects;
    public List<RectTransform> sigilPositions;
    public RectTransform sigilSpawn;
    public AudioClip spawnSigilSFX;
    public AudioClip despawnSigilSFX;

    private AudioSource audioSource;

    private List<GameObject> spawnedSigils = new List<GameObject>();
    private List<int> connectedSigilsID = new List<int>();
    private GameObject castedSpell;

    bool sigilSpawned = false;
    public bool isCooked = false;
    public bool sigilLocked = false;



    [DllImport("user32.dll")]
    private static extern bool SetCursorPos(int X, int Y);

    void Awake(){
        if(!instance) instance = this;
        else Destroy(this);
    }

    void Start(){
        audioSource = GetComponent<AudioSource>();
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
        audioSource.clip = spawnSigilSFX;
        audioSource.Play();

        for(int i = 0; i < sigilsObjects.Count; i++){
            spawnedSigils.Add(Instantiate(sigilsObjects[i],transform));
            spawnedSigils[i].GetComponent<RectTransform>().position = sigilSpawn.position;
            spawnedSigils[i].GetComponent<MoveUIToTarget>().setTarget(sigilPositions[i].anchoredPosition);
        }
    }

    public void addConnectedSigils(int id){
        connectedSigilsID.Add(id);
        checkedCastedSpell();
    }

    void checkedCastedSpell(){
        
        foreach(SpellRecipe storedSpell in SpellDatabase.instance.storedSpells){
            if(connectedSigilsID.Count == storedSpell.connectingSigilsID.Count){
                bool isCorrectSigils = true;
                for(int i = 0; i < connectedSigilsID.Count; i++){
                    if(connectedSigilsID[i] != storedSpell.connectingSigilsID[i]){
                        Debug.Log("Connected Sigils : "+connectedSigilsID[i]);
                        Debug.Log("Connecting Sigils : "+storedSpell.connectingSigilsID[i]);
                        isCorrectSigils = false;
                        break;
                    }
                }
                if(isCorrectSigils){
                    // castedSpell = storedSpell.spells;
                    Debug.Log("Success cast : "+storedSpell.spells.name);
                    isCooked = true;
                    sigilLocked = true;
                }
            }
        }
    }

    void despawnSigils(){
        sigilLocked = true;
        for(int i = 0; i < spawnedSigils.Count; i++){
            spawnedSigils[i].GetComponent<MoveUIToTarget>().setTarget(sigilSpawn.anchoredPosition);
            Destroy(spawnedSigils[i],0.4f);
        }
        audioSource.clip = despawnSigilSFX;
        audioSource.Play();

        spawnedSigils = new List<GameObject>();
        connectedSigilsID = new List<int>();
        Invoke("reloadSigils",0.4f);
    }

    void reloadSigils(){
        sigilSpawned = false;
        sigilLocked = false;
        SigilConnectSFX.instance.resetPitch();
    }
}
