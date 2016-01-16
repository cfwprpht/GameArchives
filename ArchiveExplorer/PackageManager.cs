﻿using GameArchives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveExplorer
{
  class PackageManager
  {
    private static PackageManager _pm;
    public static PackageManager GetInstance()
    {
      if(_pm == null)
      {
        return (_pm = new PackageManager());
      }
      return _pm;
    }
    
    public bool Ready { get; private set; }

    public Action<IFile> Loader { get; set; }

    private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    private System.Windows.Forms.ToolStripStatusLabel spinner;
    private PackageManager()
    {
      Ready = true;
    }

    public System.Windows.Forms.ToolStripStatusLabel Spinner
    {
      set { spinner = value; }
    }
    public System.Windows.Forms.ToolStripStatusLabel StatusLabel
    {
      set { statusLabel = value; }
    }

    public void SetReady()
    {
      Ready = true;
      if(spinner != null)
        spinner.Visible = false;
      if (statusLabel != null)
        statusLabel.Text = "Ready.";
    }

    public void SetBusyState(string busyState)
    {
      Ready = false;
      if (spinner != null)
        spinner.Visible = true;
      if (statusLabel != null)
        statusLabel.Text = busyState;
    }

    public void LoadFile(IFile f, AbstractPackage owner = null)
    {
      Loader(f);
    }
  }
}
