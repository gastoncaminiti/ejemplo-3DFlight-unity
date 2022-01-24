using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem; [IF USE INPUT SYSTEM PACKAGE]
public class PlayerControls : MonoBehaviour
{
    //[SerializeField] InputAction movement; [IF USE INPUT SYSTEM PACKAGES]
    [SerializeField] float shipSpeed = 30f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;
    // Start is called before the first frame update
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f;

    [SerializeField] float positionYawFactor = 2f;

    [SerializeField] float controlRollFactor = -20f;

    float horizontalThrow, verticalThrow;
    void Start()
    {
        
    }
    /* [IF USE INPUT SYSTEM PACKAGE]
    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }
    */

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        
    }
    private void ProcessRotation()
    {
        float positionPitch = transform.localPosition.y * positionPitchFactor;
        float controlPitch = verticalThrow * controlPitchFactor;

        float pitch = positionPitch + controlPitch;
        float yaw   = transform.localPosition.x * positionYawFactor;
        float roll  = horizontalThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    private void ProcessTranslation()
    {
        horizontalThrow = Input.GetAxis("Horizontal");
        verticalThrow = Input.GetAxis("Vertical");
        float xOffset = horizontalThrow * Time.deltaTime * shipSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = verticalThrow * Time.deltaTime * shipSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);
        transform.localPosition = new Vector3(
                                    clampedXPos,
                                    clampedYPos,
                                    transform.localPosition.z
                                    );

        /* IF INPUT SYSTEM PACKAGE
        float horizontalThrow = movement.ReadValue<Vector2>().x;
        float verticalThrow = movement.ReadValue<Vector2>().y;
        Debug.Log(horizontalThrow);
        Debug.Log(verticalThrow);
        */
    }
}
