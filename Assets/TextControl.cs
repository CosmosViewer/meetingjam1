using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControl : MonoBehaviour
{
    bool shown;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            if(shown)
                return;
            shown = true;
            transform.parent.GetChild(0).gameObject.SetActive(true);
        }    
    }
}
