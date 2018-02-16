using Newtonsoft.Json;
using System.Text;

namespace DevF_LABS.Presentation.Redis
{
    public class CacheHelper
    {
        protected virtual byte[] Serialize(object item)
        {
            var jsonString = JsonConvert.SerializeObject(item);
            return Encoding.UTF8.GetBytes(jsonString);
        }
        protected virtual T Deserialize<T>(string[] serializedObject)
        {
            if (serializedObject == null)
                return default(T);

            string jsonString = "[";
            foreach (var item in serializedObject)
                jsonString += item + ",";
            jsonString += "]";
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        protected virtual int Deserialize(string[] serializedObject)
        {
            int result = 0;
            int.TryParse(serializedObject[0], out result);
            return result;
        }
    }
}