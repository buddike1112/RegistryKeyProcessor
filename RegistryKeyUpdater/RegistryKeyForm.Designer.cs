namespace RegistryKeyUpdater
{
   partial class frmRegistryKeyUpdater
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.lblKeyStores = new System.Windows.Forms.Label();
         this.cmbKeyStores = new System.Windows.Forms.ComboBox();
         this.lblKeys = new System.Windows.Forms.Label();
         this.lstKeys = new System.Windows.Forms.ListBox();
         this.lblKeyValuePair = new System.Windows.Forms.Label();
         this.txtKeyValuePair = new System.Windows.Forms.TextBox();
         this.lblResult = new System.Windows.Forms.Label();
         this.txtResult = new System.Windows.Forms.TextBox();
         this.tabArea = new System.Windows.Forms.TabControl();
         this.tabCreate = new System.Windows.Forms.TabPage();
         this.tabMoveKeys = new System.Windows.Forms.TabPage();
         this.tabArea.SuspendLayout();
         this.tabCreate.SuspendLayout();
         this.SuspendLayout();
         // 
         // lblKeyStores
         // 
         this.lblKeyStores.AutoSize = true;
         this.lblKeyStores.Location = new System.Drawing.Point(11, 30);
         this.lblKeyStores.Name = "lblKeyStores";
         this.lblKeyStores.Size = new System.Drawing.Size(58, 13);
         this.lblKeyStores.TabIndex = 0;
         this.lblKeyStores.Text = "Key Stores";
         // 
         // cmbKeyStores
         // 
         this.cmbKeyStores.FormattingEnabled = true;
         this.cmbKeyStores.Location = new System.Drawing.Point(108, 27);
         this.cmbKeyStores.Name = "cmbKeyStores";
         this.cmbKeyStores.Size = new System.Drawing.Size(277, 21);
         this.cmbKeyStores.TabIndex = 1;
         this.cmbKeyStores.SelectedIndexChanged += new System.EventHandler(this.cmbKeyStores_SelectedIndexChanged);
         // 
         // lblKeys
         // 
         this.lblKeys.AutoSize = true;
         this.lblKeys.Location = new System.Drawing.Point(11, 62);
         this.lblKeys.Name = "lblKeys";
         this.lblKeys.Size = new System.Drawing.Size(76, 13);
         this.lblKeys.TabIndex = 2;
         this.lblKeys.Text = "Available Keys";
         // 
         // lstKeys
         // 
         this.lstKeys.FormattingEnabled = true;
         this.lstKeys.Location = new System.Drawing.Point(14, 84);
         this.lstKeys.Name = "lstKeys";
         this.lstKeys.Size = new System.Drawing.Size(746, 329);
         this.lstKeys.TabIndex = 3;
         // 
         // lblKeyValuePair
         // 
         this.lblKeyValuePair.AutoSize = true;
         this.lblKeyValuePair.Location = new System.Drawing.Point(10, 430);
         this.lblKeyValuePair.Name = "lblKeyValuePair";
         this.lblKeyValuePair.Size = new System.Drawing.Size(329, 13);
         this.lblKeyValuePair.TabIndex = 4;
         this.lblKeyValuePair.Text = "KeyValuePair (Ex : Key1=Value1;DataType;Key2=Value2:DataType)";
         // 
         // txtKeyValuePair
         // 
         this.txtKeyValuePair.Location = new System.Drawing.Point(14, 466);
         this.txtKeyValuePair.Name = "txtKeyValuePair";
         this.txtKeyValuePair.Size = new System.Drawing.Size(726, 20);
         this.txtKeyValuePair.TabIndex = 5;
         // 
         // lblResult
         // 
         this.lblResult.AutoSize = true;
         this.lblResult.Location = new System.Drawing.Point(11, 502);
         this.lblResult.Name = "lblResult";
         this.lblResult.Size = new System.Drawing.Size(37, 13);
         this.lblResult.TabIndex = 6;
         this.lblResult.Text = "Result";
         // 
         // txtResult
         // 
         this.txtResult.Location = new System.Drawing.Point(14, 533);
         this.txtResult.Multiline = true;
         this.txtResult.Name = "txtResult";
         this.txtResult.ReadOnly = true;
         this.txtResult.Size = new System.Drawing.Size(746, 111);
         this.txtResult.TabIndex = 7;
         // 
         // tabArea
         // 
         this.tabArea.Controls.Add(this.tabCreate);
         this.tabArea.Controls.Add(this.tabMoveKeys);
         this.tabArea.Location = new System.Drawing.Point(30, 21);
         this.tabArea.Name = "tabArea";
         this.tabArea.SelectedIndex = 0;
         this.tabArea.Size = new System.Drawing.Size(795, 742);
         this.tabArea.TabIndex = 8;
         // 
         // tabCreate
         // 
         this.tabCreate.Controls.Add(this.cmbKeyStores);
         this.tabCreate.Controls.Add(this.txtResult);
         this.tabCreate.Controls.Add(this.lblKeyStores);
         this.tabCreate.Controls.Add(this.lblResult);
         this.tabCreate.Controls.Add(this.lstKeys);
         this.tabCreate.Controls.Add(this.txtKeyValuePair);
         this.tabCreate.Controls.Add(this.lblKeys);
         this.tabCreate.Controls.Add(this.lblKeyValuePair);
         this.tabCreate.Location = new System.Drawing.Point(4, 22);
         this.tabCreate.Name = "tabCreate";
         this.tabCreate.Padding = new System.Windows.Forms.Padding(3);
         this.tabCreate.Size = new System.Drawing.Size(787, 716);
         this.tabCreate.TabIndex = 0;
         this.tabCreate.Text = "Create Keys";
         this.tabCreate.UseVisualStyleBackColor = true;
         // 
         // tabMoveKeys
         // 
         this.tabMoveKeys.Location = new System.Drawing.Point(4, 22);
         this.tabMoveKeys.Name = "tabMoveKeys";
         this.tabMoveKeys.Padding = new System.Windows.Forms.Padding(3);
         this.tabMoveKeys.Size = new System.Drawing.Size(787, 716);
         this.tabMoveKeys.TabIndex = 1;
         this.tabMoveKeys.Text = "Move Keys";
         this.tabMoveKeys.UseVisualStyleBackColor = true;
         // 
         // frmRegistryKeyUpdater
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(847, 779);
         this.Controls.Add(this.tabArea);
         this.Name = "frmRegistryKeyUpdater";
         this.Text = "Registry Key Updater";
         this.Load += new System.EventHandler(this.frmRegistryKeyUpdater_Load);
         this.tabArea.ResumeLayout(false);
         this.tabCreate.ResumeLayout(false);
         this.tabCreate.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label lblKeyStores;
      private System.Windows.Forms.ComboBox cmbKeyStores;
      private System.Windows.Forms.Label lblKeys;
      private System.Windows.Forms.ListBox lstKeys;
      private System.Windows.Forms.Label lblKeyValuePair;
      private System.Windows.Forms.TextBox txtKeyValuePair;
      private System.Windows.Forms.Label lblResult;
      private System.Windows.Forms.TextBox txtResult;
      private System.Windows.Forms.TabControl tabArea;
      private System.Windows.Forms.TabPage tabCreate;
      private System.Windows.Forms.TabPage tabMoveKeys;
   }
}

