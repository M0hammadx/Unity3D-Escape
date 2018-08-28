using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turningWheelCS : MonoBehaviour
{
    public int currentNumber = 0;
    public float turnSpeed = 200;
    public bool canActive = true;
    public enum AXIS
    {
        X, Y, Z
    }
    public AXIS axis = AXIS.Z;
    public int rotDir = 1;
    // Use this for initialization
    void Start()
    {

    }
    void Activate()
    {
        if (!canActive) return;
        GetComponent<AudioSource>().Play();
        if (currentNumber < 9)
        {
            currentNumber++;
        }
        else
        {
            currentNumber = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (axis == AXIS.X)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(currentNumber * 36 * rotDir, 0, 0), turnSpeed * Time.deltaTime);
        }
        else if (axis == AXIS.Y)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0, currentNumber * 36 * rotDir, 0), turnSpeed * Time.deltaTime);
        }
        else
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0, 0, currentNumber * 36 * rotDir), turnSpeed * Time.deltaTime);
        }
    }
}
