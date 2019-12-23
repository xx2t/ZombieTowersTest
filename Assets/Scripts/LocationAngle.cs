using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LocationAngle : MonoBehaviour
{
    Transform planet;
    public string cityName;
    TextMeshPro displayText;
    public int load;

    void Start(){
        planet=GameObject.Find("Planet").transform;
        displayText=this.transform.GetChild(0).GetComponent<TextMeshPro>();
        this.transform.LookAt(planet);
        this.GetComponent<MeshRenderer>().enabled=false;
        displayText.text=cityName;
        displayText.gameObject.SetActive(false);
    }
    void OnMouseOver(){
        displayText.gameObject.SetActive(true);
        if(Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene(load);
        }
    }
    void OnMouseExit(){
        displayText.gameObject.SetActive(false);
    }
}
