using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossDoor : MonoBehaviour
{
    public SecondDoor SecondDoor;
    public ActualDoor ActualDoor;
    private bool firstTime = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (firstTime)
        {
            ActualDoor.ActualClose();
            SecondDoor.CloseDoor();
            firstTime = false;
        }
    }

    public void OpenDoor()
    {
        ActualDoor.ActualOpen();
    }
}
