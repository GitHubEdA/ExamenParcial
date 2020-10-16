using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearZombie : MonoBehaviour
{
    public GameObject zombie;
    private Transform _transform;
    private int a = 0;
    private int b = 500;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        while (a < 1)
        {
            Instantiate(zombie, _transform.position, Quaternion.identity);
            a++;
        }
        b++;
        if (b > 5000)
        {
            a = 0;
            b = 0;
        }
    }
}
