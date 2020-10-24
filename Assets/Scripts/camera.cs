using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float mousesenstivity = 0f;
    float m_rotationY = 0.01f;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("MainCharacter").transform;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
    private void Rotation()
    {
        m_rotationY = Input.GetAxis("Mouse X") * mousesenstivity * Time.deltaTime;

        player.Rotate(Vector3.up * m_rotationY);
    }
    public Vector3 getforwardvector()
    {
        Quaternion roty = Quaternion.Euler(0, m_rotationY, 0);
        return roty * Vector3.forward;
    }
}
