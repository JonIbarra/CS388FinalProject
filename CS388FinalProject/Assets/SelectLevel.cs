using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectLevel : MonoBehaviour
{
    public TMP_Text mText;
    public Button playButton;

    private LevelEnum levelSelected;
    private Image buttonColor;

    // Start is called before the first frame update
    void Start()
    {
        buttonColor = playButton.GetComponent<Image>();
        levelSelected = playButton.GetComponent<LevelEnum>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OroFound()
    {
        mText.text = "Oro level found";
        buttonColor.color = new Vector4(255.0f, 255.0f, 255.0f, 255.0f);
        playButton.interactable = true;
        levelSelected.whichLevel = Level.Gold;
    }

    public void EspadaFound()
    {
        mText.text = "Espada level found";
        buttonColor.color = new Vector4(255.0f, 255.0f, 255.0f, 255.0f);
        playButton.interactable = true;
        levelSelected.whichLevel = Level.Sword;
    }

    public void CopaFound()
    {
        mText.text = "Copa level found";
        buttonColor.color = new Vector4(255.0f, 255.0f, 255.0f, 255.0f);
        playButton.interactable = true;
        levelSelected.whichLevel = Level.Cup;
    }

    public void BastoFound()
    {
        mText.text = "Basto level found";
        buttonColor.color = new Vector4(255.0f, 255.0f, 255.0f, 255.0f);
        playButton.interactable = true;
        levelSelected.whichLevel = Level.Cane;
    }

    public void TargetLost()
    {
        mText.text = "Level lost";
        buttonColor.color = new Vector4(255.0f, 255.0f, 255.0f, 50.0f);
        playButton.interactable = false;
        levelSelected.whichLevel = Level.None;
    }
}
