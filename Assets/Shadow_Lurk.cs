using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow_Lurk : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sprite;
    bool isKilling;
    GameObject lightBar;
    public bool stoped;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer> ();
        StartCoroutine(RandKill());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator KillThisMF(){
        isKilling = true;
        stoped = false;
        while(sprite.color.a < 1 && !stoped) {
            print("oj");
            Color tmp = sprite.color;
            tmp.a += Time.deltaTime/12;
            sprite.color = tmp;
            yield return null;

        }

        if (sprite.color.a >= 1) {
            GameStates.instance.GameOver();
        }

        isKilling = false;
        stoped = false;
        Color _tmp = sprite.color;
        _tmp.a = 0;
        sprite.color = _tmp;
    }

    private IEnumerator RandKill() {
        while(true) {
            yield return new WaitForSeconds(2f);
            int rand = Random.Range(0,10);
            if (rand <= 2) {
                if (!isKilling) {
                    StartCoroutine(KillThisMF());
                }
            }
        }
    }
}
