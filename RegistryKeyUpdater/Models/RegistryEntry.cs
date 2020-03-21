using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryKeyUpdater.Models
{
   public class RegistryEntry
   {
      /// <summary>
      /// Gets or sets the key.
      /// </summary>
      /// <value>
      /// The key.
      /// </value>
      public string Key { get; set; }

      /// <summary>
      /// Gets or sets the value.
      /// </summary>
      /// <value>
      /// The value.
      /// </value>
      public string Value { get; set; }

      /// <summary>
      /// Gets or sets the type of the data.
      /// </summary>
      /// <value>
      /// The type of the data.
      /// </value>
      public string DataType { get; set; }
   }
}