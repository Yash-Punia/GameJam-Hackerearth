using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float mousesenstivity = 100f;
    private float rotationX;
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
        float m_rotationY = Input.GetAxis("Mouse X") * mousesenstivity * Time.deltaTime;
        float m_rotationX = Input.GetAxis("Mouse Y") * mousesenstivity * Time.deltaTime;
        rotationX -= m_rotationX;
        rotationX = Mathf.Clamp(rotationX, -80f, 70f);
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        player.Rotate(Vector3.up * m_rotationY);
    }
}
