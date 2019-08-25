using UnityEngine;
using System.Linq;
using UnityEngine.UI;

namespace EarTheBass
{
    public class GuessTheNotes : MonoBehaviour {
        public SoundManager soundManager;
        public Text testCountText;
        public Text scoreText;
        public GameObject nextButton;
        public Text noteDetailText;
        public Image[] noteImages;
        private NoteSound[] sounds;
        private int curIndex;
        private int score;
        private AudioSource source;
        private bool testDone = false;

        void Start() {
            source = GetComponent<AudioSource>();
            curIndex = 0;
            sounds = soundManager.sounds.OrderBy(x => Random.Range(1, 1000)).ToArray();   
            source.PlayOneShot(sounds[curIndex].sound);
            testCountText.text = (curIndex + 1) + "/" + soundManager.sounds.Length;
            nextButton.SetActive(false);
        }

        public void SelectNote(int index) {
            NoteSound.NOTE note = (NoteSound.NOTE) index;
            if (note == sounds[curIndex].note) {
                source.Stop();
                source.PlayOneShot(sounds[curIndex].sound);

                if (!testDone) {
                    noteImages[index].color = Color.green;
                    score++;
                }
            }
            else {
                NoteSound noteSound;
                if (Random.Range(0,2) > 0) { 
                    noteSound = soundManager.sounds.Last(x => x.note == note);
                }
                else {
                    noteSound = soundManager.sounds.First(x => x.note == note);
                }
                source.Stop();
                source.PlayOneShot(noteSound.sound);

                if (!testDone) {
                    noteImages[index].color = Color.red;
                    noteImages[(int)sounds[curIndex].note].color = Color.green;
                }
            }

            if (!testDone) {
                noteDetailText.text = "Note = " + sounds[curIndex].note.ToString() + " | String = " + sounds[curIndex].stringId.ToString() + " | Fret = " + sounds[curIndex].fretId;
                scoreText.text = score * 100 / (curIndex + 1) + "%";
                nextButton.SetActive(true);
                testDone = true;
            }
        }

        public void PlayCurrentSound() {
            source.Stop();
            source.PlayOneShot(sounds[curIndex].sound);
        }

        public void Next() {
            for (int i = 0; i < noteImages.Length; i++)
            {
                noteImages[i].color = Color.white;
            }

            if (curIndex < soundManager.sounds.Length) {
                curIndex++;
            
                nextButton.SetActive(false);
                testDone = false;
            
                testCountText.text = (curIndex + 1) + "/" + soundManager.sounds.Length;
                noteDetailText.text = "";
                source.Stop();
                source.PlayOneShot(sounds[curIndex].sound);
            }
        }
    }
}