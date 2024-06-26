using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Camera playerCame;
    public List<SpellContainer> spells = new List<SpellContainer>();
    public GameObject spellCastPoint;
    private Animator animator;
    private bool spellAniamtion = false;
    public bool throwSpell=false;
    public LayerMask mouseInputIgnoreLayers;
    public SpellPrefab spell;
    public float playerSpeed = 5;
    private Vector3 spellMousePos = Vector3.zero;
    public bool groundhit;
    public PlayerManaManager playerManaManager;
    public float damage;
    public GameObject Abilitys;
    public SpellPrefab defaultSpell;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
        navMeshAgent.speed = playerSpeed;
        Abilitys.transform.GetChild(0).GetComponent<Image>().sprite = defaultSpell.image;
        Abilitys.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = defaultSpell.manaCost.ToString();
        spells.Add(new SpellContainer(defaultSpell, KeyCode.Q));
    }
    void Update()
    {

        Vector3 mouseWorldPos=Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ~mouseInputIgnoreLayers))
        {
            mouseWorldPos = hit.point;
            groundhit = true;
            if (Input.GetMouseButton(0) && spellAniamtion == false)
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.destination = hit.point;
            }
        }
        else {
            groundhit = false;
        }
        if (navMeshAgent.remainingDistance < 0.1)
        {
            animator.SetBool("WalkingPlayer", false);
        }
        else
        {
            animator.SetBool("WalkingPlayer", true);
        }

        foreach(SpellContainer spellContainer in spells)
        {
            if(spellAniamtion == false)
            {
                SpellPrefab spell = spellContainer.spellPrefab;
                if (Input.GetKeyDown(spellContainer.inputKey)&& playerManaManager.TryUseMana(spell.manaCost))
                {
                    this.spell = spell;
                    StartAttacke(mouseWorldPos);
                }
            }
        }  
        if (throwSpell)
        {
            if (spell.spellCastType == SpellCastType.PlayerPos)
            {
                GameObject go = Instantiate(spell.prefab, transform.position+spell.spawmPosition, transform.rotation*Quaternion.Euler(spell.spawmRotation));
                go.GetComponent<SpellDamage>().Damage += damage;
                throwSpell = false;
                spellAniamtion = false;
            }
            if (spell.spellCastType == SpellCastType.ThrowPos)
            {
                GameObject go =Instantiate(spell.prefab, spellCastPoint.transform.position + spell.spawmPosition, transform.rotation * Quaternion.Euler(spell.spawmRotation));
                go.GetComponent<SpellDamage>().Damage += damage;
                throwSpell = false;
                spellAniamtion = false;
            }
            if (spell.spellCastType == SpellCastType.MousePos)
            {
                GameObject go = Instantiate(spell.prefab, spellMousePos + spell.spawmPosition, transform.rotation * Quaternion.Euler(spell.spawmRotation));
                go.GetComponent<SpellDamage>().Damage += damage;
                throwSpell = false;
                spellAniamtion = false;
            }
        }
    }

    public void StartAttacke(Vector3 mouseWorldPos)
    {
        spellAniamtion = true;
        navMeshAgent.destination = transform.position;
        navMeshAgent.isStopped = true;
        animator.SetBool("Throwing", true);
        animator.SetBool("WalkingPlayer", false);
        Vector3 lookPos = mouseWorldPos - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = rotation;
        spellMousePos = mouseWorldPos;
    }

    public void AddSpell(SpellPrefab spellPrefab)
    {
        KeyCode keyCode;
        Abilitys.transform.GetChild(spells.Count).GetComponent<Image>().sprite = spellPrefab.image;
        Abilitys.transform.GetChild(spells.Count).GetChild(0).GetComponent<TMP_Text>().text = spellPrefab.manaCost.ToString();
        Abilitys.transform.GetChild(spells.Count).gameObject.SetActive(true);
        if (spells.Count == 1)
        {
            keyCode = KeyCode.W;
        }
        else
        {
            keyCode = KeyCode.E;
        }
        spells.Add(new SpellContainer(spellPrefab,keyCode));
    }

    public void AddSpellUpgrade(int spellid, skillUpgrade skillUpgrade)
    {
        foreach(SpellContainer spell in spells)
        {
            if(spell.spellPrefab.spellid== spellid)
            {
                spell.upgrades.Add(skillUpgrade);
            }
        }
    }
}