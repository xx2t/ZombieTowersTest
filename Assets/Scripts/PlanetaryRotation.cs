using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryRotation : MonoBehaviour
{
    float rotDeg;
    public float rotSpeed;
    public GameObject planet;
    bool down;
    float startClick;
    float currentClick;
    void Start(){
        planet=GameObject.Find("Planet");
    }
    void Update(){
        if(Input.GetMouseButtonDown(1)){
            startClick = Input.mousePosition.x;
            down=true;
        }
        if(down){
            currentClick=Input.mousePosition.x;
        }
        if(Input.GetMouseButtonUp(1)){
            down=false;
        }
    }
    void LateUpdate(){
        if(down){
            planet.transform.Rotate(0f,-(currentClick-startClick)*rotSpeed,0f,Space.Self);
        }
    }
}
