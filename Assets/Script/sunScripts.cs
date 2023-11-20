
using UnityEngine;

public class sunScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public float dropToYPos;

    private float speed = .15f;

    
    

    void Start()
    {
        //transform.position = new Vector3(Random.Range(-7.44f, 7.44f), 6, 0);
        //dropToYPos = Random.Range( 1f, - 3.5f);
        // xóa cái gameObject khi sinh ra sau bao nhiêu giây tùy random từ khoảng 15s - 20s
        Destroy(gameObject, Random.Range(15f, 20f));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > dropToYPos)
            transform.position -= new Vector3(0, speed * Time.fixedDeltaTime, 0);
    }
}
