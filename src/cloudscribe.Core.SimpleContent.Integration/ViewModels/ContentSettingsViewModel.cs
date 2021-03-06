﻿// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2016-08-05
// Last Modified:			2016-09-12
// 

using cloudscribe.Core.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cloudscribe.Core.SimpleContent.Integration.ViewModels
{

    public class ContentSettingsViewModel
    {
        public ContentSettingsViewModel()
        {
            Editors = new List<ISiteUser>();
        }

        public List<ISiteUser> Editors { get; set; }

        public string Title { get; set; } = "Blog";

        public bool ShowTitle { get; set; } = false;
        public string Description { get; set; } = string.Empty;
        //public string CopyrightNotice { get; set; } = string.Empty;
        //public string Image { get; set; } = string.Empty;
        public int PostsPerPage { get; set; } = 5;

        public string PubDateFormat { get; set; } = "MMMM d. yyyy";
        public bool IncludePubDateInPostUrls { get; set; } = true;

        public bool BlogMenuLinksToNewestPost { get; set; } = false;

        public int BlogPagePosition { get; set; } = 2; // right after home page


        //public string LocalMediaVirtualPath { get; set; } = "/media/images/";



        public int DaysToComment { get; set; } = -1;
        public bool ModerateComments { get; set; } = true;

        [EmailAddress(ErrorMessage = "The Notification Email field is not a valid e-mail address.")]
        [StringLength(100, ErrorMessage = "Notification Email has a maximum length of 100 characters")]
        public string CommentNotificationEmail { get; set; } = string.Empty;
        
        public string DefaultPageSlug { get; set; } = "home";
        //public bool UseDefaultPageAsRootNode { get; set; } = true;

        

        //public string AllowedEditRoles { get; set; } = "Administrators";
        

        // if true automatically add the blog index
        //public bool AddBlogToPagesTree { get; set; } = true;
        //public int BlogPagePosition { get; set; } = 2; // right after home page
        //public string BlogPageText { get; set; } = "Blog";
        //public string BlogPageNavComponentVisibility { get; set; } = "topnav";


        
        public string RemoteFeedUrl { get; set; } = string.Empty;

        /// <summary>
        /// ie Feedburner User Agent fragment "FeedBurner"
        /// </summary>
        public string RemoteFeedProcessorUseAgentFragment { get; set; } = "FeedBurner";
        public bool UseMetaDescriptionInFeed { get; set; } = false;
        public int ChannelTimeToLive { get; set; } = 60;
        public string LanguageCode { get; set; } = "en-US";
        public string ChannelCategoriesCsv { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "The Notification Email field is not a valid e-mail address.")]
        [StringLength(100, ErrorMessage = "Notification Email has a maximum length of 100 characters")]
        public string ManagingEditorEmail { get; set; } = string.Empty;
        public string ChannelRating { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "The Webmaster Email field is not a valid e-mail address.")]
        [StringLength(100, ErrorMessage = "Webmaster Email has a maximum length of 100 characters")]
        public string WebmasterEmail { get; set; } = string.Empty;

        
    }
}
