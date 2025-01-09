using UnityEngine;

namespace Edgar.Unity
{
    public class Door : MonoBehaviour
    {
        public string DoorID { get; private set; }
        public bool IsLocked { get; private set; }

        public Door(string doorID)
        {
            DoorID = doorID;
            IsLocked = true;
        }

        // Method to unlock the door using a key
        public bool Unlock(string keyID)
        {
            if (IsLocked && keyID == DoorID)
            {
                IsLocked = false;
                Debug.Log($"Door {DoorID} unlocked successfully.");
                return true;
            }
            else
            {
                Debug.Log($"Failed to unlock door {DoorID}. Incorrect key: {keyID}");
                return false;
            }
        }

        // Method to lock the door
        public void Lock()
        {
            IsLocked = true;
            Debug.Log($"Door {DoorID} is now locked.");
        }
    }
}
