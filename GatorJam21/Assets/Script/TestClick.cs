using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestClick : MonoBehaviour
{
    public void onClick()
    {
        SceneManager.LoadScene(1);
    }
}
