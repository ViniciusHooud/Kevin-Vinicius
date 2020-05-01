namespace MobileCamoes.Infra
{
    public class AppSettings
    {
        public const string ApiUrl = "https://api.themoviedb.org/3";
        public const string ApiKey = "fff89b39bdf069ec334aa762a2c73353";
        public const string ApiImageBaseUrl = "https://image.tmdb.org/t/p/w500/";

        public static string OfflineDataBaseLiteDBPath { get; set; }
        public static string OfflineDataBaseSQLitePath { get; set; }
        public static string OfflineFileSystemPath { get; set; }
    }
}
