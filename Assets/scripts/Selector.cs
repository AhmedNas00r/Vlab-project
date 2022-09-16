﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField] Camera FPCam;
    RaycastHit lastHit;
    Color lastColor;
    bool isLastHit;
    void Update()
    {
        Select();
        LookAtSelect();
    }

    private void LookAtSelect() {
        RaycastHit hit;
        if (Physics.Raycast(FPCam.transform.position, FPCam.transform.forward, out hit)) {
            Debug.Log(hit.transform.name);
            if (hit.transform.CompareTag("Select")) {
                lastHit = hit;
                MeshRenderer renderer = hit.transform.GetComponent<MeshRenderer>();
                if (!isLastHit) {
                    lastColor = renderer.material.color;
                    isLastHit = true;
                    renderer.material.color = Color.red;
                                        
                }
            } else if (isLastHit) {
                isLastHit = false;
                MeshRenderer renderer = lastHit.transform.GetComponent<MeshRenderer>();
                renderer.material.color = lastColor;
            }
        }
    }

    private void Select() {
        if (Input.GetButtonDown("Fire1")) {
        Debug.Log("Down");
        RaycastHit hit;
        if (Physics.Raycast(FPCam.transform.position, FPCam.transform.forward, out hit)) {
            if (hit.transform.CompareTag("Select")) {
                // lastHit = hit;
                // MeshRenderer renderer = hit.transform.GetComponent<MeshRenderer>();
                // if (!isLastHit) {
                //     // lastColor = renderer.material.color;
                //     isLastHit = true;
                //     renderer.material.color = Color.black;
                // } 
                //TODO: Canvass set active   
            }
        }
            // } else if (isLastHit) {
            //     isLastHit = false;
            //     MeshRenderer renderer = lastHit.transform.GetComponent<MeshRenderer>();
            //     renderer.material.color = lastColor;
            // }
        }
    }
}
