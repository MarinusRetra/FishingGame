using System.Collections;
using UnityEngine;
using TMPro;

interface IInteractable
{
    void Interact();
    string GetInteractionText(); // Add a method to get the interaction text
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorTansform;
    public float InteractRange;
    public TextMeshProUGUI interactionText;
    private bool isWaiting = false;
    private Coroutine interactionCoroutine;
    public Canvas Canvass;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isWaiting)
            {
                interactionCoroutine = StartCoroutine(WaitAndInteract(0.5f));
            }
        }

        UpdateUI(); // is alleen een functie om de update leesbaar te houden
    }

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

    void UpdateUI()
    {
        if (interactionText != null)
        {
            Ray ray = new Ray(InteractorTansform.position, InteractorTansform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactionText.text = interactObj.GetInteractionText();
                    Vector3 direction = hitInfo.point - transform.position;
                    Canvass.transform.position = hitInfo.point - direction.normalized * Vector3.Distance(transform.position, hitInfo.point) / 2;
                    Canvass.transform.rotation = Quaternion.LookRotation(-direction);
                    interactionText.gameObject.SetActive(true);
                }
                else
                {
                    interactionText.gameObject.SetActive(false);
                }
            }
            else
            {
                interactionText.gameObject.SetActive(false);
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
