﻿using Emerald.Core;
using Emerald.WinUI.Enums;
using Emerald.WinUI.Helpers;

namespace Emerald.WinUI.Models
{
    public class Account : Model
    {
        private string userName;
        public string UserName { get => userName; set => Set(ref userName, value); }

        public string AccessToken { get; set; }

        public string UUID { get; set; }

        public int Count { get; set; }

        public bool Last { get; set; }

        // For app UI
        public string TypeIconGlyph { get => Type == AccountType.Offline ? "\xF384" : "\xEC05"; }

        public string ProfilePicture { get => Type != AccountType.Offline ? "https://minotar.net/avatar/" + UUID : "https://minotar.net/avatar/MHF_Steve"; }

        public string BodyPicture { get => Type != AccountType.Offline ? "https://minotar.net/body/" + UUID : "https://minotar.net/body/MHF_Steve"; }

        public string Skin { get => Type != AccountType.Offline ? "https://minotar.net/skin/" + UUID : "https://minotar.net/skin/MHF_Steve"; }

        public AccountType Type { get => UUID == null ? AccountType.Offline : AccountType.Microsoft; }

        private bool _CheckBoxLoaded;
        public bool CheckBoxLoaded { get => _CheckBoxLoaded; set => Set(ref _CheckBoxLoaded, value); }

        public string TypeString
            => IsFake ? Localized.MicrosoftOrOffline.Localize() : (IsOffline ? Localized.OfflineAccount.Localize() : Localized.MicrosoftAccount.Localize());

        private bool _IsChecked;
        public bool IsChecked { get => _IsChecked; set => Set(ref _IsChecked, value); }

        public bool IsOffline => UUID == null;

        public bool IsFake => UUID == "fake" || AccessToken == "fake";

        public Account(string username, string accesstoken, string uuid, int count, bool last)
        {
            CheckBoxLoaded = false;
            IsChecked = false;
            UserName = username;
            AccessToken = accesstoken;
            UUID = uuid;
            Count = count;
            Last = last;
        }
    }
}