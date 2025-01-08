using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Occlusionmask : MonoBehaviour
{
    public Camera Cam;
    private RaycastHit[] Hits;
    public LayerMask LayerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OcclusionMask();
    }

    private void OcclusionMask()
    {
        
        if (Physics.SphereCast(Cam.transform.position, 2, Cam.transform.forward, out RaycastHit Hits, 100, LayerMask)) 
        { 
            Hits.transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        
        else
        {
            Hits.transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

}
