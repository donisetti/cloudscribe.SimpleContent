﻿// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Author:					Joe Audette
// Created:					2016-08-31
// Last Modified:			2016-09-04
// 

using cloudscribe.SimpleContent.Models;
using cloudscribe.SimpleContent.Storage.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cloudscribe.SimpleContent.Storage.EFCore
{
    public class SqlServerSimpleContentModelMapper : ISimpleContentModelMapper
    {
        public SqlServerSimpleContentModelMapper(SimpleContentTableNames tableNames = null)
        {
            this.tableNames = tableNames ?? new SimpleContentTableNames();
        }

        private SimpleContentTableNames tableNames;

        public void Map(EntityTypeBuilder<ProjectSettings> entity)
        {
            entity.ForSqlServerToTable(tableNames.TablePrefix + tableNames.ProjectTableName);

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id)
            .HasMaxLength(36)
            ;

            entity.Property(p => p.Title)
            .HasMaxLength(255)
            ;

            entity.Property(p => p.CopyrightNotice)
            .HasMaxLength(255)
            ;

            entity.Property(p => p.ModerateComments)
            .IsRequired()
            .ForSqlServerHasColumnType("bit")
            .ForSqlServerHasDefaultValue(true)
            ;

            entity.Property(p => p.CommentNotificationEmail)
            .HasMaxLength(100)
            ;

            entity.Property(p => p.BlogMenuLinksToNewestPost)
            .IsRequired()
            .ForSqlServerHasColumnType("bit")
            .ForSqlServerHasDefaultValue(false)
            ;

            entity.Property(p => p.LocalMediaVirtualPath)
            .HasMaxLength(255)
            ;

            entity.Property(p => p.CdnUrl)
            .HasMaxLength(255)
            ;

            entity.Property(p => p.PubDateFormat)
            .HasMaxLength(75)
            ;

            entity.Property(p => p.IncludePubDateInPostUrls)
            .IsRequired()
            .ForSqlServerHasColumnType("bit")
            .ForSqlServerHasDefaultValue(true)
            ;

            entity.Property(p => p.TimeZoneId)
            .HasMaxLength(100)
            ;

            entity.Property(p => p.RecaptchaPrivateKey)
            .HasMaxLength(255)
            ;

            entity.Property(p => p.RecaptchaPublicKey)
            .HasMaxLength(255)
            ;

            entity.Property(p => p.DefaultPageSlug)
            .HasMaxLength(255)
            ;

            entity.Property(p => p.UseDefaultPageAsRootNode)
            .IsRequired()
            .ForSqlServerHasColumnType("bit")
            .ForSqlServerHasDefaultValue(true)
            ;

            entity.Property(p => p.ShowTitle)
            .IsRequired()
            .ForSqlServerHasColumnType("bit")
            .ForSqlServerHasDefaultValue(false)
            ;

            entity.Property(p => p.AddBlogToPagesTree)
            .IsRequired()
            .ForSqlServerHasColumnType("bit")
            .ForSqlServerHasDefaultValue(true)
            ;

            entity.Property(p => p.BlogPageText)
            .HasMaxLength(255)
            ;

            entity.Property(p => p.BlogPageNavComponentVisibility)
            .HasMaxLength(255)
            ;

            entity.Property(p => p.Image)
            .HasMaxLength(255)
            ;

            entity.Property(p => p.UseMetaDescriptionInFeed)
            .IsRequired()
            .ForSqlServerHasColumnType("bit")
            .ForSqlServerHasDefaultValue(false)
            ;

            entity.Property(p => p.LanguageCode)
           .HasMaxLength(10)
           ;

            entity.Property(p => p.ChannelCategoriesCsv)
            .HasMaxLength(255)
            ;

            entity.Property(p => p.ManagingEditorEmail)
            .HasMaxLength(100)
            ;

            entity.Property(p => p.ChannelRating)
            .HasMaxLength(100)
            ;

            entity.Property(p => p.WebmasterEmail)
            .HasMaxLength(100)
            ;

            entity.Property(p => p.RemoteFeedUrl)
            .HasMaxLength(255)
            ;

            entity.Property(p => p.RemoteFeedProcessorUseAgentFragment)
            .HasMaxLength(255)
            ;

            entity.Property(p => p.EmailFromAddress)
            .HasMaxLength(100)
            ;

            entity.Property(p => p.SmtpServer)
            .HasMaxLength(100)
            ;

            entity.Property(p => p.SmtpPort)
            //.IsRequired()
            //.ForSqlServerHasColumnType("int")
            //.HasDefaultValue(25)
            //.ValueGeneratedNever()
            ;

            entity.Property(p => p.SmtpUser)
            .HasMaxLength(500)
            ;

            entity.Property(p => p.SmtpPassword)
            ;

            entity.Property(p => p.SmtpPreferredEncoding)
            .HasMaxLength(20);
            ;

            entity.Property(p => p.SmtpRequiresAuth)
            .IsRequired()
            .ForSqlServerHasColumnType("bit")
            .ForSqlServerHasDefaultValue(false)
            ;

            entity.Property(p => p.SmtpUseSsl)
            .IsRequired()
            .ForSqlServerHasColumnType("bit")
            .ForSqlServerHasDefaultValue(false)
            ;

        }

        public void Map(EntityTypeBuilder<PostEntity> entity)
        {
            entity.ForSqlServerToTable(tableNames.TablePrefix + tableNames.PostTableName);

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id)
            .HasMaxLength(36)
            ;

            entity.Property(p => p.BlogId)
            .HasMaxLength(36)
            .IsRequired()
            ;
            entity.HasIndex(p => p.BlogId);

            entity.Property(p => p.Title)
            .HasMaxLength(255)
            .IsRequired()
            ;

            entity.Property(p => p.Author)
            .HasMaxLength(255)
            ;

            entity.Property(p => p.Slug)
            .HasMaxLength(255)
            .IsRequired()
            ;
            entity.HasIndex(p => p.Slug);

            entity.Property(p => p.MetaDescription)
            .HasMaxLength(500)
            ;

            entity.Property(p => p.IsPublished)
            .IsRequired()
            .ForSqlServerHasColumnType("bit")
            .ForSqlServerHasDefaultValue(true)
            ;

            entity.Ignore(p => p.Categories);

            entity.Property(p => p.CategoriesCsv)
            .HasMaxLength(500)
            ;

            entity.Ignore(p => p.Comments);

            // will this create a shadow foriegn key?
            entity.HasMany(p => p.PostComments)
                .WithOne()
               
            ;

            // a shadow property to persist the categories/tags as a csv
            //entity.Property<string>("CategoryCsv");

        }

        public void Map(EntityTypeBuilder<PostComment> entity)
        {
            entity.ForSqlServerToTable(tableNames.TablePrefix + tableNames.PostCommentTableName);

            //entity.HasDiscriminator<string>("comment_type")
            //    .HasValue<Comment>("comment_base")
            //    .HasValue<PageComment>("comment_page");

            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id)
            .HasMaxLength(36)
            ;

            entity.Ignore(p => p.ContentId); //mapped from postid

            entity.Property(p => p.PostEntityId)
            .HasMaxLength(36)
            //.IsRequired()
            ;
            entity.HasIndex(p => p.PostEntityId);

            entity.Property(p => p.ProjectId)
            .HasMaxLength(36)
            .IsRequired()
            ;
            entity.HasIndex(p => p.ProjectId);

            entity.Property(p => p.Author)
           .HasMaxLength(255)
           ;

            entity.Property(p => p.Email)
           .HasMaxLength(100)
           ;

            entity.Property(p => p.Website)
           .HasMaxLength(255)
           ;

            entity.Property(p => p.Ip)
           .HasMaxLength(100)
           ;

            entity.Property(p => p.UserAgent)
           .HasMaxLength(255)
           ;

        }

        public void Map(EntityTypeBuilder<PostCategory> entity)
        {
            entity.ForSqlServerToTable(tableNames.TablePrefix + tableNames.PostCategoryTableName);

            entity.HasKey(p => new { p.Value, p.PostEntityId });

            entity.Property(p => p.Value)
            .HasMaxLength(50)
            .IsRequired()
            ;

            entity.HasIndex(p => p.Value);

            entity.Property(p => p.PostEntityId)
            .HasMaxLength(36)
            .IsRequired()
            ;
            entity.HasIndex(p => p.PostEntityId);

            entity.Property(p => p.ProjectId)
            .HasMaxLength(36)
            .IsRequired()
            ;
            entity.HasIndex(p => p.ProjectId);
            
        }

        public void Map(EntityTypeBuilder<PageEntity> entity)
        {
            entity.ForSqlServerToTable(tableNames.TablePrefix + tableNames.PageTableName);

            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id)
            .HasMaxLength(36)
            ;

            entity.Property(p => p.ProjectId)
            .HasMaxLength(36)
            .IsRequired()
            ;
            entity.HasIndex(p => p.ProjectId);

            entity.Property(p => p.Title)
            .HasMaxLength(255)
            .IsRequired()
            ;

            entity.Property(p => p.ParentId)
            .HasMaxLength(36)
            ;
            entity.HasIndex(p => p.ParentId);

            entity.Property(p => p.ParentSlug)
            .HasMaxLength(255)
            ;

            entity.Property(p => p.Author)
           .HasMaxLength(255)
           ;

            entity.Property(p => p.Slug)
            .HasMaxLength(255)
            .IsRequired()
            ;

            entity.Property(p => p.MetaDescription)
            .HasMaxLength(500)
            ;

            entity.Property(p => p.IsPublished)
            .IsRequired()
            .ForSqlServerHasColumnType("bit")
            .ForSqlServerHasDefaultValue(true)
            ;


            entity.Property(p => p.ShowHeading)
            .IsRequired()
            .ForSqlServerHasColumnType("bit")
            .ForSqlServerHasDefaultValue(true)
            ;

            entity.Property(p => p.ShowPubDate)
            .IsRequired()
            .ForSqlServerHasColumnType("bit")
            .ForSqlServerHasDefaultValue(false)
            ;

            entity.Property(p => p.ShowLastModified)
            .IsRequired()
            .ForSqlServerHasColumnType("bit")
            .ForSqlServerHasDefaultValue(false)
            ;

            entity.Property(p => p.ShowCategories)
            .IsRequired()
            .ForSqlServerHasColumnType("bit")
            .ForSqlServerHasDefaultValue(false)
            ;

            entity.Property(p => p.ShowComments)
            .IsRequired()
            .ForSqlServerHasColumnType("bit")
            .ForSqlServerHasDefaultValue(false)
            ;

            entity.Ignore(p => p.Categories);

            entity.Property(p => p.CategoriesCsv)
            .HasMaxLength(500)
            ;

            entity.Ignore(p => p.Comments);

            entity.HasMany(p => p.PageComments)
                .WithOne();

            // a shadow property to persist the categories/tags as a csv
            //entity.Property<string>("CategoryCsv");

        }

        public void Map(EntityTypeBuilder<PageComment> entity)
        {
            entity.ForSqlServerToTable(tableNames.TablePrefix + tableNames.PageCommentTableName);

            //entity.HasDiscriminator<string>("comment_type")
            //    .HasValue<Comment>("comment_base")
            //    .HasValue<PageComment>("comment_page");

            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id)
            .HasMaxLength(36)
            ;

            entity.Ignore(p => p.ContentId); //mapped from postid

            entity.Property(p => p.PageEntityId)
            .HasMaxLength(36)
            //.IsRequired()
            ;
            entity.HasIndex(p => p.PageEntityId);

            entity.Property(p => p.ProjectId)
            .HasMaxLength(36)
            .IsRequired()
            ;
            entity.HasIndex(p => p.ProjectId);

            entity.Property(p => p.Author)
           .HasMaxLength(255)
           ;

            entity.Property(p => p.Email)
           .HasMaxLength(100)
           ;

            entity.Property(p => p.Website)
           .HasMaxLength(255)
           ;

            entity.Property(p => p.Ip)
           .HasMaxLength(100)
           ;

            entity.Property(p => p.UserAgent)
           .HasMaxLength(255)
           ;

        }

        public void Map(EntityTypeBuilder<PageCategory> entity)
        {
            entity.ForSqlServerToTable(tableNames.TablePrefix + tableNames.PageCategoryTableName);

            entity.HasKey(p => new { p.Value, p.PageEntityId });

            entity.Property(p => p.Value)
            .HasMaxLength(50)
            .IsRequired()
            ;

            entity.HasIndex(p => p.Value);

            entity.Property(p => p.PageEntityId)
            .HasMaxLength(36)
            .IsRequired()
            ;
            entity.HasIndex(p => p.PageEntityId);

            entity.Property(p => p.ProjectId)
            .HasMaxLength(36)
            .IsRequired()
            ;
            entity.HasIndex(p => p.ProjectId);

        }


    }
}
