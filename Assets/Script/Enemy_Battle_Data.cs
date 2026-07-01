using UnityEngine;

public class Enemy_Battle_Data : MonoBehaviour
{
    public EnemyType enemyProfile;
    public float currenthealth;

    void Start()
    {
        currenthealth = enemyProfile.max_Health;
    }

    public void takeDMG(float DMGTaken)
    {
        currenthealth -= DMGTaken;
    }
}
