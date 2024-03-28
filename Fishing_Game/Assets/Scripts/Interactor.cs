using System.Collections;
using UnityEngine;
using TMPro;

interface IInteractable
{
    void Interact();
    string GetInteractionText();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorTansform;
    public float InteractRange;
    public TextMeshProUGUI interactionText;
    private bool isWaiting = false;
    private Coroutine interactionCoroutine;
    public Canvas Canvass;

    [HideInInspector]
    public bool isHovering = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isWaiting) //als hij niet aan het wachten is doe de interaction coroutine
            {
                interactionCoroutine = StartCoroutine(WaitAndInteract(0.5f));
            }
        }
        UpdateUI(); // is alleen een functie om de update leesbaar te houden
    }
    /// <summary>
    /// Roept Interaction functie op interactObj als isWaiting false is en je naar een interactable object kijkt en op E drukt
    /// </summary>
    /// <param name="waitTime">Hoelang je wacht totdat je weer kan interacten met een object</param>
    /// <returns></returns>
    IEnumerator WaitAndInteract(float waitTime)
    {
        isWaiting = true;

        Ray ray = new Ray(InteractorTansform.position, InteractorTansform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.Interact();
            }
        }
        yield return new WaitForSeconds(waitTime);

        isWaiting = false;
    }

    void UpdateUI() // Laar de interaction tekst zien van het geraakte interactable object
    {
        if (interactionText != null)
        {
            Ray ray = new Ray(InteractorTansform.position, InteractorTansform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    isHovering = true;
                    interactionText.text = interactObj.GetInteractionText();
                    Vector3 direction = hitInfo.point - transform.position;
                    Canvass.transform.position = hitInfo.point - direction.normalized * Vector3.Distance(transform.position, hitInfo.point) / 2;
                    Canvass.transform.rotation = Quaternion.LookRotation(-direction);
                    interactionText.gameObject.SetActive(true);
                }
                else
                {
                    interactionText.gameObject.SetActive(false);
                    isHovering = false;

                }
            }
            else
            {
                interactionText.gameObject.SetActive(false);
                isHovering = false;

            }
        }
        else 
        {
            Debug.Log("Tektst doet raar");
        }
    }

    private void OnDestroy()
    {
        if (interactionCoroutine != null)
        {
            StopCoroutine(interactionCoroutine);
        }
    }
}
