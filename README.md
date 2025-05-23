#  Weeping Angel AI – Unity C# Script

This Unity C# script recreates the eerie "Weeping Angel" behavior — the enemy chases the player **only when not being looked at**, and instantly **freezes when in view**. Inspired by games like *SCP: Containment Breach* and *Doctor Who*’s Weeping Angels.

---

##  Features

- ✅ Enemy stops when the player sees it
- ✅ Resumes chasing when unseen
- ✅ Uses `NavMeshAgent` for pathfinding
- ✅ Respawns player after being caught

---

## How to Use

1. Attach the script to your enemy GameObject.
2. Make sure the enemy has:
   - A `NavMeshAgent` component
   - A `Renderer` (for visibility checks)
3. Assign:
   - Player `Transform`
   - Player `Camera`
4. Set speed and catch distance in the Inspector.

---

##  Script Behavior

- Checks if the enemy is inside the player’s camera frustum.
- Performs a raycast to confirm visibility.
- If seen → stops
- If not seen → moves toward the player
- Catches and respawns the player when close

---

##  Example Values

```csharp
public float speed = 3.5f;
public float catchDistance = 1.5f;
