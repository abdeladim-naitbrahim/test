using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneCreator : MonoBehaviour
{
    public int multiple = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void generateclone()
    {
        int n0 = character.clones.Count;
        int   n = (n0 == 0 ? multiple : n0 * multiple);
       /* int i = 0;
        foreach (GameObject x in GameObject.FindGameObjectsWithTag("clone"))
        {
            clone y = x.GetComponent<clone>();
            character.clones.Add(y);
            y.index = i;
            i++;
        }*/
        for(int j=n0;j<n;j++)
        {
            clone y = Instantiate<clone>(character.clonref.GetComponent<clone>());
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "character")
        {                        
            GetComponent<MeshCollider>().enabled = false;
            generateclone();
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
