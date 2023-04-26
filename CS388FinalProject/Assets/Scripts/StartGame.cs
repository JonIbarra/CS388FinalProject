using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public int gameStartScene;
    public Animator mAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartScene()
    {
        mAnimator.Play("FadeOut");
        Invoke("LoadScene", 2);
    }
    void LoadScene()
    {
        SceneManager.LoadScene(gameStartScene);
    }
}
