using System.Windows.Forms;
namespace Flare
{
   partial class OAuthWindow
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose( bool disposing )
      {
         if ( disposing && ( components != null ) )
         {
            components.Dispose();
         }
         base.Dispose( disposing );
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this._webBrowser = new WebBrowser();
         this.SuspendLayout();
         // 
         // _webBrowser
         // 
         this._webBrowser.AllowWebBrowserDrop = false;
         this._webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
         this._webBrowser.Location = new System.Drawing.Point(0, 0);
         this._webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
         this._webBrowser.Name = "_webBrowser";
         this._webBrowser.ScrollBarsEnabled = false;
         this._webBrowser.Size = new System.Drawing.Size(1076, 469);
         this._webBrowser.TabIndex = 0;
         this._webBrowser.WebBrowserShortcutsEnabled = false;
         this._webBrowser.IsWebBrowserContextMenuEnabled = false;
         this._webBrowser.ScriptErrorsSuppressed = true;
         // 
         // OAuthWindow
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoSize = true;
         this.ClientSize = new System.Drawing.Size(1076, 469);
         this.Controls.Add(this._webBrowser);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
         this.Name = "OAuthWindow";
         this.Text = "37Signals Authorization";
         this.ResumeLayout(false);

      }

      #endregion

      private WebBrowser _webBrowser;
   }
}