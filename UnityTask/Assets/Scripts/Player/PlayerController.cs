using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field:SerializeField] public float PlayerSpeed {  get; private set; }
    [SerializeField] Animator animatorController;
    [SerializeField] GameObject inventoryUI;

    #region Private
        Vector2 moveDirection;
        Vector2 lastDirection;
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
            {
                lastDirection = moveDirection;
                transform.Translate(moveDirection * PlayerSpeed * Time.deltaTime);
            }
        #endregion

        #region CHARACTER_ANIMATIONS
            animatorController.SetFloat("MovementX", inputX);
            animatorController.SetFloat("MovementY", inputY);
            animatorController.SetFloat("LastX", lastDirection.x);
            animatorController.SetFloat("LastY", lastDirection.y);
        #endregion

        #region CHARACTER_ACTIONS
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
        #endregion  
    }

    
}
