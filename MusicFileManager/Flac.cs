using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicFileManager
{
    [Serializable]
    public class Flac : IFile, ISerializable
    {
        const string ThumbFileDir = "./Thumbs/";

        public string Filepath { get; private set; }

        public TagLib.Tag Tag { get; private set; }


        public override string ToString()
        {
            string ret = "[metadata]";
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
            ret += "PicThumb:" + GetThumbPath() + "\r\n";

            ret += "[Properties]\r\n";
            ret += "AudioBitrate:" + Properties.AudioBitrate + "\r\n";
            ret += "AudioChannels:" + Properties.AudioChannels + "\r\n";
            ret += "AudioSampleRate:" + Properties.AudioSampleRate+ "\r\n";
            ret += "BitsPerSample:" + Properties.BitsPerSample+ "\r\n";
            ret += "Codecs:" + (string.Join(", ",  Properties.Codecs))+ "\r\n";
            ret += "Description:" + Properties.Description+ "\r\n";
            ret += "Duration:" + Properties.Duration+ "\r\n";
            ret += "MediaTypes:" + Properties.MediaTypes+ "\r\n";
            ret += "PhotoHeight:" + Properties.PhotoHeight+ "\r\n";
            ret += "PhotoWidth:" + Properties.PhotoWidth+ "\r\n";
            ret += "PhotoQuality:" + Properties.PhotoQuality+ "\r\n";
            ret += "VideoHeight:" + Properties.VideoHeight+ "\r\n";
            ret += "VideoWidth:" + Properties.VideoWidth+ "\r\n";

            return ret;
        }
        public TagLib.Properties Properties { get; set; }

        public void Load(string filepath)
        {
            Filepath = filepath;
            TagLib.File f = TagLib.File.Create(filepath, TagLib.ReadStyle.Average);
            Tag = f.Tag;
            Properties = f.Properties;

            SaveThumb();
            f.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private StringBuilder GetThumbPath()
        {
            if (Tag.Pictures.Length == 0) return null;
            StringBuilder targetFilePath = null;
            foreach (TagLib.IPicture pic in Tag.Pictures)
            {
                if(pic.Type == TagLib.PictureType.FrontCover)
                {
                    targetFilePath = new StringBuilder(ThumbFileDir);
                    targetFilePath.Append(Filepath.GetHashCode().ToString("x"));
                    // 拡張子決定
                    targetFilePath.Append(".").Append(pic.MimeType.Substring(6));
                }
            }
            return targetFilePath;
        }


        /// <summary>
        /// 
        /// </summary>
        public void SaveThumb()
        {
            StringBuilder sb = GetThumbPath();
            if (sb == null) return;
            // 最も小さいものをサムネイルとして保存する
            int minDataSize = int.MaxValue;
            TagLib.IPicture targetPic = null;
            foreach (TagLib.IPicture pic in Tag.Pictures)
            {
                if(pic.Data.Count < minDataSize)
                {
                    minDataSize = pic.Data.Count;
                    targetPic = pic;
                }
            }
            if (targetPic == null) return;
            string strPath = sb.ToString();
            if (!System.IO.Directory.Exists(ThumbFileDir))
            {
                System.IO.Directory.CreateDirectory(ThumbFileDir);
            }
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(System.IO.File.Open(strPath, System.IO.FileMode.Create));
            bw.Write(targetPic.Data.Data);
            bw.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        public void LoadThumb()
        {
            StringBuilder sb = GetThumbPath();
            string strPath = sb.ToString();
            if (!System.IO.Directory.Exists(ThumbFileDir))
            {
                return;
            }
            System.IO.BinaryReader br = new System.IO.BinaryReader(System.IO.File.Open(sb.ToString(), System.IO.FileMode.Open));
            Console.WriteLine("FileSize: {0}byte" ,br.BaseStream.Length);
            br.Close();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Tag) + "." + nameof(Tag.Album), Tag.Album);
            info.AddValue("Tag.AlbumArtists", Tag.AlbumArtists);
            info.AddValue("Tag.AlbumArtistsSort", Tag.AlbumArtistsSort);
            info.AddValue("Tag.AlbumSort", Tag.AlbumSort);
            info.AddValue("Tag.AmazonId", Tag.AmazonId);
            info.AddValue("Tag.Artists", Tag.Artists);
            var name = nameof(Tag.AmazonId);

            info.AddValue("Properties.AudioBitrate", Properties.AudioBitrate);
        }
    }
}
