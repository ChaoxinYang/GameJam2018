using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private ScoreKeeper scoreKeeper;
    private AudioSource[] audioSources;
    public float timer = 0.5f;

    void Start(){
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void OnEnable(){
        audioSources = gameObject.GetComponents<AudioSource>();
        audioSources[0].Play();
    }

    // Update is called once per frame
    void Update(){
        timer -= Time.deltaTime;
        if (timer <= 0){
            gameObject.SetActive(false);
            timer = 0.5f;
        }

        if (audioSources[1].isPlaying == false && gameObject.GetComponent<SpriteRenderer>().enabled == false){
            gameObject.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D coll){
        if (coll.gameObject.CompareTag("Enemy")){
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            audioSources[1].Play();

        }
    }
}
