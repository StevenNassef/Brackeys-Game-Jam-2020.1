using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorWheelManager : MonoBehaviour
{

    // public enum SpellType {
    //     Yellow, Green, Blue, Purple, Red, NoColor = -1
    // }

    public GameObject colorWheelObject;
    public Animator animator;
    public bool canActivate = true;
    public float xScale;
    public float yScale;
    
    public float initXScale;
    public float initYScale;

    private bool activated;

    private Spell selectedSpell;
    [SerializeField] private List<Spell> spellList;

    // Update is called once per frame
    void Update()
    {
        
        if(!activated) {
            if(canActivate && Input.GetKeyDown(KeyCode.Mouse0)) {
                ActivateWheel();
            }
        } else {
        // TODO make it scale up up to specific point  
        }

        
        if(Input.GetKeyUp(KeyCode.Mouse0)) {
            DeactivateWheel();
            Debug.Log("Color wheel deactivated");
        }
        
    }

    void ActivateWheel() {
        activated = true;
        Vector3 currentMousePosition = Input.mousePosition;
        transform.position = currentMousePosition;
        colorWheelObject.SetActive(true);
    }

    void DeactivateWheel() {
        activated = false;
        animator.SetTrigger("Close");
        colorWheelObject.SetActive(false);
        PlayerManager.instance.CurrentAnkhController.SetAnkhSpell(selectedSpell);
        // StartCoroutine("OnCompleteCloseWheelAnimation");
    }
    
    // IEnumerator OnCompleteCloseWheelAnimation()
    // {
    //     while(animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
    //         yield return null;
    //     colorWheelObject.SetActive(false);
    // }

    public void SelectColor(int colorNum) {
        if(activated) {
            selectedSpell = spellList[colorNum];
        }
        Debug.Log("Selected Color is " + selectedSpell);
    }

}
