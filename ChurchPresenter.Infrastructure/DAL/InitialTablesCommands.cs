using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace ChurchPresenter.Infrastructure.DAL
{
    internal static class InitialTablesCommands
    {
        public static readonly string CreateSongTable = (
                    @"create table if not exists Songs
                (
                    Id                         integer identity primary key AUTOINCREMENT,
                    Title                      varchar(100) not null,
                    Artist                     varchar(100) not null,
                    Tags                       varchar(100)
                    VerseNumber                integer not null,
                    LineNumber                 integer not null,
                    Lyrics                     varchar(200) not null
                    Language                   varchar(20) not null,
                )");

        public static readonly string CreateHymnTable = (
                    @"create table if not exists HymnLyrics
                (
                    Id                         integer identity primary key AUTOINCREMENT,
                    HymnBookAbbr               varchar(10) not null,
                    HymnNumber                 integer not null,
                    VerseNumber                integer not null
                    LineNumber                 varchar(100) not null,
                    Lyrics                     varchar(200) not null
                    Language                   varchar(20) not null,
                )");

        public static readonly string CreateHymnMetaTable = (
                   @"create table if not exists HymnMetas
                (
                    Id                         integer identity primary key AUTOINCREMENT,
                    HymnNumber                 varchar(100) not null,
                    Authors                    varchar(100) not null
                    YearWritten                varchar(100) not null,
                    History                    text not null
                    Tags                       varchar(100) not null,
                )");
    }
    
}
