using System.Text;
using UnityEngine;

enum GESTURE {
    UP = 0,
    DOWN = 1,
    LEFT = 2,
    RIGHT = 3,
    NONE = 4,
}

public class PlayerController : MonoBehaviour
{
    private Rigidbody mRigibody;

    public float jumpForce = 5f;
    
    void Start()
    {
        mRigibody = GetComponent<Rigidbody>();
        
        if(mRigibody == null){
            throw new System.Exception("No rigibody on player");
        }
    }

    void Update()
    {   

        GESTURE currentGesture = GESTURE.NONE;
        BleApi.BLEData res = new BleApi.BLEData();
        while (BleApi.PollData(out res, false))
        {
            string gestureCodeString = Encoding.ASCII.GetString(res.buf, 0, res.size);

            currentGesture = (GESTURE) System.Int32.Parse(gestureCodeString);
            UIController.instance.debugText.text = currentGesture.ToString();
             
            if(currentGesture == GESTURE.LEFT && mRigibody.velocity.magnitude == 0){

                transform.Translate(Vector3.left * 3);

            }

            if(currentGesture == GESTURE.RIGHT && mRigibody.velocity.magnitude == 0){

                transform.Translate(Vector3.left * -3);

            }

            if(currentGesture == GESTURE.UP && mRigibody.velocity.magnitude == 0){

                mRigibody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            }

            currentGesture = GESTURE.NONE;

        }


        if(Input.GetKeyDown(KeyCode.LeftArrow) && mRigibody.velocity.magnitude == 0){

            transform.Translate(Vector3.left * 3);

        }

        if(Input.GetKeyDown(KeyCode.RightArrow) && mRigibody.velocity.magnitude == 0){

            transform.Translate(Vector3.left * -3);
        
        }

        if(Input.GetKeyDown(KeyCode.Space) && mRigibody.velocity.magnitude == 0){
            mRigibody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }
}
