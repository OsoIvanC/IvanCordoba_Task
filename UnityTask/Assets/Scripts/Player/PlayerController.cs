using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field:SerializeField] public float PlayerSpeed {  get; private set; }
    [SerializeField] Animator animatorController;

    #region Private
        Vector2 moveDirection;
        float inputX;
        float inputY;
    #endregion
    private void Awake()
    {
        animatorController = GetComponent<Animator>();
    }
    private void Update()
    {
        #region CHARACTER_MOVEMENT
            inputX = Input.GetAxisRaw("Horizontal");
            inputY = Input.GetAxisRaw("Vertical");

            moveDirection = new Vector2(inputX, inputY);
            
            moveDirection.Normalize();
            
            if(moveDirection != Vector2.zero) 
                transform.Translate(moveDirection * PlayerSpeed * Time.deltaTime);
        #endregion

        #region CHARACTER_ANIMATIONS
            animatorController.SetFloat("MovementX", inputX);
            animatorController.SetFloat("MovementY", inputY);
        #endregion
    }
}
