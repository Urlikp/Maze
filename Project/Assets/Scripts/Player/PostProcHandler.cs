using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class PostProcHandler : MonoBehaviour
{
    public float walkingFOV = 70f;
    public float sprintDistort = -30f;
    float sprintingFOV;
    PlayerMovement playerMovement;
    Camera mainCamera;
    PostProcessVolume postVolume;
    LensDistortion ld;
    ColorGrading cg;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        postVolume = GameObject.Find("Main Camera").GetComponent<PostProcessVolume>();
        if(!postVolume) print("Oof");
        sprintingFOV = walkingFOV - 5f;
        ld = postVolume.profile.GetSetting<LensDistortion>();   
        cg = postVolume.profile.GetSetting<ColorGrading>();   
    }

    //Applies various camera effects on certain actions
    void FixedUpdate()
    {
        //Blue filter when under water
        if(playerMovement.isDrowning)  cg.temperature.value = -70f;
        else cg.temperature.value = 10;

        //Lens distrortion and smaller FOV when sprinting
        if (playerMovement.isSprinting) 
        {
            if(ld.intensity.value > sprintDistort)
            {
                ld.intensity.value -= 1.5f;
            }
            if(mainCamera.fieldOfView > sprintingFOV) mainCamera.fieldOfView -= 0.25f;
        }  
        else
        {
            if(mainCamera.fieldOfView < walkingFOV) mainCamera.fieldOfView += 0.25f;
            if(ld.intensity.value < 0)
            {
                ld.intensity.value += 1.5f;
            }
        }
    }
}
