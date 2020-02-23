using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class HoleController : MonoBehaviour
{
    [SerializeField] private VisualEffect spellEffect;
    [SerializeField] private Spell _currentSpell;
    public Spell currentSpell => _currentSpell;
    private Animator animator;
    private Vector3 initialPosition;
    private Vector3 initialScale;
    void Start()
    {

        animator = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        initialPosition = transform.position;
        initialScale = transform.localScale;
        PlayerManager.instance.soundManage.playPortalSound();
        spellEffect.SetVector4("Color", currentSpell.SpellColor);
    }

    public void DisableObject()
    {
        StartCoroutine(OnCompleteCloseHoleAnimation());
    }
    IEnumerator OnCompleteCloseHoleAnimation()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }
        transform.position = initialPosition;
        transform.localScale = initialScale;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
