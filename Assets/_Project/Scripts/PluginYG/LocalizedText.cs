using YG;

namespace Assets.Scripts.PluginYG
{
    public static class LocalizedText
    {
        public const string Russian = "ru";
        public const string English = "en";
        public const string Turkish = "tr";

        public static string Get(string english, string russia, string turkish = null)
        {
            return YG2.lang switch
            {
                Russian => russia,
                English => english,
                Turkish => turkish,

                _ => Russian,
            };
        }
    }
}