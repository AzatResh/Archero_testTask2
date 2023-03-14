using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;

    public void ShowGameOverMenu(){
        gameOverMenu.SetActive(true);
    }
}
