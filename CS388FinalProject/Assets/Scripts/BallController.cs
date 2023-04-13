using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    GameObject mBall;
    public GameObject mBallPrefab;
    GameObject mTarget;

    public GameObject ARCamera;

    bool active = false;
    
    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBall(GameObject target)
    {
        if (!active)
        {
            active = true;
            mTarget = target;
            Vector3 pos = mTarget.transform.GetChild(0).transform.GetChild(0).transform.position;
            mBall = Instantiate(mBallPrefab, new Vector3(pos.x, pos.y + 165, pos.z), Quaternion.identity);
            Physics.gravity = mTarget.transform.up * (-1000);
        }
    }

    public void ExitCard()
    {
        if (active)
            active = false;
    }
}
