using Newtonsoft.Json;

namespace MovieLibrary.UnitTests
{
    public static class CustomAssert
    {
        public static bool ValueEqual(object obj1, object obj2)
        {
            return JsonConvert.SerializeObject(obj1) == JsonConvert.SerializeObject(obj2);
        }
    }
}