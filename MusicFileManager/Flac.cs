using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFileManager
{
    public class Flac : IFile
    {
        public string Filepath { get; private set; }

        public TagLib.Tag Tag { get; private set; }


        public override string ToString()
        {
            string ret = "";
            ret += "Album:" + (string.Join(", ", Tag.Album)) + "\r\n";
            ret += "AlbumArtists:" + (string.Join(", ", Tag.AlbumArtists)) + "\r\n";
            ret += "AlbumArtistsSort:" + (string.Join(", ", Tag.AlbumArtistsSort)) + "\r\n";
            ret += "AlbumSort:" + (string.Join(", ", Tag.AlbumSort)) + "\r\n";
            ret += "AmazonId:" + (string.Join(", ", Tag.AmazonId)) + "\r\n";
            ret += "BeatsPerMinute:" + (string.Join(", ", Tag.BeatsPerMinute)) + "\r\n";
            ret += "Comment:" + (string.Join(", ", Tag.Comment)) + "\r\n";
            ret += "Composers:" + (string.Join(", ", Tag.Composers)) + "\r\n";
            ret += "ComposersSort:" + (string.Join(", ", Tag.ComposersSort)) + "\r\n";
            ret += "Conductor:" + (string.Join(", ", Tag.Conductor)) + "\r\n";
            ret += "Copyright:" + (string.Join(", ", Tag.Copyright)) + "\r\n";
            ret += "Disc:" + (string.Join(", ", Tag.Disc)) + "\r\n";
            ret += "DiscCount:" + (string.Join(", ", Tag.DiscCount)) + "\r\n";
            ret += "FirstAlbumArtist:" + (string.Join(", ", Tag.FirstAlbumArtist)) + "\r\n";
            ret += "FirstAlbumArtistSort:" + (string.Join(", ", Tag.FirstAlbumArtistSort)) + "\r\n";
            ret += "FirstComposer:" + (string.Join(", ", Tag.FirstComposer)) + "\r\n";
            ret += "FirstComposerSort:" + (string.Join(", ", Tag.FirstComposerSort)) + "\r\n";
            ret += "FirstGenre:" + (string.Join(", ", Tag.FirstGenre)) + "\r\n";
            ret += "FirstPerformer:" + (string.Join(", ", Tag.FirstPerformer)) + "\r\n";
            ret += "FirstPerformerSort:" + (string.Join(", ", Tag.FirstPerformerSort)) + "\r\n";
            ret += "Genres:" + (string.Join(", ", Tag.Genres)) + "\r\n";
            ret += "Grouping:" + (string.Join(", ", Tag.Grouping)) + "\r\n";
            ret += "IsEmpty:" + (string.Join(", ", Tag.IsEmpty)) + "\r\n";
            ret += "JoinedAlbumArtists:" + (string.Join(", ", Tag.JoinedAlbumArtists)) + "\r\n";
            ret += "JoinedComposers:" + (string.Join(", ", Tag.JoinedComposers)) + "\r\n";
            ret += "JoinedGenres:" + (string.Join(", ", Tag.JoinedGenres)) + "\r\n";
            ret += "JoinedPerformers:" + (string.Join(", ", Tag.JoinedPerformers)) + "\r\n";
            ret += "JoinedPerformersSort:" + (string.Join(", ", Tag.JoinedPerformersSort)) + "\r\n";
            ret += "Lyrics:" + (string.Join(", ", Tag.Lyrics)) + "\r\n";
            ret += "MusicBrainzArtistId:" + (string.Join(", ", Tag.MusicBrainzArtistId)) + "\r\n";
            ret += "MusicBrainzDiscId:" + (string.Join(", ", Tag.MusicBrainzDiscId)) + "\r\n";
            ret += "MusicBrainzReleaseArtistId:" + (string.Join(", ", Tag.MusicBrainzReleaseArtistId)) + "\r\n";
            ret += "MusicBrainzReleaseCountry:" + (string.Join(", ", Tag.MusicBrainzReleaseCountry)) + "\r\n";
            ret += "MusicBrainzReleaseId:" + (string.Join(", ", Tag.MusicBrainzReleaseId)) + "\r\n";
            ret += "MusicBrainzReleaseStatus:" + (string.Join(", ", Tag.MusicBrainzReleaseStatus)) + "\r\n";
            ret += "MusicBrainzReleaseType:" + (string.Join(", ", Tag.MusicBrainzReleaseType)) + "\r\n";
            ret += "MusicBrainzTrackId:" + (string.Join(", ", Tag.MusicBrainzTrackId)) + "\r\n";
            ret += "MusicIpId:" + (string.Join(", ", Tag.MusicIpId)) + "\r\n";
            ret += "Performers:" + (string.Join(", ", Tag.Performers)) + "\r\n";
            ret += "PerformersSort:" + (string.Join(", ", Tag.PerformersSort)) + "\r\n";
            ret += "TagTypes:" + (string.Join(", ", Tag.TagTypes)) + "\r\n";
            ret += "Title:" + (string.Join(", ", Tag.Title)) + "\r\n";
            ret += "TitleSort:" + (string.Join(", ", Tag.TitleSort)) + "\r\n";
            ret += "Track:" + (string.Join(", ", Tag.Track)) + "\r\n";
            ret += "TrackCount:" + (string.Join(", ", Tag.TrackCount)) + "\r\n";
            ret += "Year:" + (string.Join(", ", Tag.Year)) + "\r\n";

            return ret;
        }

        public void Load(string filepath)
        {
            TagLib.File f = TagLib.File.Create(filepath);
            Tag = f.Tag;
            f.Dispose();
        }
    }
}
