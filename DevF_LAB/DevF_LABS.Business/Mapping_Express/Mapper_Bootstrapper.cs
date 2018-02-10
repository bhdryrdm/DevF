using DevF_LABS.Business.Mapping_AutoMapper;

namespace DevF_LABS.Business.Mapping_Express
{
    public static class Mapper_Bootstrapper
    {
        public static void RegisterMapping()
        {
            new XSS_ExpressMapper();
        }
    }
}
