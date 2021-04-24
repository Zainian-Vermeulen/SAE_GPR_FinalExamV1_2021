using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class PlayerHud : MonoBehaviour
{
    [SerializeField] private SpellCastingController spellCastingController;
    [SerializeField] private DropCollector dropCollector;

    [SerializeField] private Image spellIcon;
    [SerializeField] private GameObject spellIcon2;
    [SerializeField] private Image spellImage2;

    [SerializeField] private TMPro.TMP_Text spellCooldownText;
    [SerializeField] private TMPro.TMP_Text spellCooldownText2;

    [SerializeField] private GameObject collectUIObject;
    [SerializeField] private Image spellInUse;

    private void Start()
    {
        Debug.Assert(spellCastingController != null, "SpellCastingController reference is null");
        Debug.Assert(dropCollector != null, "DropCollector reference is null");

        spellIcon.sprite = spellCastingController.SimpleAttackSpellDescription.SpellIcon;
        spellImage2.sprite = spellCastingController.SpecialAttackSpellDescription.SpellIcon;

        dropCollector.DropsInRangeChanged += OnDropsInRangeChanged;
        dropCollector.SpecialAbilityDrop += CollectSpecailAbility;
        
    }

    private void OnDropsInRangeChanged()
    {
        collectUIObject.SetActive(dropCollector.DropsInRangeCount > 0);
    }

    

    private void CollectSpecailAbility()
    {
        spellIcon2.SetActive(true);
        spellImage2.enabled = true;

    }

    private void GetCooldown()
    {
        float cooldown = spellCastingController.GetSimpleAttackCooldown();
        float cooldown2 = spellCastingController.GetSpecialAttackCooldown();


        if (cooldown > 0)
        {
            // spellInUse.enabled = false;

            spellCooldownText.text = cooldown.ToString("0.0");
            spellIcon.color = new Color(0.25f, 0.25f, 0.25f, 1);
            spellCooldownText.rectTransform.localScale.Set(1.0f, 1.0f, 1.0f);
        }
        else
        {
            //spellInUse.enabled = true;
            spellCooldownText.text = "";
            spellIcon.color = Color.white;
            spellCooldownText.rectTransform.localScale.Set(2.0f, 2.0f, 2.0f);

        }

        if (cooldown2 > 0)
        {
            spellCooldownText2.text = cooldown.ToString("0.0");
            spellImage2.color = new Color(0.25f, 0.25f, 0.25f, 1);
            spellCooldownText2.rectTransform.localScale.Set(1.0f, 1.0f, 1.0f);
        }
        else
        {
            spellCooldownText2.text = "";
            spellImage2.color = Color.white;
            spellCooldownText2.rectTransform.localScale.Set(2.0f, 2.0f, 2.0f);
        }
    }

    private void Update()
    {
        GetCooldown();
    }
}
