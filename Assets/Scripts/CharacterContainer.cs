using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class CharacterContainer : MonoBehaviour
{
    [SerializeField] public List<CharacterController> Characters { get; protected set; } = new List<CharacterController>();
    private int _characterCount;
    public int RemainingHumans;

    UnityEvent m_CountChange;

    private void OnValidate()
    {
        Characters = GetComponentsInChildren<CharacterController>().ToList();
        _characterCount = Characters.Count;
    }

    private void Start()
    {
        if (m_CountChange == null)
            m_CountChange = new UnityEvent();

        m_CountChange.AddListener(CountHumans);

        m_CountChange.Invoke();
    }

    private void Update()
    {
        //for debug purposes
        if (Input.GetMouseButtonDown(2))
        {
            m_CountChange.Invoke();
        }

    }

    public void CountHumans()
    {
        RemainingHumans = 0;
        foreach (CharacterController c in Characters)
        {
            if (c.IsZombie == false) RemainingHumans++;
        }
        _characterCount = Characters.Count;

        Debug.Log($"{RemainingHumans} humans remain out of {_characterCount} characters!");
    }
}
