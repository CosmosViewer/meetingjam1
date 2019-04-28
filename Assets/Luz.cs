using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour {

    public GameObject player;
    bool treme;
    public LightBar lightBar;
    public float lightHP;
    

    void Update () {

        //transform.position = player.position;
        if (!lightBar.isProtecting) {
            transform.localScale = new Vector3(12f,12f,10f) * (lightHP/ 50);
        }

        if (lightHP <= 0) {
            GameStates.instance.GameOver();
        }
    }

    public void Grow()
    {
        StartCoroutine(Growing());
    }

    public void Down()
    {
        StartCoroutine(Downing());
    }

    IEnumerator Growing()
    {
        lightBar.isProtecting = true;
        while(transform.localScale.x < 50)
        {
            transform.localScale = new Vector3(transform.localScale.x + (40 * Time.deltaTime), transform.localScale.y + (40 * Time.deltaTime));
            yield return new WaitForSeconds(.005f);
        }
        StartCoroutine(Normal());
        
    }

    IEnumerator Normal()
    {
        while (transform.localScale.x > 10)
        {
            transform.localScale = new Vector3(transform.localScale.x - (40 * Time.deltaTime), transform.localScale.y - (40 * Time.deltaTime));
            yield return new WaitForSeconds(.01f);
        }
        while (transform.localScale.x < 10)
        {
            transform.localScale = new Vector3(transform.localScale.x + (7 * Time.deltaTime), transform.localScale.y + (7 * Time.deltaTime));
            yield return new WaitForSeconds(.08f);
        }
        lightBar.grande = false;
        lightBar.isProtecting = false;
    }

    IEnumerator Downing()
    {
        lightBar.isProtecting = true;
        while (transform.localScale.x > 4)
        {
            transform.localScale = new Vector3(transform.localScale.x - (40 * Time.deltaTime), transform.localScale.y - (40 * Time.deltaTime));
            yield return new WaitForSeconds(.005f);
        }
        StartCoroutine(Normal());
    }
}
