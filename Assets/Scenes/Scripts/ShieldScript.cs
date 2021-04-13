using UnityEngine;

public class ShieldScript : MonoBehaviour
{

    [SerializeField] private float speed = 110;
    float yRotation = 0;
    float xRotation = 0;

    private void Update()
    {
        yRotation += Time.deltaTime * speed;
        xRotation += Time.deltaTime * speed;
        
        this.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
