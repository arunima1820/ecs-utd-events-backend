using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UTD_ECS_Events_WebAPI
{
    public static class Global
    {
        #if DEBUG
            public const string Project_Id = "ecs-utdevents-dev";
        #elif RELEASE
            public const string Project_Id = "utdecsevents-9bed0";
        #endif

        #if DEBUG
                public const string Database_Key_File = "/ecsutdevents-DEV_KEY.json";
        #elif RELEASE
                public const string Database_Key_File = "/ecsutdevents-PROD_KEY.json";
        #endif

    }
}
