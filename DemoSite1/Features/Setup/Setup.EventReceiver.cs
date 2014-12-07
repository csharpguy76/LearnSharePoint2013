using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Web.UI.WebControls.WebParts;
using DemoSite1.WebParts.HelloWorldWebPart;
using Microsoft.SharePoint;

namespace DemoSite1.Features.Setup
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("15b1b71b-058d-4e82-adba-8b9d517c3e67")]
    public class SetupEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;
            var webPartManager = web.GetLimitedWebPartManager("SitePages/Home.aspx", PersonalizationScope.Shared);

            var webPart = new HelloWorldWebPart();
            webPart.Title = "Hello World Web Part";
            
            webPartManager.AddWebPart(webPart,"Zone 2", 2);
            webPartManager.SaveChanges(webPart);
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;
            web.AllowUnsafeUpdates = true;
            var webPartManager = web.GetLimitedWebPartManager("SitePages/Home.aspx", PersonalizationScope.Shared);
            var wp = webPartManager.WebParts.Cast<WebPart>().SingleOrDefault(x => x.Title == "Hello World Web Part");
            webPartManager.DeleteWebPart(wp);
        }


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
