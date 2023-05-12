using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Vector3 offset;
    public static float roty;
    public static Quaternion camerarot;
    [SerializeField]
    private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        transform.position=WallManager.startpositon();
        roty = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
        offset = transform.position - player.transform.position;
        if (Input.GetMouseButton(0))
        {
            roty-=0.4f;
            transform.Rotate(new Vector3(0, roty + offset.y,0 )*Time.deltaTime);
        }
        else if(Input.GetMouseButton(1))
        {
            roty+=0.4f;
            transform.Rotate(new Vector3(0, roty + offset.y, 0) * Time.deltaTime);
        }
        else
        {
            roty=0;
        }
    }

  public static Quaternion  CameraRotate()
    {
        return camerarot;
    }
}
