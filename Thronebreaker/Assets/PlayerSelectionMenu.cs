using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PlayerSelectionMenu : MonoBehaviour
{
    public TextMeshProUGUI[] optionsText;
    public Transform[] optionsTransform;
    public GameObject selectionMenuMarker;
    [SerializeField] private PartyMemberUnit currentlySelectedUnit;
    public BattleManager battleManager;

    public void Start()
    {
        battleManager = FindObjectOfType<BattleManager>();
        selectionMenuMarker.transform.position = optionsTransform[0].position;
    }

    public void UpdateMarkerPosition(int i)
    {
        selectionMenuMarker.transform.position = optionsTransform[i].position;
    }

    public void SetCurrentUnit(PartyMemberUnit currentUnit)
    {
        currentlySelectedUnit = currentUnit;
    }
    int selection = 0;
    public IEnumerator SelectAction()
    {
        bool playerHasSelected = false;

        while (!playerHasSelected)
        {
            // Allow the player to move the marker between characters using -> and -<
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Debug.Log("UP ARROW KEY PRESSED");

                // Up movement
                if (selection == 0)
                {
                    selection = 3;
                    UpdateMarkerPosition(selection);
                }
                else
                {
                    selection--;
                    UpdateMarkerPosition(selection);
                }
            }

            // For each time the player is over a new party member, move the marker
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("DOWN ARROW KEY PRESSED");

                // Down movement
                if (selection == 3)
                {
                    selection = 0;
                    UpdateMarkerPosition(selection);
                }
                else
                {
                    selection++;
                    UpdateMarkerPosition(selection);
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                battleManager.currentActionIndex = selection;
                playerHasSelected = true;
                // Do action
            }

            yield return null;
        }

        this.gameObject.SetActive(false);
    }
}
