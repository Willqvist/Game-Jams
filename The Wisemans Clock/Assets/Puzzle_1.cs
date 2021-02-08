using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_1 : MonoBehaviour
{
    private static Puzzle_1 instance;
    public static Puzzle_1 Instance => instance;
    public GameObject[] nuts;

    public AudioSource move, place;
    
    private GameObject nut_1;
    private GameObject nut_2;

    private Vector3 original_1;
    private Vector3 original_2;

    private Vector3 wew_1;
    private Vector3 wew_2;

    private int index_1;
    private int index_2;

    private bool isSwapping = false;
    private float swap_timer = 1f;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        if(!isSwapping)
        {
            return;
        }

        swap_timer -= Time.deltaTime;

        if(swap_timer > 0.5f && swap_timer <= 1f)
        {
            Vector3 temp = nut_2.GetComponent<InteractorShower>().origin.transform.position;
            nut_2.GetComponent<NutSwap>().LerpToPosition(wew_1);
            nut_1.GetComponent<NutSwap>().LerpToPosition(wew_2);
        }

        if(swap_timer > 0f && swap_timer < 0.5f)
        {
            nut_2.GetComponent<NutSwap>().LerpToPosition(original_1);
            nut_1.GetComponent<NutSwap>().LerpToPosition(original_2);
        }

        if(swap_timer <= 0)
        {
            isSwapping = false;
            swap_timer = 1f;

            foreach (var n in nuts)
            {
                n.GetComponent<InteractorShower>().enabled = true;
            }


            var temp = this.nuts[index_2];
            this.nuts[index_2] = this.nuts[index_1];
            this.nuts[index_1] = temp;

            nut_1 = null;
            nut_2 = null;
            index_1 = 0;
            index_2 = 0;
        }
    }

    public void OnNutSelect(GameObject nut)
    {
        move.Play();
        if(isSwapping)
        {
            return;
        }

        if (nut_1 == null)
        {
            nut_1 = nut;
            original_1 = nut.transform.position;
            nut_1.GetComponent<NutSwap>().LerpToPosition(nut_1.GetComponent<InteractorShower>().origin.transform.position);
            wew_1 = nut_1.GetComponent<InteractorShower>().origin.transform.position;
            foreach(var n in nuts)
            {
                if(n.name == nut_1.name)
                {
                    break;
                }
                this.index_1++;
            }
        }
        else
        {
            if(nut == nut_1)
            {
                return;
            }
            foreach (var n in nuts)
            {
                n.GetComponent<InteractorShower>().enabled = false;
            }

            original_2 = nut.transform.position;

            nut.GetComponent<NutSwap>().LerpToPosition(nut.GetComponent<InteractorShower>().origin.transform.position);

            isSwapping = true;
            place.Play();
            nut_2 = nut;
            wew_2 = nut.GetComponent<InteractorShower>().origin.transform.position;
            foreach (var n in nuts)
            {
                if (n.name == nut_2.name)
                {
                    break;
                }
                this.index_2++;
            }
        }
    }
}
