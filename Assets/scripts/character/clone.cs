using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clone : MonoBehaviour
{
    public float forceCof;
    public float maxVitess;
    public float maxforce;
    public int index;
    public Rigidbody rigidbody;
    public bool folow=true;
    pont pontgoal;
    
    public void go(Vector3 t)
    {
        Vector3 force = Vector3.ClampMagnitude(forceCof * (t - transform.position), maxforce);
        force -= force.y * Vector3.up;
        rigidbody.AddForce(force );
        if (rigidbody.velocity.magnitude > maxVitess)
        {
            rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity- rigidbody.velocity.y*Vector3.up, maxVitess)+ rigidbody.velocity.y * Vector3.up;

            //_rigidbody.AddForce(direction * _speed);
        }
    }
    public void gotopontgoal(pont t)
    {
       /* maxVitess *= 2;
        forceCof *=2;*/
        pontgoal = t;
        folow = false;
    }
    // Start is called before the first frame update
    void Start()
    {
     //   character.instance.getclones();
    }

    // Update is called once per frame
    void Update()
    {
        
       


        if (folow)
        {
            go(character.getpositionclone(index));
           
        }
        else
        {
            foreach (var p in pontgoal.elements)
            {if(!p.cln.active)
                {
                    go(p.cln.transform.position);
                    break;
                }
                
            }
        }
    }
}
