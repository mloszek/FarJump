using UnityEngine;

public class RespawnScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            gameObject.transform.position = new Vector3(0, 502.1f, 0);
            //Instantiate(gameObject, new Vector3(0, 502.1f, 0), Quaternion.identity);
            //Destroy(this.gameObject);
        }
    }
}
