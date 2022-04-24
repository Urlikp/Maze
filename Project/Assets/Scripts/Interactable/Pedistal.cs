using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedistal : MonoBehaviour
{
    public bool active = true;
    public ParticleSystem fire;
    public ParticleSystem smoke;
    public MainRiddleDoor mainRiddleDoor;
    public GameObject pointLight;
    public ItemPedistal itemPedistal;


    //Deactivates pedistal fire
    public void Deactivate() 
    {
        if (active) 
        {
            active = false;
            fire.Stop();
            smoke.Stop();
            mainRiddleDoor.riddlesSolved++;
            pointLight.SetActive(false);

            itemPedistal.smoke.Play();
            itemPedistal.fire.Play();
            itemPedistal.pointLight.SetActive(true);
        }
       
    }
}
