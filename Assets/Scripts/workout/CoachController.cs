using UnityEngine;

public class CoachController : MonoBehaviour
{
    private Animator mAnimator;
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        if(mAnimator == null){
            throw new System.Exception("No Animator on coach");
        }
    }

    public void StartMoviment(Moviment moviment){

         switch (moviment)
        {
            case Moviment.IDLE:
                mAnimator.SetTrigger("idle");
                break;
            case Moviment.JUMP:
                mAnimator.SetTrigger("jumping");
                break;
            case Moviment.SWING:
                mAnimator.SetTrigger("swing");
                break;
            case Moviment.BREAK:
                mAnimator.SetTrigger("breaking");
                break;
            default:
                Debug.LogError("Movimento do personagem não reconhecido.");
                break;
        }


    }

}
