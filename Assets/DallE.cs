using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading.Tasks;

namespace OpenAI
{
    public class DallE : MonoBehaviour
    {
        [SerializeField] private InputField Name;
        [SerializeField] private Button button;
        [SerializeField] private Image image;
        [SerializeField] private GameObject loadingLabel;

        private OpenAIApi openai = new OpenAIApi();

        private void Start()
        {
            button.onClick.AddListener(SendImageRequest);
        }

        private async void SendImageRequest()
        {
            image.sprite = null;
            button.enabled = false;
            Name.enabled = false;
            loadingLabel.SetActive(true);
            var response = await openai.CreateImage(new CreateImageRequest {
				Model = "dall-e-3",
                Prompt = "Generate a anime - style normal looking "+Name.text+" from a Dungeons and dragons fantasy world for a background of a visual novel, no characters, no border, 16:9 aspect ratio, and nothing to fancy like crystals and stuff.",
                Size = ImageSize.Size1792
			});

            if (response.Data != null && response.Data.Count > 0)
            {
                using(var request = new UnityWebRequest(response.Data[0].Url))
                {
                    request.downloadHandler = new DownloadHandlerBuffer();
                    request.SetRequestHeader("Access-Control-Allow-Origin", "*");
                    request.SendWebRequest();

                    while (!request.isDone) await Task.Yield();

                    Texture2D texture = new Texture2D(2, 2);
                    texture.LoadImage(request.downloadHandler.data);
					byte[] imageData = texture.EncodeToPNG(); // Or use EncodeToJPG for JPG files
					System.IO.File.WriteAllBytes(Application.persistentDataPath + "/Backgrounds/"+Name.text+".png", imageData);
					Debug.Log("Image saved at: " + Application.persistentDataPath + "/Backgrounds/" + Name.text + ".png");
					var sprite = Sprite.Create(texture, new Rect(0, 0, 1792, 1024), Vector2.zero, 1f);
                    image.sprite = sprite;
                }
            }
            else
            {
                Debug.LogWarning("No image was created from this prompt.");
            }

            button.enabled = true;
            Name.enabled = true;
            loadingLabel.SetActive(false);
        }
    }
}
