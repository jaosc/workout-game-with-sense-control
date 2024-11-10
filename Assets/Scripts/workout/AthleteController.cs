using System.Text;
using UnityEngine;

public class AthleteController : MonoBehaviour
{
    private Animator mAnimator;
    public Moviment mCurrentMoviment;
    void Start()
    {
        mCurrentMoviment = Moviment.IDLE;
        mAnimator = GetComponent<Animator>();
        if(mAnimator == null){
            throw new System.Exception("No Animator on athlete");
        }
    }

    void Update()
    {

        BleApi.BLEData res = new BleApi.BLEData();
        while (BleApi.PollData(out res, false))
        {
            string movimentPrediction = Encoding.ASCII.GetString(res.buf, 0, res.size);

            if(movimentPrediction == "break"){

                mAnimator.SetTrigger("breaking");
                mCurrentMoviment = Moviment.BREAK;
            
            }

            if(movimentPrediction == "swing"){

                mAnimator.SetTrigger("swing");
                mCurrentMoviment = Moviment.SWING;
            
            }

            if(movimentPrediction == "jumping"){

                mAnimator.SetTrigger("jumping");
                mCurrentMoviment = Moviment.JUMP;
            
            }

            if(movimentPrediction == "idle"){

                mAnimator.SetTrigger("idle");
                mCurrentMoviment = Moviment.IDLE;
            
            }
        }
    }
}
