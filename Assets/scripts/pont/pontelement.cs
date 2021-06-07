using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pontelement : MonoBehaviour
{
    public GameObject cln;
    public MeshCollider detecteur;
    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "clone")
        {
            Destroy(other.gameObject);
            cln.active = true;
            detecteur.enabled = false;
        }

    }
}
