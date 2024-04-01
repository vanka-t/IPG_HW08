using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NPCController : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    SkinnedMeshRenderer face_Blendshape;

    // 0 = ready to blink, 1 = close eyes, 2= open
    int blinking = 0;
    float blinkingValue = 0;
    float blinkingTimer = 0;
    float blinkingTimerTotal = 3.5f;

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

     void Update()
    {
        blinkingTimer += Time.deltaTime;
        if(blinking == 0 && (Random.value <0.0001f || blinkingTimer > blinkingTimerTotal))
        {
            //start blinking
            blinkingTimer = 0;
            blinkingTimerTotal = Random.Range(1.1f, 5.01f);
            blinking = 1;
            blinkingValue = 0;
        }
        else if (blinking == 1)
        {
            //transition to closing eyes
            blinkingValue += Time.deltaTime * 1000;
            if(blinkingValue> 100)
            {
                blinking = 2;
                face_Blendshape.SetBlendShapeWeight(35, 100);
            }
            else
            {
                face_Blendshape.SetBlendShapeWeight(35, blinkingValue);
            }

        } else if (blinking == 2)
        {
            //transition to opening eyes
            blinkingValue -= Time.deltaTime * 600;
            if(blinkingValue< 0)
            {
                blinking = 0;
                face_Blendshape.SetBlendShapeWeight(35, 0);
            }
            else
            {
                face_Blendshape.SetBlendShapeWeight(35, blinkingValue);
            }

        }
    }
    public void ShowAnimation(string animID)
    {
        for(int i= 0; i< 60; i++)//resetting the face settings after every submission
        {
            if(i != 35)
            {
                face_Blendshape.SetBlendShapeWeight(i, 0);
            }
        }
        if (animID == "idle")
            //since theres 3 different idle animations...
        {
            if(Random.value < 0.3f)
            {
                anim.SetTrigger("idle1");
            } else if (Random.value < 0.6f)
            {
                anim.SetTrigger("idle2");
            }
            else
            {
                anim.SetTrigger("idle");
            }
            if (Random.value < 0.5f)
            {

                face_Blendshape.SetBlendShapeWeight(9, 100); //(index, %)
                //TIP: copy paramaeter from inspector and paste here to see the index of array for specififc face feature

            }
            else
            {
                face_Blendshape.SetBlendShapeWeight(51, 100); //(index, %)

                
            }
        }
        else if (animID == "shy")
   
        {
             anim.SetTrigger("shy");
            face_Blendshape.SetBlendShapeWeight(38, 100); //(index, %)

        }
        else if (animID == "confuse")

        {
            anim.SetTrigger("confuse");
            face_Blendshape.SetBlendShapeWeight(32, 100); //(index, %)

        }
        else if (animID == "joking")

        {
            anim.SetTrigger("joking");
            face_Blendshape.SetBlendShapeWeight(33, 100); //(index, %)

        }
        else if (animID == "worried")

        {
            anim.SetTrigger("worried");
            face_Blendshape.SetBlendShapeWeight(52, 100); //(index, %)

        }
        else if (animID == "surprise")

        {
            anim.SetTrigger("surprise");
            face_Blendshape.SetBlendShapeWeight(53, 100); //(index, %)


        }
        else if (animID == "focus")

        {
            anim.SetTrigger("focus");
            face_Blendshape.SetBlendShapeWeight(35, 50); //(index, %)


        }
        else if (animID == "angry")

        {
            anim.SetTrigger("angry");
            face_Blendshape.SetBlendShapeWeight(49, 100); //(index, %)

        }
        else if (animID == "cheers")

        {
            anim.SetTrigger("cheers");
            face_Blendshape.SetBlendShapeWeight(24, 100); //(index, %)

        }
        else if (animID == "nod")

        {
            anim.SetTrigger("nod");

        }
        else if (animID == "waving_arm")

        {
            anim.SetTrigger("waving_arm");
           

        }
        else if (animID == "proud")

        {
            anim.SetTrigger("proud");
            face_Blendshape.SetBlendShapeWeight(50, 100); //(index, %)

        }

    }

}
