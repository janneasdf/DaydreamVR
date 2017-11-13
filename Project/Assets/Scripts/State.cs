using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {
    [Tooltip("For easy access to photo picker, even if it is inactive. ")]
    public GameObject PhotoPicker;

    [Tooltip("For easy access to sticker picker, even if it is inactive. ")]
    public GameObject StickerPicker;

    [Tooltip("Prefab for an empty room. ")]
    public GameObject EmptyRoomPrefab;

    public void SetTerrain(GameObject terrainOrNull)
    {
        SetEnvironmentThing("TerrainParent", terrainOrNull);
    }

    public void SetEffect(GameObject effectOrNull)
    {
        SetEnvironmentThing("EffectParent", effectOrNull);

    }

    public void SetBackground(GameObject backgroundOrNull)
    {
        SetEnvironmentThing("BackgroundParent", backgroundOrNull);
    }

    private void SetEnvironmentThing(string parentName, GameObject thing)
    {
        var currentRoom = GetCurrentRoom();
        var thingParentTransform = currentRoom.transform.Find("Environment").Find(parentName);

        var thingPrefab = thing;
        foreach (Transform child in thingParentTransform)
        {
            Destroy(child.gameObject);
        }
        if (thingPrefab != null)
        {
            var newThing = Instantiate(thingPrefab);
            newThing.transform.SetParent(thingParentTransform, true);
        }

        //foreach (Transform existingThing in thingParentTransform)
        //{
        //    existingThing.gameObject.SetActive(false);
        //}
        //if (thing != null)
        //{
        //    thing.SetActive(true);
        //}
    }
    
    // Returns first room object that is not inactive
    private GameObject GetCurrentRoom()
    {
        var rooms = GameObject.Find("Rooms");
        foreach (Transform roomTransform in rooms.transform)
        {
            var room = roomTransform.gameObject;
            if (room.activeSelf) return room;
        }
        print("Error: Current room could not be found. ");
        return null;
    }

    public void GoToNextRoom() { GoToRoom(1); }

    public void GoToPreviousRoom() { GoToRoom(-1); }

    // Goes to room with index of current room index + offset (such as -1 or +1)
    private void GoToRoom(int offset)
    {
        var currentRoom = GetCurrentRoom();
        var roomIndex = currentRoom.transform.GetSiblingIndex() + offset;
        var roomsTransform = currentRoom.transform.parent;
        // Check that the room is not out of bounds
        if (roomIndex >= 0)
        {
            // Create new room if necessary
            if (roomIndex == roomsTransform.childCount)
            {
                var newRoom = Instantiate(EmptyRoomPrefab);
                newRoom.transform.SetParent(roomsTransform, true);

                // Hack: set the picker and empty room prefab
                var newState = newRoom.gameObject.GetComponentInChildren<State>();
                newState.EmptyRoomPrefab = EmptyRoomPrefab;
                newState.PhotoPicker = PhotoPicker;
            }

            // Set all rooms inactive
            foreach (Transform room in roomsTransform) { room.gameObject.SetActive(false); }

            // Set the new room active
            roomsTransform.GetChild(roomIndex).gameObject.SetActive(true);
        }
        else
        {
            print("Error: room " + roomIndex + " is out of bounds. ");
        }
    }
}
