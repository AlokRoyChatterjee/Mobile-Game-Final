using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Door2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        SceneManager.LoadScene("Hard Level");
    }
}
