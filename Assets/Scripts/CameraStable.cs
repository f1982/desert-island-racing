using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStable : MonoBehaviour
{
    public GameObject TheCar;
    public float carX;
    public float carY;
    public float carZ;


    void Start()
    {
        carX = 0;
    }
    // Update is called once per frame
    void Update()
    {
        carX = TheCar.transform.eulerAngles.x;
        carY = TheCar.transform.eulerAngles.y;
        carZ = TheCar.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(carX - carX, carY, carZ - carZ);
    }
}
