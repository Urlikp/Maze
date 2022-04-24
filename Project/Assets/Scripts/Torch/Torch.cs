using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public GameObject torchLight;
    public Item torch;
    private GameObject pointLight;
    private ParticleSystem fire, smoke;
    public bool _extinguished = false;

    // Set some variables and make torch invisible
    void Start()
    {
        torchLight = transform.GetChild(0).gameObject;
        pointLight = torchLight.transform.GetChild(0).gameObject;
        fire = torchLight.transform.GetChild(1).GetComponent<ParticleSystem>();
        smoke = torchLight.transform.GetChild(2).GetComponent<ParticleSystem>();

        torchLight.SetActive(false);
    }

    // Equip/Unequip torch
    public void SetTorchLight()
    {
        torchLight.SetActive(!torchLight.activeSelf);
        if (_extinguished)
        {
            Extinguish();
        }
    }

    // Extinguish torch
    public void Extinguish()
    {
        if(torch.collected)
        {
            pointLight.SetActive(false);
            fire.Stop();
            smoke.Stop();
            _extinguished = true;
        }
    }

    // Ignite torch
    public void Ignite()
    {
        if(torch.collected)
        {
            torchLight.SetActive(true);
            pointLight.SetActive(true);
            fire.Play();
            smoke.Play();
            _extinguished = false;
        }
    }
}
