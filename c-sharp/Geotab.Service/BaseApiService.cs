using Geotab.Core;

namespace Geotab.Service
{
    class BaseApiService
    {
        public string BaseUrl { get; set; }

        public int? TimeoutInSeconds { get; set; }

        public BaseApiService() { }

    }
}
