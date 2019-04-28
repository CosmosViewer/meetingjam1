using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldLight : MonoBehaviour
{
    bool isHoldingLigth;
    public Animator ligth;
    public Transform ligthSize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (isHoldingLigth) {
                return;
            }

            else {
                isHoldingLigth = true;
                StartCoroutine(ReduceLigth());
            }
        }

        else if (Input.GetKeyUp(KeyCode.E)) {
            isHoldingLigth = false;
            StartCoroutine(PowerLigth());
        }
    }

    private IEnumerator ReduceLigth() {
        while (isHoldingLigth) {
            Vector3 size = ligthSize.localScale;
            if (ligthSize.localScale.x >= 0)
                size = new Vector3(size.x - Time.deltaTime, size.y - Time.deltaTime, size.y);
            ligthSize.localScale = size;
            yield return null;
        }
    }

    private IEnumerator PowerLigth() {
        float time = Time.time;
        while (true) {
            
            if (Time.time - time > 1f) {
                ligthSize.localScale = new Vector3(1f,1f,1f);
                break;
            }
            
            Vector3 size = ligthSize.localScale;
            
            size = new Vector3(size.x + Time.deltaTime * 10, size.y + Time.deltaTime * 10, size.y);
            ligthSize.localScale = size;
            
            yield return null;
        }

    }

}
