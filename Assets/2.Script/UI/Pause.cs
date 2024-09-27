using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Pause : MonoBehaviour
{
    [Header("UI")]
    [field: SerializeField]
    private GameObject pauseUI;
    private bool UIopened;
    public void PauseBtnClicked()
    {
        if (UIopened)
        {
            closeUI();
            UIopened = false;
        }
        else
        {
            openUI();
            UIopened = true;
        }
    }

    private void openUI()
    {
        pauseUI.SetActive(true);
    }

    private void closeUI()
    {
        pauseUI.SetActive(false);
    }
}
