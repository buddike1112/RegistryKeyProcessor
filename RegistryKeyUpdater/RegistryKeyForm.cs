using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;

namespace RegistryKeyUpdater
{
   public partial class frmRegistryKeyUpdater : Form
   {
      public List<string> KeyStores { get; set; }

      public frmRegistryKeyUpdater()
      {
         InitializeComponent();

         KeyStores = new List<string>() { "HKEY_CLASSES_ROOT", "HKEY_CURRENT_USER", "HKEY_LOCAL_MACHINE", "HKEY_USERS", "HKEY_CURRENT_CONFIG" };
      }

      private void frmRegistryKeyUpdater_Load(object sender, EventArgs e)
      {
         try
         {
            cmbKeyStores.Items.AddRange(KeyStores.ToArray<object>());
         }
         catch (Exception ex)
         {
            WriteLog($"Error occurrerd on form loading : {ex.Message} Trace : {ex.StackTrace}");
         }
      }

      private void cmbKeyStores_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            switch (cmbKeyStores.SelectedItem.ToString())
            {
               case "HKEY_LOCAL_MACHINE":
                  //string[] subKeyNames = GetSubKeyNameArray(Registry.LocalMachine);

                  // Print out the keys.
                  PrintKeys(Registry.LocalMachine);
                  //EnumerateKeysRecurse("SOFTWARE\\WOW6432Node");
                  //PopulateList(subKeyNames);
                  break;

               default:
                  WriteLog($"{cmbKeyStores.SelectedItem.ToString()} not yet configured");
                  break;
            }
         }
         catch (Exception ex)
         {
            WriteLog($"Error occurrerd on key store searching : {ex.Message} Trace : {ex.StackTrace}"); WriteLog($"Error occurrerd on key store searching : {ex.Message} Trace : {ex.StackTrace}");
         }
      }

      #region Private Methods

      public bool CanReadKey(RegistryKey rkey, string key)
      {
         try
         {
            rkey.OpenSubKey(key, true).Close();
            return true;
         }
         catch (SecurityException)
         {
            return false;
         }
      }

      private void PrintKeys(RegistryKey rkey)
      {
         // Retrieve all the subkeys for the specified key.
         String[] names = rkey.GetSubKeyNames();
         string keyPath = string.Empty;

         // Print the contents of the array to the console.
         foreach (String s in names)
         {
            keyPath = string.Concat(rkey.Name, "\\", s);

            RegistryKey RegKey = rkey.OpenSubKey(s);

            if (RegKey != null)
            {
               PopulateItem(keyPath);
               this.PrintKeys(RegKey);
            }
         }
      }

      private void PopulateItem(string subKey)
      {
         try
         {
            lstKeys.Items.Add(subKey);
         }
         catch (Exception ex)
         {
            WriteLog($"Error occurrerd on PopulateItem : {ex.Message} Trace : {ex.StackTrace}");
         }
      }

      private void WriteLog(string logToWrite)
      {
         txtResult.Text = string.Empty;
         txtResult.Text = logToWrite;
      }

      private void ClearControls()
      {
         lstKeys.Items.Clear();
         txtKeyValuePair.Text = string.Empty;
         txtResult.Text = string.Empty;
      }

      #endregion Private Methods
   }
}