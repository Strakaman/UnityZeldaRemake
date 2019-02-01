using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundLibrary : MonoBehaviour {

	public SoundGroup[] soundGroups;

    Dictionary<SoundClipType, AudioClip[]> groupDictionary = new Dictionary<SoundClipType, AudioClip[]>();

	void Awake() {
		foreach (SoundGroup soundGroup in soundGroups) {
			groupDictionary.Add (soundGroup.soundType, soundGroup.group);
		}
	}

	public AudioClip GetClipFromName(SoundClipType theSoundType) {
        if (groupDictionary.ContainsKey(theSoundType))
        {
            AudioClip[] sounds = groupDictionary[theSoundType];
			return sounds [Random.Range (0, sounds.Length)];
		}
		return null;
	}

	[System.Serializable]
	public class SoundGroup {
		public SoundClipType soundType;
		public AudioClip[] group;
	}

}