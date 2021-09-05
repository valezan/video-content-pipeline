using System.Collections.Generic;
using System.Threading.Tasks;
using VideoContentPipeline.Models.v1_0;

namespace VideoContentPipeline.Services
{
    public interface IVideoService
    {
        Task<bool> Create(VideoMetaData data);

        Task<bool> Update(VideoMetaData data);

        Task<bool> Delete(string id);

        Task<bool> UpdateVideoUrl(VideoLocation location);

        Video GetById(string id);

        IEnumerable<Video> GetByThemeId(string themeId);
    }
}