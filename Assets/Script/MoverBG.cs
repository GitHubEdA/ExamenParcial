using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBG : MonoBehaviour
{
    private Transform _transform;
    public GameObject Ninja;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Ninja.transform.position.x;
        var y = Ninja.transform.position.y;
        var z = _transform.position.z;

        _transform.position = new Vector3(x+9, y+2, z);
    }
}
