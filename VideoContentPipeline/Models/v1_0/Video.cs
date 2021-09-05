
using System;

namespace VideoContentPipeline.Models.v1_0
{
    [Serializable]
    public class Video: VideoMetaData
    {
        public string Url {get; set;}        

        public DateTime CreatedAt {get; set;}

        public DateTime? UpdatedAt {get; set;}
    }
}