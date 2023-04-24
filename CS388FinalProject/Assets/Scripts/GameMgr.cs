using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    bool seen;
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

    GameObject mLaberynth;
    Vector3 mLaberynthPos;

    public GameObject mBallPrefab;
    public GameObject mFanPrefab;

    //public UnityEngine.UI.Text mText;

    // Start is called before the first frame update
    void Start()
    {
        seen = false;
        front_active = false;
        back_active = false;
        left_active = false;
        right_active = false;

        mDirection = new Vector3(0, 0, 1);
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

    public void SetLaberynth(GameObject lab)
    {
        if (!seen)
        {
            mLaberynth = lab;
            mLaberynthPos = lab.transform.position;
            Vector3 pos = lab.transform.GetChild(0).transform.GetChild(0).transform.position;

            mBall = Instantiate(mBallPrefab, new Vector3(pos.x, pos.y + 165, pos.z), Quaternion.identity);
            mBall.transform.parent = mLaberynth.transform;
            Physics.gravity = mLaberynth.transform.up * (-1000);

            mFanFront = Instantiate(mFanPrefab, mLaberynthPos + mLaberynth.transform.up * 300 + mLaberynth.transform.forward * 1200, mLaberynth.transform.rotation);
            mFanFront.transform.parent = mLaberynth.transform;

            mFanBack = Instantiate(mFanPrefab, mLaberynthPos + mLaberynth.transform.up * 300 - mLaberynth.transform.forward * 1200, mLaberynth.transform.rotation);
            mFanBack.transform.Rotate(new Vector3(0, 1, 0) * 180);
            mFanBack.transform.parent = mLaberynth.transform;

            mFanLeft = Instantiate(mFanPrefab, mLaberynthPos + mLaberynth.transform.up * 300 - mLaberynth.transform.right * 1200, mLaberynth.transform.rotation);
            mFanLeft.transform.Rotate(new Vector3(0, 1, 0) * 270);
            mFanLeft.transform.parent = mLaberynth.transform;

            mFanRight = Instantiate(mFanPrefab, mLaberynthPos + mLaberynth.transform.up * 300 + mLaberynth.transform.right * 1200, mLaberynth.transform.rotation);
            mFanRight.transform.Rotate(new Vector3(0, 1, 0) * 90);
            mFanRight.transform.parent = mLaberynth.transform;

            seen = true;
        }
    }

    public void ExitCard()
    {
        if (seen)
        {
            Object.Destroy(mBall);

            Object.Destroy(mFanFront);
            Object.Destroy(mFanBack);
            Object.Destroy(mFanLeft);
            Object.Destroy(mFanRight);

            seen = false;
            front_active = false;
            back_active = false;
            left_active = false;
            right_active = false;
        }
    }

    public void PressingFanFront()
    {
        if (seen)
        {
            front_active = !front_active;
        }
    }

    public void PressingFanBack()
    {
        if (seen)
        {
            back_active = !back_active;
        }
    }

    public void PressingFanLeft()
    {
        if (seen)
        {
            left_active = !left_active;
        }
    }

    public void PressingFanRight()
    {
        if (seen)
        {
            right_active = !right_active;
        }
    }
}
