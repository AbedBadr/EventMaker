using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using EventMaker.Model;
using Newtonsoft.Json;

namespace EventMaker.Persistency
{
    // Json.Net er downloaded til projektet via NuGet.

    class PersistencyService
    {
        private static string JsonFileName = "Events.json";

        public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> events)
        {
            string EventsJsonString = JsonConvert.SerializeObject(events);
            SerializeEventsFileAsync(EventsJsonString, JsonFileName);
        }

        public static async Task<List<Event>> LoadEventsFromJsonAsync()
        {
            string eventsJsonString = await DeSerializeEventsFileAsync(JsonFileName);
            if (eventsJsonString != null)
                return (List<Event>) JsonConvert.DeserializeObject(eventsJsonString,
                    typeof(List<Event>));
            return null;
        }

        public static async void SerializeEventsFileAsync(string eventsString, string fileName)
        {
            StorageFile localFile =
                await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName,
                    CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, eventsString);
        }

        public static async Task<string> DeSerializeEventsFileAsync(string fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);
            }
            catch (FileNotFoundException ex)
            {
                MessageDialogHelper.Show(
                    "Loading for the first time? - Try to Add and Save some Events before trying to Save for the first time",
                    "File not found");
                return null;
            }
        }

        private class MessageDialogHelper
        {
            public static async void Show(string content, string title)
            {
                MessageDialog messageDialog = new MessageDialog(content, title);
                await messageDialog.ShowAsync();
            }
        }
    }
}
