using UnityEngine;

public class DropContainer : MonoBehaviour
{
    public static int score;
    public static int goal = 2;
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.name == "cargocontainer" && collision.transform.parent == null)
        {
            Destroy(collision.gameObject);
            score++;
        }
    }
}
