﻿using CmlLib.Core.Downloader;
using System;
using System.Collections.Generic;
using System.Text;

namespace SDLauncher.Core.Args
{
    public class UIChangeRequestedEventArgs : EventArgs
    {
        public bool UI { get; private set; }
        public UIChangeRequestedEventArgs(bool ui)
        {
            this.UI = ui;
        }
    }
    public class StatusChangedEventArgs : EventArgs
    {
        public string Status { get; private set; }
        public StatusChangedEventArgs(string status)
        {
            this.Status = status;
        }
    }
    public class ProgressChangedEventArgs : EventArgs
    {
        public int? MaxFiles { get; private set; }
        //
        public int? CurrentFile { get; private set; }
        //
        public int? MainProgressPercentage { get; private set; }
        public DownloadFileChangedEventArgs DownloadArgs { get; private set; }
        public ProgressChangedEventArgs(int? currentfile = null, int? maxfiles = null, int? currentProg = null, DownloadFileChangedEventArgs args = null)
        {
            MaxFiles = maxfiles;
            CurrentFile = currentfile;
            MainProgressPercentage = currentProg;
            DownloadArgs = args;
        }
    }
    public class VersionsRefreshedEventArgs : EventArgs
    {
        public bool Success { get; private set; }
        public VersionsRefreshedEventArgs(bool success)
        {
            Success = success;
        }
    }
}
