using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    GameObject InfoLogo;
    [SerializeField]
    GameObject TutorialPanel;
    [SerializeField]
    GameObject[] Tips;
    [SerializeField]
    GameObject PreviousArrow;
    [SerializeField]
    GameObject NextArrow;

    private int currentTip;
    private bool IsTutActive;

    public void ShowPanel()
    {
        IsTutActive = true;
        TutorialPanel.SetActive(true);
        InfoLogo.SetActive(false);
        currentTip = 0;
        ActivateTip(currentTip);
    }

    public void HidePanel()
    {
        TutorialPanel.SetActive(false);
        InfoLogo.SetActive(true);
        IsTutActive = false; 
    }

    private void ActivateTip(int x)
    {
        for(int i = 0; i < Tips.Length; i++)
        {
            Tips[i].SetActive(false);
        }

        Tips[x].SetActive(true);

        if(x == 0)
        {
            PreviousArrow.SetActive(false);
        }
        else
        {
            PreviousArrow.SetActive(true);
        }

        if (x == Tips.Length-1)
        {
            NextArrow.SetActive(false);
        }
        else
        {
            NextArrow.SetActive(true);
        }
    }

    public void GetNextTip()
    {
        currentTip++;
        ActivateTip(currentTip);
    }
    public void GetPrevTip()
    {
        currentTip--;
        ActivateTip(currentTip);
    }



}
