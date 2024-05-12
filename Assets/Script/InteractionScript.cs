using UnityEngine;

public class InteractionScript : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        // Eðer E tuþuna basýldýysa ve diðer obje NPC etiketine sahipse
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("NPC"))
        {
            // Ebeveyn objeyi bul
            Transform parent = other.transform.parent;
           
            other.gameObject.SetActive(false);

            // Ebeveyn objedeki tüm çocuklarý dolaþ
            foreach (Transform child in parent)
            {
                // Eðer çocuk obje NPC etiketine sahip deðilse
                if (!child.CompareTag("NPC"))
                {

                    child.gameObject.SetActive(true);
                    
                    Destroy(gameObject);
                    break; // Ýlk bulunaný aktif hale getirdikten sonra döngüden çýk
                }
            }
        }
    }
}

