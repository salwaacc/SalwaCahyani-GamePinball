using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CreditUIController : MonoBehaviour
{
    public Button exitButton;

  private void Start()
  {

    exitButton.onClick.AddListener(ExitGame);
  }

  private void ExitGame()
  {
    SceneManager.LoadScene("CreditScene");
  }
}
