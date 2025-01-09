using System.Collections.Generic;
using UnityEngine;

namespace Edgar.Unity
{
    // Class representing a single key
    public class Key
    {
        public string KeyID { get; private set; }
        public string Name { get; private set; }

        public Key(string keyID, string name)
        {
            KeyID = keyID;
            Name = name;
        }
    }

    // Manager class for handling keys
    public class KeyManager : MonoBehaviour
    {
        private List<Key> collectedKeys;

        private void Awake()
        {
            collectedKeys = new List<Key>();
        }

        // Method to add a key to the player's collection
        public void CollectKey(Key key)
        {
            if (!collectedKeys.Contains(key))
            {
                collectedKeys.Add(key);
                Debug.Log($"Key collected: {key.Name}");
            }
            else
            {
                Debug.Log($"Key already collected: {key.Name}");
            }
        }

        // Method to check if the player has a specific key
        public bool HasKey(string keyID)
        {
            foreach (var key in collectedKeys)
            {
                if (key.KeyID == keyID)
                {
                    return true;
                }
            }
            return false;
        }

        // Method to use a key to unlock a door
        public bool UseKey(string keyID, Door door)
        {
            if (HasKey(keyID))
            {
                if (door.Unlock(keyID))
                {
                    Debug.Log($"Door unlocked with key: {keyID}");
                    return true;
                }
                else
                {
                    Debug.Log($"Key {keyID} does not match the door.");
                }
            }
            else
            {
                Debug.Log($"Player does not have key: {keyID}");
            }
            return false;
        }
    }
}
