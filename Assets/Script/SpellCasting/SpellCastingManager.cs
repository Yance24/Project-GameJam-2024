using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SpellCastingManager : MonoBehaviour
{
    public static SpellCastingManager instance{private set; get;}

    public Transform player;
    public List<GameObject> sigilsObjects;
    public List<RectTransform> sigilPositions;
    public RectTransform sigilSpawn;
    public AudioClip spawnSigilSFX;
    public AudioClip despawnSigilSFX;
    public Image lineImage;
    public Texture2D aimCursorTexture;
    public Texture2D defaultTexture;

    private AudioSource audioSource;

    private List<GameObject> spawnedSigils = new List<GameObject>();
    private List<SigilHandler> connectedSigilsID = new List<SigilHandler>();
    private List<Image> instantiatedLine = new List<Image>();


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
            despawnSigils();
        }

        if(connectedSigilsID.Count > 0 && !isCooked){
            LineDrawer.drawUiLine(connectedSigilsID[connectedSigilsID.Count - 1].rectTransform().localPosition,
            MouseUtil.mousePositionToRect(sigilSpawn),
            instantiatedLine[instantiatedLine.Count - 1]);
        }
    }

    // void MoveCursor()
    // {
        
    //     Vector2 screenPosition;
    //     screenPosition = Camera.main.WorldToScreenPoint(player.position);
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

    public void addConnectedSigils(SigilHandler sigil){
        connectedSigilsID.Add(sigil);

        if(connectedSigilsID.Count > 1){
            LineDrawer.drawUiLine(connectedSigilsID[connectedSigilsID.Count - 2].rectTransform().localPosition,
            connectedSigilsID[connectedSigilsID.Count - 1].rectTransform().localPosition,
            instantiatedLine[instantiatedLine.Count - 1]);
        }

        checkedCastedSpell();

        if(isCooked) return;

        instantiatedLine.Add(Instantiate(lineImage.gameObject,transform).GetComponent<Image>());
        LineDrawer.drawUiLine(sigil.rectTransform().localPosition,
        MouseUtil.mousePositionToRect(sigilSpawn),
        instantiatedLine[instantiatedLine.Count - 1]);
    }

    void checkedCastedSpell(){
        
        foreach(SpellRecipe storedSpell in SpellDatabase.instance.storedSpells){
            if(connectedSigilsID.Count == storedSpell.connectingSigilsID.Count){
                bool isCorrectSigils = true;
                for(int i = 0; i < connectedSigilsID.Count; i++){
                    if(connectedSigilsID[i].id != storedSpell.connectingSigilsID[i].id){
                        // Debug.Log("Connected Sigils : "+connectedSigilsID[i]);
                        // Debug.Log("Connecting Sigils : "+storedSpell.connectingSigilsID[i]);
                        isCorrectSigils = false;
                        break;
                    }
                }
                if(isCorrectSigils){
                    castedSpell = storedSpell.spells;
                    Vector2 cursorHotspot = new Vector2(aimCursorTexture.width / 2, aimCursorTexture.height / 2);
                    Cursor.SetCursor(aimCursorTexture,cursorHotspot,CursorMode.Auto);
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
        for(int i = 0; i < instantiatedLine.Count; i++){
            Destroy(instantiatedLine[i]);
        }

        spawnedSigils = new List<GameObject>();
        connectedSigilsID = new List<SigilHandler>();
        instantiatedLine = new List<Image>();
        Invoke("reloadSigils",0.4f);
    }

    void reloadSigils(){
        sigilSpawned = false;
        sigilLocked = false;
        SigilConnectSFX.instance.resetPitch();
        if(isCooked){
            castSpell();
            isCooked = false;
            Cursor.SetCursor(defaultTexture,Vector2.zero,CursorMode.Auto);
        }
        
    }

    void castSpell(){
        castedSpell = Instantiate(castedSpell);
        castedSpell.transform.position = player.position;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        castedSpell.GetComponent<Rigidbody2D>().rotation    = YEuler.countAngle(player.position,mousePosition);
    }
}
