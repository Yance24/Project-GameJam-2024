using System.Collections;
using UnityEngine;

public class BgmThreatSystem : MonoBehaviour
{
    public AudioSource normalBgm;
    public AudioSource threatBgm;

    public float fadeDuration;

    Coroutine bgmFade;

    void OnEnable(){
        EnemyAI.totalEnemyAggroOnChange += checkBgm;
    }

    void OnDisable(){
        EnemyAI.totalEnemyAggroOnChange -= checkBgm;
    }

    void Start(){
        checkBgm();
    }

    void checkBgm(){
        if(bgmFade != null) StopCoroutine(bgmFade);
        if(EnemyAI.TotalEnemyAggro > 0){
            bgmFade = StartCoroutine(changeThreatBgm());
        }else{
            bgmFade = StartCoroutine(changeNormalBgm());
        }
    }
    IEnumerator changeNormalBgm(){
        float currentTime = Mathf.Lerp(1,0,threatBgm.volume);
        while(currentTime < fadeDuration){
            currentTime += Time.fixedDeltaTime;
            float progress = currentTime / fadeDuration;
            threatBgm.volume = Mathf.Lerp(1,0,progress);
            yield return new WaitForFixedUpdate();
        }
        threatBgm.Stop();



        if(!normalBgm.isPlaying){
            normalBgm.time = 0;
            normalBgm.Play();
        }

        currentTime = Mathf.Lerp(0,1,normalBgm.volume);
        while(currentTime < fadeDuration){
            currentTime += Time.fixedDeltaTime;
            float progress = currentTime / fadeDuration;
            normalBgm.volume = Mathf.Lerp(0,1,progress);
            yield return new WaitForFixedUpdate();
        }
        yield break;
    }

    IEnumerator changeThreatBgm(){
        float currentTime = Mathf.Lerp(1,0,normalBgm.volume);
        while(currentTime < fadeDuration){
            currentTime += Time.fixedDeltaTime;
            float progress = currentTime / fadeDuration;
            normalBgm.volume = Mathf.Lerp(1,0,progress);
            yield return new WaitForFixedUpdate();
        }
        normalBgm.Stop();



        if(!threatBgm.isPlaying){
            threatBgm.time = 0;
            threatBgm.Play();
        }

        currentTime = Mathf.Lerp(0,1,threatBgm.volume);
        while(currentTime < fadeDuration){
            currentTime += Time.fixedDeltaTime;
            float progress = currentTime / fadeDuration;
            threatBgm.volume = Mathf.Lerp(0,1,progress);
            yield return new WaitForFixedUpdate();
        }
        yield break;
    }
}
