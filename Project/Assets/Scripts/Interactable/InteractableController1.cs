using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InteractableController1 : MonoBehaviour
{
    public Inventory inventory;
    public Transform camTransform;
    public float interactRange = 5f;
    public GameObject text;
    Animator anim;
    Torch torch;

    void Start()
    {
        torch = GameObject.Find("TorchObject").GetComponent<Torch>();
    }

    //Casts rays from the player and compares Tags to determine which objects are interactable and 
    //executes the specified action on interact
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(camTransform.position, camTransform.TransformDirection(Vector3.forward), out hit, interactRange))
        {
            if (hit.transform.gameObject.CompareTag("Door") || (hit.transform.gameObject.CompareTag("LockedDoor") && inventory.key.collected)
            || hit.transform.gameObject.CompareTag("Pedistal") || hit.transform.gameObject.CompareTag("Button")
            || hit.transform.gameObject.CompareTag("IceButton") || hit.transform.gameObject.CompareTag("Item")
            || hit.transform.gameObject.CompareTag("HammerButton") || (hit.transform.gameObject.CompareTag("FirePlace") && inventory.torch.collected)
            || hit.transform.gameObject.CompareTag("MapScrap")
            )
            {
                if(!text.activeSelf) text.SetActive(true);
            }
            else if(text.activeSelf) text.SetActive(false);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.transform.gameObject.CompareTag("Door"))
                {
                    anim = hit.transform.gameObject.GetComponent<Animator>();
                    anim.SetTrigger("OpenClose");
                }

                else if (hit.transform.gameObject.CompareTag("LockedDoor") && inventory.key.collected)
                {
                    anim = hit.transform.gameObject.GetComponent<Animator>();
                    anim.SetTrigger("OpenClose");
                }

                else if (hit.transform.gameObject.CompareTag("Pedistal"))
                {
                    Pedistal pedistal = hit.transform.parent.GetComponent<Pedistal>();
                    pedistal.Deactivate();
                }

                else if (hit.transform.gameObject.CompareTag("Button"))
                {
                    StoneButton stoneButton = hit.transform.gameObject.GetComponent<StoneButton>();
                    stoneButton.Push();
                }

                else if (hit.transform.gameObject.CompareTag("IceButton"))
                {
                    IcePuzzleButton icePuzzleButton = hit.transform.gameObject.GetComponent<IcePuzzleButton>();
                    icePuzzleButton.Push();
                }

                else  if (hit.transform.gameObject.CompareTag("Item"))
                {
                    Item item = hit.transform.gameObject.GetComponent<Item>();
                    item.ItemCollect();
                }

                else  if (hit.transform.gameObject.CompareTag("MapScrap"))
                {
                    MapScrap item = hit.transform.gameObject.GetComponent<MapScrap>();
                    item.MapScrapCollect();
                }


                else if (hit.transform.gameObject.CompareTag("HammerButton"))
                {
                    Button1Action btn = hit.transform.gameObject.GetComponent<Button1Action>();
                    btn.DoAction();
                }

                else if (hit.transform.gameObject.CompareTag("FirePlace"))
                {
                    torch.Ignite();
                }
            }

        }
        else {if(text.activeSelf) text.SetActive(false);}

    }
}
