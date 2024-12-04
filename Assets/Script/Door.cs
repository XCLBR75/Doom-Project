using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnim;
    public GameObject areaToSpawn;
    public bool requiresKey;
    public bool reqRed, reqBlue, reqGreen;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (requiresKey)
            {
                if((reqRed && other.GetComponent<PlayerInventory>().hasRed)
                || (reqBlue && other.GetComponent<PlayerInventory>().hasBlue)
                || (reqGreen && other.GetComponent<PlayerInventory>().hasGreen))
                {
                    doorAnim.SetTrigger("OpenDoor");
                    areaToSpawn.SetActive(true);
                }

            } 
            else 
            {
                doorAnim.SetTrigger("OpenDoor");
                areaToSpawn.SetActive(true);
            }
        }
    }

}
