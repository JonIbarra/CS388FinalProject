using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameMgr : MonoBehaviour
{
    bool seen;
    bool playing;
    bool front_active;
    bool back_active;
    bool left_active;
    bool right_active;

    Vector3 mDirection;
    public float mFanSpeed;

    GameObject mBall;

    GameObject mFanFront;
    GameObject mFanBack;
    GameObject mFanLeft;
    GameObject mFanRight;

    private ParticleSystem mNorthPS;
    private ParticleSystem mSouthPS;
    private ParticleSystem mWestPS;
    private ParticleSystem mEastPS;

    GameObject mLaberynth;
    Vector3 mLaberynthPos;

    public GameObject mBallPrefab;
    public GameObject mFanPrefab;
    public ParticleSystem mWinningPS;

    public TMP_Text mSearchText;
    public TMP_Text mWinText;

    public Button mPlayButton;
    public Button mNorthButton;
    public Button mSouthButton;
    public Button mWestButton;
    public Button mEastButton;

    private Image mNorthImage;
    private Image mSouthImage;
    private Image mWestImage;
    private Image mEastImage;

    public Animator mAnimator;

    // Start is called before the first frame update
    void Start()
    {
        seen = false;
        playing = false;
        front_active = false;
        back_active = false;
        left_active = false;
        right_active = false;

        mDirection = new Vector3(0, 0, 1);

        mNorthImage = mNorthButton.GetComponent<Image>();
        mSouthImage = mSouthButton.GetComponent<Image>();
        mWestImage = mWestButton.GetComponent<Image>();
        mEastImage = mEastButton.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //Quaternion deltaRotation = Quaternion.Euler(mAngleVelocity * Time.fixedDeltaTime);

        if(seen)
        {
            //mFanFront.transform.position = mLaberynthPos + mLaberynth.transform.up * 300 + mLaberynth.transform.forward * 1200;
            //mFanFront.transform.rotation = Quaternion.Euler(0,0,0);
            //Physics.gravity = mLaberynth.transform.up * (-1000);

            //mText.text = "DEACTIVE";
            //
            //mText.text = "ACTIVE: " + (mBall.GetComponent<Rigidbody>().velocity.x) + ", " + (mBall.GetComponent<Rigidbody>().velocity.y) + ", " + (mBall.GetComponent<Rigidbody>().velocity.z);
        }

        if(front_active)
        {
            mFanFront.transform.GetChild(0).Rotate(mFanSpeed * mDirection * Time.deltaTime);
            mBall.GetComponent<Rigidbody>().AddForce(-mFanFront.transform.forward * 10000);
        }

        if (back_active)
        {
            mFanBack.transform.GetChild(0).Rotate(mFanSpeed * mDirection * Time.deltaTime);
            mBall.GetComponent<Rigidbody>().AddForce(-mFanBack.transform.forward * 10000);
        }

        if (left_active)
        {
            mFanLeft.transform.GetChild(0).Rotate(mFanSpeed * mDirection * Time.deltaTime);
            mBall.GetComponent<Rigidbody>().AddForce(-mFanLeft.transform.forward * 10000);
        }

        if (right_active)
        {
            mFanRight.transform.GetChild(0).Rotate(mFanSpeed * mDirection * Time.deltaTime);
            mBall.GetComponent<Rigidbody>().AddForce(-mFanRight.transform.forward * 10000);
        }
    }

    public void SetOro(GameObject lab)
    {
        mSearchText.text = "Gold Ace map found";
        SetLaberynth(lab);
    }

    public void SetCopa(GameObject lab)
    {
        mSearchText.text = "Cup Ace map found";
        SetLaberynth(lab);
    }

    public void SetBasto(GameObject lab)
    {
        mSearchText.text = "Club Ace map found";
        SetLaberynth(lab);
    }

    public void SetEspada(GameObject lab)
    {
        mSearchText.text = "Sword Ace map found";
        SetLaberynth(lab);
    }

    public void SetLaberynth(GameObject lab)
    {
        if (!seen)
        {
            mPlayButton.interactable = true;
            
            mLaberynth = lab;
            mLaberynthPos = lab.transform.position;
            Physics.gravity = mLaberynth.transform.up * (-1000);

            mFanFront = Instantiate(mFanPrefab, mLaberynthPos + mLaberynth.transform.up * 300 + mLaberynth.transform.forward * 1200, mLaberynth.transform.rotation);
            mFanFront.transform.parent = mLaberynth.transform;
            mNorthPS = mFanFront.transform.GetChild(1).GetComponent<ParticleSystem>();
            mNorthPS.Stop();

            mFanBack = Instantiate(mFanPrefab, mLaberynthPos + mLaberynth.transform.up * 300 - mLaberynth.transform.forward * 1200, mLaberynth.transform.rotation);
            mFanBack.transform.Rotate(new Vector3(0, 1, 0) * 180);
            mFanBack.transform.parent = mLaberynth.transform;
            mSouthPS = mFanBack.transform.GetChild(1).GetComponent<ParticleSystem>();
            mSouthPS.Stop();

            mFanLeft = Instantiate(mFanPrefab, mLaberynthPos + mLaberynth.transform.up * 300 - mLaberynth.transform.right * 1200, mLaberynth.transform.rotation);
            mFanLeft.transform.Rotate(new Vector3(0, 1, 0) * 270);
            mFanLeft.transform.parent = mLaberynth.transform;
            mWestPS = mFanLeft.transform.GetChild(1).GetComponent<ParticleSystem>();
            mWestPS.Stop();

            mFanRight = Instantiate(mFanPrefab, mLaberynthPos + mLaberynth.transform.up * 300 + mLaberynth.transform.right * 1200, mLaberynth.transform.rotation);
            mFanRight.transform.Rotate(new Vector3(0, 1, 0) * 90);
            mFanRight.transform.parent = mLaberynth.transform;
            mEastPS = mFanRight.transform.GetChild(1).GetComponent<ParticleSystem>();
            mEastPS.Stop();

            seen = true;
        }
    }

    public void ExitCard()
    {
        if (seen)
        {
            mSearchText.text = "Searching for a card";
            mPlayButton.transform.GetChild(0).GetComponent<Text>().text = "Play";

            mWinText.color = new Color32(255, 255, 255, 0);

            if (playing)
                Object.Destroy(mBall);

            Object.Destroy(mFanFront);
            Object.Destroy(mFanBack);
            Object.Destroy(mFanLeft);
            Object.Destroy(mFanRight);

            mPlayButton.interactable = false;
            mNorthButton.interactable = false;
            mSouthButton.interactable = false;
            mWestButton.interactable = false;
            mEastButton.interactable = false;

            mNorthImage.color = new Color32(253, 88, 49, 255);
            mSouthImage.color = new Color32(253, 88, 49, 255);
            mWestImage.color = new Color32(253, 88, 49, 255);
            mEastImage.color = new Color32(253, 88, 49, 255);

            seen = false;
            playing = false;
            front_active = false;
            back_active = false;
            left_active = false;
            right_active = false;
        }
    }

    public void PressingFanFront()
    {
        if (playing)
        {
            front_active = !front_active;
            if (front_active)
            {
                mNorthImage.color = new Color32(209, 255, 143, 255);
                mNorthPS.Play();
            }
            else
            {
                mNorthImage.color = new Color32(253, 88, 49, 255);
                mNorthPS.Stop();
            }
        }
    }

    public void PressingFanBack()
    {
        if (playing)
        {
            back_active = !back_active;
            if (back_active)
            {
                mSouthImage.color = new Color32(209, 255, 143, 255);
                mSouthPS.Play();
            }
            else
            {
                mSouthImage.color = new Color32(253, 88, 49, 255);
                mSouthPS.Stop();
            }
        }
    }

    public void PressingFanLeft()
    {
        if (playing)
        {
            left_active = !left_active;
            if (left_active)
            {
                mWestImage.color = new Color32(209, 255, 143, 255);
                mWestPS.Play();
            }
            else
            {
                mWestImage.color = new Color32(253, 88, 49, 255);
                mWestPS.Stop();
            }
        }
    }

    public void PressingFanRight()
    {
        if (playing)
        {
            right_active = !right_active;
            if (right_active)
            {
                mEastImage.color = new Color32(209, 255, 143, 255);
                mEastPS.Play();
            }
            else
            {
                mEastImage.color = new Color32(253, 88, 49, 255);
                mEastPS.Stop();
            }
        }
    }

    public void PressPlay()
    {
        if (playing)
            Object.Destroy(mBall);
        if (seen)
        {
            Vector3 pos = mLaberynth.transform.GetChild(0).transform.GetChild(0).transform.position;
            mBall = Instantiate(mBallPrefab, new Vector3(pos.x, pos.y + 165, pos.z), Quaternion.identity);
            mBall.transform.parent = mLaberynth.transform;
            mBall.GetComponent<BallController>().mWinText = mWinText;
            mBall.GetComponent<BallController>().mGameMgr = this;

            playing = true;

            mPlayButton.transform.GetChild(0).GetComponent<Text>().text = "Reset";
            mWinText.color = new Color32(255, 255, 255, 0);

            mNorthButton.interactable = true;
            mSouthButton.interactable = true;
            mWestButton.interactable = true;
            mEastButton.interactable = true;
        }
    }

    public void PressingBackButton()
    {
        mAnimator.Play("FadeOut");
        Invoke("ExitLevel", 2);
    }

    void ExitLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void Win()
    {
        Instantiate(mWinningPS, mLaberynth.transform);
    }
}
