using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Door : MonoBehaviour
{
    public string nextScene; 

    private void OnTriggerEnter2D(Collider2D other){
        SceneManager.LoadScene(nextScene);
    }
}
