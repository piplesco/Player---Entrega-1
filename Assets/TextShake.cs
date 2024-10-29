using UnityEngine;

public class TextShake : MonoBehaviour
{
    public Transform player;
    public float shakeAmount = 2f; 

    private Vector3 originalPosition;

    void Start()
    {
        
        originalPosition = transform.localPosition;
    }

    void Update()
    {
       
        if (IsPlayerWalking())
        {
            Vector3 shakePosition = originalPosition + (Vector3)Random.insideUnitCircle * shakeAmount;
            transform.localPosition = shakePosition;
        }
        else
        {
           
            transform.localPosition = originalPosition;
        }
    }

    private bool IsPlayerWalking()
    {
       
        return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
    }
}