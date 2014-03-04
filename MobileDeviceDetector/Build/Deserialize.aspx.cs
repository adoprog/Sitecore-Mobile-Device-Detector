namespace Sitecore.SharedSource.MobileDeviceDetector.Build
{
  using System;
  using System.IO;

  using Sitecore.Configuration;
  using Sitecore.Data;
  using Sitecore.Data.Serialization;
  using Sitecore.SecurityModel;

  public partial class Deserialize : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      this.Page.Session.Timeout = 300;

      using (new SecurityDisabler())
      {
        Sitecore.Context.SetActiveSite("shell");
        DeserializeDatabase(false);
        ClearArchives();
      }
    }

    private static void DeserializeDatabase(bool force)
    {
      foreach (string path2 in Factory.GetDatabaseNames())
      {
        var options = new LoadOptions { ForceUpdate = force, DisableEvents = true };
        Manager.LoadTree(Path.Combine(PathUtils.Root, path2), options);
      }
    }
    
    private static void ClearArchives()
    {
      foreach (Database database in Factory.GetDatabases())
      {
        foreach (string index in database.ArchiveNames)
        {
          database.Archives[index].RemoveEntries();
        }
      }
    }
  }
}