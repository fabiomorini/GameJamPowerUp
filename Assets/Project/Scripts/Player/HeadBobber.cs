using UnityEngine;

public class HeadBobber : MonoBehaviour
{
    public float walkingBobbingSpeed = 14f;
    [HideInInspector] public float currentWalkingBobbingSpeed = 0f;
    public float bobbingAmount = 0.05f;
    private CharacterControllerScript controller = null;

    float defaultPosY = 0;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosY = transform.localPosition.y;
        controller = GetComponentInParent<CharacterControllerScript>();
        currentWalkingBobbingSpeed = walkingBobbingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isMoving)
        {
            //Player is moving
            timer += Time.deltaTime * walkingBobbingSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
        }
        else
        {
            //Idle
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed), transform.localPosition.z);
        }
    }
}
