using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevel : MonoBehaviour
{
    private Level levelSelected;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void ButtonClicked()
    {
        levelSelected = gameObject.GetComponent<LevelEnum>().whichLevel;

        switch (levelSelected)
        {
            case Level.Gold:
                Debug.Log("Gold level initialized");
                break;
            case Level.Sword:
                Debug.Log("Sword level initialized");
                break;
            case Level.Cup:
                Debug.Log("Cup level initialized");
                break;
            case Level.Cane:
                Debug.Log("Cane level initialized");
                break;
        }
    }
}
