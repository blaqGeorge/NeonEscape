//////using System.Collections;
//////using System.Collections.Generic;
//////using UnityEngine;

//////public class ThirdPersonDash : MonoBehaviour
//////{
//////    RigidbodyMovement moveScript;
//////    public float dashSpeed;
//////    public float dashTime;

//////    private void Start()
//////    {
//////        moveScript = GetComponent<RigidbodyMovement>();
//////    }

//////    private void Update()
//////    {
//////        if (Input.GetKey(KeyCode.E)) {
//////            StartCoroutine(Dash());
//////        }
//////    }

//////    IEnumerable Dash()
//////    {
//////        float startTime = Time.time;

//////        while (Time.time < startTime + dashTime)
//////        {
//////            moveScript.controller.Move(moveScript.);
//////        }
//////    }

//////}
////using UnityEngine;
////using UnityEngine.UI;
////using System.Collections; // Required for coroutines

////public class PlayerMP : MonoBehaviour
////{
////    public float maxMP = 100f; // Maximum MP
////    public float currentMP; // Current MP
////    public float abilityCost = 20f; // Amount of MP reduced when ability is used
////    public Slider mpSlider; // UI slider for MP

////    void Start()
////    {
////        currentMP = maxMP; // Initialize MP
////        mpSlider.maxValue = maxMP;
////        mpSlider.value = currentMP;
////    }

////    void Update()
////    {
////        mpSlider.value = currentMP; // Update MP bar

////        if (Input.GetKeyDown(KeyCode.E)) // If player presses E
////        {
////            UseAbility();
////        }
////    }

////    void UseAbility()
////    {
////        if (currentMP >= abilityCost)
////        {
////            currentMP -= abilityCost; // Deduct MP
////            maxMP -= abilityCost; // Temporarily reduce max MP
////            StartCoroutine(RefillMaxMP()); // Begin MP recovery process
////        }
////    }

////    IEnumerator RefillMaxMP()
////    {
////        yield return new WaitForSeconds(5); // Wait 5 seconds
////        maxMP += abilityCost; // Restore max MP
////    }
////}

//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;

//public class PlayerMP : MonoBehaviour
//{
//    public float maxMP = 100f;
//    public float currentMP;
//    public float abilityCost = 20f;
//    public float regenRate = 10f; // MP regen per second
//    public float regenDelay = 5f; // Time before MP starts regenerating
//    public Slider mpSlider;
//    private bool isRegenerating = false;

//    void Start()
//    {
//        currentMP = maxMP;
//        mpSlider.maxValue = maxMP;
//        mpSlider.value = currentMP;
//    }

//    void Update()
//    {
//        mpSlider.value = currentMP;

//        // **Only allow ability if current MP is 50 or more**
//        if (Input.GetKeyDown(KeyCode.E) && currentMP >= 50)
//        {
//            UseAbility();
//        }
//    }

//    void UseAbility()
//    {
//        currentMP -= abilityCost;
//        maxMP -= abilityCost;

//        if (isRegenerating)
//        {
//            StopCoroutine(RegenerateMP());
//        }
//        StartCoroutine(RegenerateMP());
//    }

//    IEnumerator RegenerateMP()
//    {
//        isRegenerating = true;
//        yield return new WaitForSeconds(regenDelay);

//        while (currentMP < maxMP)
//        {
//            currentMP = Mathf.Clamp(currentMP + (regenRate * Time.deltaTime), 0, maxMP);
//            mpSlider.value = currentMP;
//            yield return null;
//        }

//        isRegenerating = false;
//    }
//}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMP : MonoBehaviour
{
    public float maxMP = 100f; // Max MP
    public float currentMP; // Current MP
    public float abilityCost = 20f; // MP cost for teleport ability
    public float regenRate = 10f; // MP regen per second
    public float regenDelay = 5f; // Delay before MP starts regenerating
    public float tpDistance = 1.5f; // Teleport distance

    public Slider mpSlider;
    private bool isRegenerating = false;

    void Start()
    {
        maxMP = 100f;
        currentMP = maxMP;
        mpSlider.maxValue = maxMP;
        mpSlider.value = currentMP;
    }

    void Update()
    {
        mpSlider.value = currentMP;

        // **Trigger teleport if E is pressed and MP is 50 or more**
        if (Input.GetKeyDown(KeyCode.E) && currentMP >= 50)
        {
            TeleportAbility();
        }
    }

    void TeleportAbility()
    {
        currentMP -= abilityCost; // Reduce MP
        maxMP -= abilityCost; // Temporarily reduce max MP

        // **Teleport the player forward**
        transform.position += transform.forward * tpDistance;

        Debug.Log("Teleported! Remaining MP: " + currentMP);

        // Stop previous regeneration coroutine and restart regen delay
        if (isRegenerating)
        {
            StopCoroutine(RegenerateMP());
        }
        StartCoroutine(RegenerateMP());
    }

    IEnumerator RegenerateMP()
    {
        isRegenerating = true;
        yield return new WaitForSeconds(regenDelay); // Wait before starting regen

        while (currentMP < maxMP)
        {
            currentMP = Mathf.Clamp(currentMP + (regenRate * Time.deltaTime), 0, maxMP);
            mpSlider.value = currentMP;
           
            yield return null;
            
        }

        maxMP =100f; // Restore max MP after full regeneration
        isRegenerating = false;
    }
}