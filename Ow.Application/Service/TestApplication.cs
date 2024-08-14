using Volo.Abp.Application.Services;

namespace Ow.Application.Service
{
    public class TestApplication:ApplicationService,ITestApplication
    {
        public string GetName()
        {
            return "My Name is XXX.";
        }

    }
}
