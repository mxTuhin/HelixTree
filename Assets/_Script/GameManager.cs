using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject HelixSet;
    public GameObject Cylinder;

    private float vectorYPos=0;

    private int counter=0;
    public static int helixCounter = 5;
    GameObject[] set=new GameObject[helixCounter];
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < helixCounter; ++i)
        {
            set[i]=Instantiate(HelixSet, new Vector3(0, vectorYPos, 0) , transform.rotation) as GameObject;
            setTrue(set[i]);
            int loopSlot = Random.Range(1, 4);
            Debug.Log(loopSlot);
            for (int j = 0; j < loopSlot; ++j)
            {
                int slot = Random.Range(1, 12);
                set[i].transform.Find(""+slot).gameObject.SetActive(false);
            }
            
            vectorYPos += 4;
            set[i].transform.SetParent(Cylinder.transform);
        }
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setTrue(GameObject locSet)
    {
        for (int i = 1; i <=12; ++i)
        {
            locSet.transform.Find(""+i).gameObject.SetActive(true);
        }
    }
}
