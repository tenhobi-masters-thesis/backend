﻿namespace KingKarel.Database;

public static class PsqlConnectionStringParser
{
    internal static string GetEfConnectionString(string connectionUrl)
    {
        bool isUrl = Uri.TryCreate(connectionUrl, UriKind.Absolute, out Uri? url);
        if (isUrl && url != null)
        {
            return
                $"host={url.Host};username={url.UserInfo.Split(':')[0]};password={url.UserInfo.Split(':')[1]};database={url.LocalPath.Substring(1)};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;";
        }

        return connectionUrl;
    }
}