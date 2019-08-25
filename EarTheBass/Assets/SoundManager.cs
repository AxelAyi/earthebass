using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EarTheBass {

     [System.Serializable]
    public class NoteSound {
        public enum NOTE { C, Db, D, Eb, E, F, Gb, G, Ab, A, Bb, B }
        public enum BASS_STRING { E, A, D, G }

        public NOTE note;
        public BASS_STRING stringId;
        public int fretId;
        public AudioClip sound;
    }

    public class SoundManager : MonoBehaviour
    {
        public NoteSound[] sounds;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }

}
