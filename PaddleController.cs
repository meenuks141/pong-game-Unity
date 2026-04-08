

using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 8f;
    public float limit = 2.2f; // boundary limit

    void Update()
    {
        float move = Input.GetAxis("Vertical");
        Vector3 pos = transform.position;

        pos.y += move * speed * Time.deltaTime;

        // Clamp position
        pos.y = Mathf.Clamp(pos.y, -limit, limit);

        transform.position = pos;
    }
}