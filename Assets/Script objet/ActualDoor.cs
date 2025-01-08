using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualDoor : MonoBehaviour
{
    public MeshRenderer DoorRenderer;
    public BoxCollider BoxCol;

    // Start is called before the first frame update
    void Start()
    {
        DoorRenderer = GetComponent<MeshRenderer>();
        BoxCol = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActualClose()
    {
        DoorRenderer.enabled = true;
        BoxCol.enabled = true;
        BoxCol.isTrigger = false;
    }

    public void ActualOpen()
    {
        DoorRenderer.enabled = false;
        BoxCol.isTrigger = true;
    }
}
