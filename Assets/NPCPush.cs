using UnityEngine;
using System.Collections;

public class NPCPush : MonoBehaviour
{
    public GameObject[] NPC;
    public Transform NPCParent;
    void Start()
    {
        NPCParent = this.gameObject.transform;
        if (Random.Range(0, 10) == 0)
        {
            InstantiateNPC();
        }
    }

    void InstantiateNPC()
    {
        int NPCNumber= Random.Range(0, NPC.Length);
        GameObject NPCObject = Instantiate(NPC[NPCNumber]);
        NPCObject.transform.position = new Vector3((NPCParent.position.x + Random.Range(10, 20)), 2, (NPCParent.position.z + Random.Range(10, 20)));
        NPCObject.transform.localScale = new Vector3(8, 8, 8);
        Animator animator = NPCObject.GetComponent<Animator>();
        animator.SetBool("IsWalk", false);
        animator.SetBool("Set", true);
    }

}
