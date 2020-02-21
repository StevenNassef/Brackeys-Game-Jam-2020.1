using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekanisisCubeController : MonoBehaviour
{
    [SerializeField] GameObject dummyCube;
    [SerializeField] TelekanisiDummyCube dummyCubeController;
    void Start()
    {
        dummyCubeController = dummyCube.GetComponent<TelekanisiDummyCube>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MouseUpFromCube()
    {
        if(dummyCubeController.isSafe)
        {
            transform.position = dummyCube.transform.position;
        }
        dummyCube.SetActive(false);
        dummyCube.transform.position = transform.position;
    }

    public void MouseDownOnCube()
    {
        dummyCube.SetActive(true);
    }

}
