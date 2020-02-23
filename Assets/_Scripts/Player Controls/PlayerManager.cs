using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Control;
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private AnkhController _ankhController;
    [SerializeField] private PlayerControllerEngine _playerController;
    [SerializeField] private GeneralSounds _soundManage;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private GameObject _sheildGFX;
    public GameObject sheildGFX => _sheildGFX;
    public GeneralSounds soundManage;
    private static PlayerManager _instance;
    public static PlayerManager instance => _instance;
    void Awake()
    {

        if (_instance == null)
        {

            _instance = this;
            // DontDestroyOnLoad(this.gameObject);

            //Rest of your Awake code

        }
        else
        {
            Destroy(this);
        }
    }
    public void TriggerColorWallAnimation()
    {
        _playerAnimator.SetBool("ColorWall", true);
        soundManage.playColorSound();
    }
    public void TriggerSpellAnimation()
    {
        string triggerName = "";
        PlayerManager.instance.soundManage.playGruntCharacterSound();
        switch (_ankhController.CurrentAnkhSpell.SpellType)
        {

            case SpellType.Manipulator:
                triggerName = "RotateSign";
                break;
            case SpellType.Death_Hole:
                triggerName = "HoleSign";
                break;
            case SpellType.Soul_Shifter:
                triggerName = "InvisibleSign";
                break;
            case SpellType.Creator:
                triggerName = "CreateSign";
                break;
            case SpellType.Telekinesis:
                triggerName = "TeleSign";
                break;
            default:
                break;
        }
        _playerAnimator.SetBool(triggerName, true);

    }

    public AnkhController CurrentAnkhController => _ankhController;
    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
