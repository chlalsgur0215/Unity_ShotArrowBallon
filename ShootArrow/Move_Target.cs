using UnityEngine;

public class Move_Target : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0.005f, 0);
        if (transform.position.y > 30.0f)
        {
            Destroy(gameObject);
        }
        
        
    }
}
