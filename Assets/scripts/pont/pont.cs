using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pont : MonoBehaviour
{
    public  pontelement[] elements;
    bool usable = true;
    // Start is called before the first frame update
    void Start()
    {

        elements = transform.parent.GetComponentsInChildren<pontelement>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "character" && usable)
        {
            usable = false;
          // gameObject. GetComponent<MeshCollider>().enabled = false;
            Debug.Log("detect");
            float maxz = 0;
            /*foreach(var z in character.clones)
            {
                float mz = z.transform.position.z;
                if (mz>)
            }*/
            for (int i = 0; i < elements.Length; i++)
            {
                Debug.Log("go");
                character.clones[i].gotopontgoal(this);
            }
        }

    }
}
