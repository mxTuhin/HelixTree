using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject HelixSet;
    public GameObject Cylinder;
    public GameObject redSet;

    private float vectorYPos=0;
    
    public static int helixCounter = 35;
    GameObject[] set=new GameObject[helixCounter];
    public bool inGame = false;
    public GameObject menuCanvas;
    public static GameManager instance;
    public Text endingText;

    public Material red;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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
                GameObject locRedSet=Instantiate(redSet, set[i].transform.Find("" + (slot + 1)).gameObject.transform.position, set[i].transform.Find("" + (slot + 1)).gameObject.transform.rotation);
                locRedSet.transform.SetParent(Cylinder.transform);
                set[i].transform.Find("" + (slot + 1)).gameObject.SetActive(false);
            }
            
            vectorYPos += 4;
            set[i].transform.SetParent(Cylinder.transform);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticVars.inGame)
        {
            Time.timeScale = 1.0f;
            menuCanvas.SetActive(false);
        }
        else
        {
            Time.timeScale = 0.0f;
            menuCanvas.SetActive(true);
        }
        
    }

    void setTrue(GameObject locSet)
    {
        for (int i = 1; i <=12; ++i)
        {
            locSet.transform.Find(""+i).gameObject.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void playGame()
    {
        StaticVars.inGame = true;
        SceneManager.LoadScene("Play");
        
    }
}
