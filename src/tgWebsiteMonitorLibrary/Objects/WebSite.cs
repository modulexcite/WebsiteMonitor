﻿using System;
using System.Collections.Generic;
using TreeGecko.Library.Common.Objects;

namespace TreeGecko.WebMonitor.Library.Objects
{
    public class WebSite : AbstractTGObject    
    {
        /// <summary>
        /// Url to test
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Seconds to check web site.
        /// Ignored if in a group.
        /// </summary>
        public int CheckEvery { get; set; }

        /// <summary>
        /// Next time to test the web site.
        /// Ignored if in a group.
        /// </summary>
        public DateTime NextCheckTime { get; set; }

        /// <summary>
        /// List of users to notify
        /// Ignored if in group
        /// </summary>
        public List<Guid> UsersToNotify { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public Guid? WebSiteGroupGuid { get; set; }

        public override TGSerializedObject GetTGSerializedObject()
        {
            TGSerializedObject tgs = base.GetTGSerializedObject();

            tgs.Add("Url", Url);
            tgs.Add("CheckEvery", CheckEvery);
            tgs.Add("NextCheckTime", NextCheckTime);
            tgs.Add("WebSiteGroupGuid", WebSiteGroupGuid);
            tgs.Add("UsersToNotify", UsersToNotify);

            return tgs;
        }

        public override void LoadFromTGSerializedObject(TGSerializedObject _tgs)
        {
            base.LoadFromTGSerializedObject(_tgs);

            Url = _tgs.GetString("Url");
            CheckEvery = _tgs.GetInt32("CheckEvery");
            NextCheckTime = _tgs.GetDateTime("NextCheckTime");
            WebSiteGroupGuid = _tgs.GetNullableGuid("WebSiteGroupGuid");
            UsersToNotify = _tgs.GetListOfGuids("UsersToNotify");
        }
    }
}
