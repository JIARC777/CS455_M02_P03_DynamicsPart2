using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRandomTarget : MonoBehaviour
{
    public SheepList sheepList;
    int sheepRandomTargetIndex;
    public Kinematic aiController;
    // Start is called before the first frame update
    void Start()
    {
        aiController = this.GetComponent<Kinematic>();
    }
    void UpdateTarget()
    {
        // Request target and assign target to controller living on wolf
        sheepRandomTargetIndex = sheepList.AssignTarget();
        aiController.target = sheepList.sheepL[sheepRandomTargetIndex];
    }
    private void Update()
    {
        if (aiController.target == null)
        {
            // check for null target (destroyed incidently by another wolf) and request new target
            UpdateTarget();
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        //Checkk for collision tage and delete sheep. Update target if target was sheep destroyed
        if (collision.collider.tag == "Sheep")
        {
            int destroyedTarget = sheepList.sheepL.IndexOf(collision.gameObject);
            sheepList.DeleteSheep(collision.gameObject);
            if (destroyedTarget == sheepRandomTargetIndex)
                UpdateTarget();
            
        }
        
    }
}
