using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static event Action HandlePulled = delegate { };

    private AudioSource audioPlayer;

    [SerializeField]
    private Text prizeText; //texto da recompensa;

    [SerializeField]
    private Row[] rows; //representa a classe rows linha (slots)

    [SerializeField]
    private Transform handle; //cabo da maquina

    private int prizeValue;

    private bool resultsChecked; //verifica se os slots pararam

    void Start()
    {
        resultsChecked = false;
        audioPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped)
        {
            prizeValue = 0;
            prizeText.enabled = false;
            resultsChecked = false;
        }

        if(rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
        {
            CheckResults();
            prizeText.enabled = true;
            prizeText.text = "Prize "+ prizeValue;
        }
    }

    private void OnMouseDown()
    {
        if(rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped)
        {
            StartCoroutine("PullHandle");
        }
    }

    private IEnumerator PullHandle()
    {
        //animacao da alavanca
        for (int i = 0; i < 15; i+=5)
        {
            handle.Rotate(0f,0f,i);
            yield return new WaitForSeconds(0.01f);
        }

        audioPlayer.Play();
        HandlePulled();
        
         //animacao da alavanca
        for (int i = 0; i < 15; i+=5)
        {
            handle.Rotate(0f,0f,-i);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void CheckResults()
    {
        //tres iguais
        if (rows[0].stoppedSlot == "Greatball" && rows[1].stoppedSlot == "Greatball" && rows[2].stoppedSlot == "Greatball")
        {
            prizeValue = 200;
        } 
        else if (rows[0].stoppedSlot == "Revive" && rows[1].stoppedSlot == "Revive" && rows[2].stoppedSlot == "Revive")
        {
            prizeValue = 400;
        }
        else if (rows[0].stoppedSlot == "Oshawott" && rows[1].stoppedSlot == "Oshawott" && rows[2].stoppedSlot == "Oshawott")
        {
            prizeValue = 600;
        }
        else if (rows[0].stoppedSlot == "Leftovers" && rows[1].stoppedSlot == "Leftovers" && rows[2].stoppedSlot == "Leftovers")
        {
            prizeValue = 800;
        }
        else if (rows[0].stoppedSlot == "Potion" && rows[1].stoppedSlot == "Potion" && rows[2].stoppedSlot == "Potion")
        {
            prizeValue = 1500;
        }
        else if (rows[0].stoppedSlot == "Raichu" && rows[1].stoppedSlot == "Raichu" && rows[2].stoppedSlot == "Raichu")
        {
            prizeValue = 3000;
        }
        else if (rows[0].stoppedSlot == "Masterball" && rows[1].stoppedSlot == "Masterball" && rows[2].stoppedSlot == "Masterball")
        {
            prizeValue = 5000;
        }
        //dois iguais
        else if (
            rows[0].stoppedSlot == rows[1].stoppedSlot && rows[0].stoppedSlot == "Greatball" ||
            rows[0].stoppedSlot == rows[2].stoppedSlot && rows[0].stoppedSlot == "Greatball" ||
            rows[1].stoppedSlot == rows[2].stoppedSlot && rows[1].stoppedSlot == "Greatball"
            )
        {
            prizeValue = 100;
        }
        else if (
            rows[0].stoppedSlot == rows[1].stoppedSlot && rows[0].stoppedSlot == "Revive" ||
            rows[0].stoppedSlot == rows[2].stoppedSlot && rows[0].stoppedSlot == "Revive" ||
            rows[1].stoppedSlot == rows[2].stoppedSlot && rows[1].stoppedSlot == "Revive"
            )
        {
            prizeValue = 300;
        }
        else if (
            rows[0].stoppedSlot == rows[1].stoppedSlot && rows[0].stoppedSlot == "Oshawott" ||
            rows[0].stoppedSlot == rows[2].stoppedSlot && rows[0].stoppedSlot == "Oshawott" ||
            rows[1].stoppedSlot == rows[2].stoppedSlot && rows[1].stoppedSlot == "Oshawott"
            )
        {
            prizeValue = 500;
        }
        else if (
            rows[0].stoppedSlot == rows[1].stoppedSlot && rows[0].stoppedSlot == "Leftovers" ||
            rows[0].stoppedSlot == rows[2].stoppedSlot && rows[0].stoppedSlot == "Leftovers" ||
            rows[1].stoppedSlot == rows[2].stoppedSlot && rows[1].stoppedSlot == "Leftovers"
            )
        {
            prizeValue = 700;
        }
        else if (
            rows[0].stoppedSlot == rows[1].stoppedSlot && rows[0].stoppedSlot == "Potion" ||
            rows[0].stoppedSlot == rows[2].stoppedSlot && rows[0].stoppedSlot == "Potion" ||
            rows[1].stoppedSlot == rows[2].stoppedSlot && rows[1].stoppedSlot == "Potion"
            )
        {
            prizeValue = 1000;
        }
        else if (
            rows[0].stoppedSlot == rows[1].stoppedSlot && rows[0].stoppedSlot == "Raichu" ||
            rows[0].stoppedSlot == rows[2].stoppedSlot && rows[0].stoppedSlot == "Raichu" ||
            rows[1].stoppedSlot == rows[2].stoppedSlot && rows[1].stoppedSlot == "Raichu"
            )
        {
            prizeValue = 2000;
        }
        else if (
            rows[0].stoppedSlot == rows[1].stoppedSlot && rows[0].stoppedSlot == "Masterball" ||
            rows[0].stoppedSlot == rows[2].stoppedSlot && rows[0].stoppedSlot == "Masterball" ||
            rows[1].stoppedSlot == rows[2].stoppedSlot && rows[1].stoppedSlot == "Masterball"
            )
        {
            prizeValue = 4000;
        }
        resultsChecked = true;
    }
}
