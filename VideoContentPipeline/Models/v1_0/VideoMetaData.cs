
using System;

namespace VideoContentPipeline.Models.v1_0
{
    [Serializable]
    public class VideoMetaData
    {
        public string Id { get; set;}

        public string Title {get; set;}
        
        public string Description {get; set;}        

        public string ThemeId {get; set;}
    }
}