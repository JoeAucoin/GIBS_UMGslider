using DotNetNuke.Common.Utilities;
using GIBS.Modules.GIBS_UMGslider.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GIBS.Modules.GIBS_UMGslider.Components
{
    public class SliderController
    {
        public static List<SliderInfo> GetItems(int albumID, int maxCount, int moduleID)

        {   //todo: look at caching

            return CBO.FillCollection<SliderInfo>(DataProvider.Instance().GetItems(albumID, maxCount, moduleID));

        }

        //portalId
        public static List<SliderInfo> GetAlbums(int portalId)

        {   //todo: look at caching

            return CBO.FillCollection<SliderInfo>(DataProvider.Instance().GetAlbums(portalId));

        }


    }
}