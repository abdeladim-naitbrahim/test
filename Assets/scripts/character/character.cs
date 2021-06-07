using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public const float dx = 0.8f;
    public static List<clone> clones;
    public static character instance;
    public static int x;
    public static GameObject clonref;
    // Start is called before the first frame update
    public static Vector3 getpositionclone(int index)
    {
        Vector3 charpos = character.instance.transform.position;
        int y = Mathf.FloorToInt(index / character.x);
        int x = (index == 0 ? 0 : (y == 0 ? index : index % y));
        x = x - Mathf.FloorToInt(character.x / 2);
        return character.instance.transform.position + new Vector3(x * character.dx, 0, -y * character.dx);

    }
    void Start()
    {
        clonref= Resources.Load<GameObject>("clone");
        if (!instance)
            instance = this;
        getclones();
    }
    public void getclones()
    {
        clones = new List<clone>();
        clones.Clear();
        int i = 0;
        foreach(GameObject x in GameObject.FindGameObjectsWithTag("clone"))
        {
            clone y = x.GetComponent<clone>();
            clones.Add(y);
            y.index = i;
            if(y.folow)y.transform.position = getpositionclone(i);
            i++;
        }

        x = i;
    }
    // Update is called once per frame
    void Update()
    {

         x = Mathf.FloorToInt(Mathf.Sqrt(clones.Count));
        if (x != GameObject.FindGameObjectsWithTag("clone").Length)
            getclones();


    }
}
