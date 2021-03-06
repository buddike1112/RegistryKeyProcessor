﻿using Microsoft.Win32;
using RegistryKeyUpdater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RegistryKeyUpdater
{
   public partial class frmRegistryKeyUpdater : Form
   {
      /// <summary>
      /// Gets or sets the key stores.
      /// </summary>
      /// <value>
      /// The key stores.
      /// </value>
      public List<string> KeyStores { get; set; }

      public frmRegistryKeyUpdater()
      {
         InitializeComponent();

         KeyStores = new List<string>() { "HKEY_CLASSES_ROOT", "HKEY_CURRENT_USER", "HKEY_LOCAL_MACHINE", "HKEY_USERS", "HKEY_CURRENT_CONFIG" };
      }

      /// <summary>
      /// Handles the Load event of the frmRegistryKeyUpdater control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

      /// <summary>
      /// Handles the SelectedIndexChanged event of the cmbKeyStores control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
      private void cmbKeyStores_SelectedIndexChanged(object sender, EventArgs e)
      {
         // Clearing controls
         ClearControls();

         try
         {
            switch (cmbKeyStores.SelectedItem.ToString())
            {
               case "HKEY_LOCAL_MACHINE":
                  // Loading LOCAL_MACHINE Keys
                  PrintKeys(Registry.LocalMachine);
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

      /// <summary>
      /// Handles the Click event of the btnCreate control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
      private void btnCreate_Click(object sender, EventArgs e)
      {
         try
         {
            List<RegistryEntry> keysToWrite = GetKeysList();

            if (keysToWrite.Count > 0)
            {
               string log = string.Empty;

               foreach (var item in keysToWrite)
               {
                  log += $"These entries will add to the destination Key : {item.Key} Value : {item.Value} Data Type : {item.DataType}\n";
               }

               WriteLog(log);
            }
            else
            {
               WriteLog($"Unable to find keys to input.");
            }
         }
         catch (Exception ex)
         {
            WriteLog($"Error occurrerd on btnCreate_Click : {ex.Message} Trace : {ex.StackTrace}");
         }
      }

      private List<RegistryEntry> GetKeysList()
      {
         List<RegistryEntry> items = new List<RegistryEntry>();
         string[] mainItems = txtKeyValuePair.Text.Split(';');

         try
         {
            if (mainItems != null && mainItems.Length > 0)
            {
               foreach (string item in mainItems)
               {
                  string[] filteredItems = item.Split(':');

                  if (filteredItems.Length > 0)
                  {
                     string[] keyValueItems = filteredItems[0].Split('=');

                     if (keyValueItems.Length > 0)
                     {
                        items.Add(new RegistryEntry() { Key = keyValueItems[0], Value = keyValueItems[1], DataType = filteredItems[1] });
                     }
                     else
                     {
                        WriteLog($"Not a qualified pattern : {filteredItems[0]} qualifier -> '='");
                     }
                  }
                  else
                  {
                     WriteLog($"Not a qualified pattern : {item} qualifier -> ':'");
                  }
               }
            }
            else
            {
               WriteLog($"Unable to find qualified registry entries to add. Please provide keys in correct format.");
            }
         }
         catch (Exception ex)
         {
            WriteLog($"Error occurrerd on GetKeysList : {ex.Message} Trace : {ex.StackTrace}");
         }

         return items;
      }

      /// <summary>
      /// Handles the Click event of the btnReset control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
      private void btnReset_Click(object sender, EventArgs e)
      {
         ClearControls();
      }

      #region Private Methods

      /// <summary>
      /// Prints the keys and subkeys in list box.
      /// </summary>
      /// <param name="rkey">The rkey.</param>
      private void PrintKeys(RegistryKey rkey)
      {
         // Retrieve all the subkeys for the specified key.
         String[] names = rkey.GetSubKeyNames();
         string keyPath = string.Empty;

         // Print the contents of the array to the console.
         foreach (String s in names)
         {
            PopulateItem("MainKey:" + s);
            keyPath = string.Concat(rkey.Name, "\\", s);

            try
            {
               RegistryKey RegKey = rkey.OpenSubKey(s);

               foreach (var val in RegKey.GetSubKeyNames())
               {
                  PopulateItem("\tKey:" + string.Concat(keyPath, "\\", val));

                  RegistryKey productKey = RegKey.OpenSubKey(val);

                  if (productKey != null)
                  {
                     foreach (var subKeyName in productKey.GetSubKeyNames())
                     {
                        PopulateItem("\t\tSubKey:" + string.Concat(keyPath, "\\", val, "\\", subKeyName));
                     }
                  }
               }
            }
            catch (SecurityException ex)
            {
               PopulateItem($"{keyPath} -----> {ex.Message}");
            }
         }
      }

      /// <summary>
      /// Populates the item in List view.
      /// </summary>
      /// <param name="subKey">The sub key.</param>
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

      /// <summary>
      /// Writes the log in Result box.
      /// </summary>
      /// <param name="logToWrite">The log to write.</param>
      private void WriteLog(string logToWrite)
      {
         txtResult.Text = string.Empty;
         txtResult.Text = logToWrite;
      }

      /// <summary>
      /// Clears the controls.
      /// </summary>
      private void ClearControls()
      {
         lstKeys.Items.Clear();
         txtKeyValuePair.Text = string.Empty;
         txtResult.Text = string.Empty;
      }

      #endregion Private Methods
   }
}