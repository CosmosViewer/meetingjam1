using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAir : MonoBehaviour
{
    public GameObject vent;
    bool SpawnedAir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            if (SpawnedAir)
                return;
            
            SpawnedAir = true;
            Instantiate(vent, other.gameObject.transform.position + 5 * Vector3.right, Quaternion.identity);
        }
    }
}
