using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeText : MonoBehaviour
{
    public TMP_Text mText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OroFound()
    {
        mText.text = "Oro level found";
    }

    public void EspadaFound()
    {
        mText.text = "Espada level found";
    }

    public void CopaFound()
    {
        mText.text = "Copa level found";
    }

    public void BastoFound()
    {
        mText.text = "Basto level found";
    }

    public void TargetLost()
    {
        mText.text = "Level lost";
    }
}
