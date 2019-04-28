using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBehaviour : MonoBehaviour
{
    
    AudioSource airSounds;
    Rigidbody2D air;
    GameObject player;
    GameObject lightBar;
    // Start is called before the first frame update
    void Start()
    {
        air = GetComponent<Rigidbody2D> ();
        airSounds = GetComponent<AudioSource> ();
        airSounds.playOnAwake = true;
        lightBar = GameObject.FindGameObjectWithTag("lightbar");
        player = GameObject.FindGameObjectWithTag("_player");
        print(player);
        StartCoroutine(ProduceAir());
    }

    private IEnumerator ProduceAir(){
        yield return new WaitForSeconds(0.5f);
        air.velocity = new Vector2(-3,0);
        float timer = Time.time;
        while(Time.time - timer < 3f){
           if (!lightBar.GetComponent<LightBar>().isProtecting)
                player.GetComponent<Luz>().lightHP -= 5f * Time.deltaTime;
        
            yield return null;
        }
    }
    
}
