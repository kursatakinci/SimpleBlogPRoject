using System.Text.Json;

namespace SimpleBlogProject.Core.Helper.String
{
    public static class JsonElementHelper
    {
        public static string GetString(JsonElement jsonElement)
        {
            string json = JsonSerializer.Serialize(jsonElement);

            return json;
        }
    }
}
