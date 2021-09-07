

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoContentPipeline.Models.Exceptions;
using VideoContentPipeline.Models.v1_0;

namespace VideoContentPipeline.Services
{
    public class VideoService: IVideoService
    {
        private readonly ApiContext apiContext;

        public VideoService(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        private void ValidateMetaData(VideoMetaData data)
        {
            if(data == null)
            {
                throw new ArgumentNullException("The argument 'data' cannot be null");
            }

            if(string.IsNullOrWhiteSpace(data.Id))
            {
                throw new IdentityNullException("The property 'Id' cannot be null");    
            }
        }

        private void ValidateUrl(string url)
        {
            if(string.IsNullOrWhiteSpace(url))
            {
                throw new UriFormatException("The video URL cannot be null");
            }
            
            if(!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                throw new UriFormatException($"The video URL ${url} is not valid.");
            }            
        }

        private async Task<bool> saveChanges()
        {
           return (await apiContext.SaveChangesAsync()) > 0;
        }

        public async Task<bool> Create(VideoMetaData data)
        {
            ValidateMetaData(data);

            apiContext.Videos.Add(new Video() {
                Id = data.Id,
                Title = data.Title,
                Description = data.Description,
                ThemeId = data.ThemeId,
                CreatedAt = DateTime.Now
            });

            return await saveChanges();
        }

        public async Task<bool> Update(VideoMetaData data)
        {
            ValidateMetaData(data);
            
            var video = GetById(data.Id);

            video.Title = data.Title;
            video.Description = data.Description;
            video.ThemeId = data.ThemeId;
            video.UpdatedAt = DateTime.Now;

            apiContext.Videos.Update(video);

            return await saveChanges();
        }

        public async Task<bool> Delete(string id)
        {
            var video = GetById(id);

            apiContext.Videos.Remove(video);

            return await saveChanges();
        }


        public async Task<bool> UpdateVideoUrl(VideoLocation location)
        {
            if(string.IsNullOrWhiteSpace(location.VideoId))
            {
                throw new IdentityNullException("The property VideoId cannot be null");
            }

            ValidateUrl(location.VideoUrl);

            var video = GetById(location.VideoId);

            video.Url = location.VideoUrl;
            video.UpdatedAt = DateTime.Now;

            apiContext.Update(video);

            return await saveChanges();
            
        }

        public Video GetById(string id)
        {
            if(string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("The argument 'id' cannot be null");
            }
            var video = apiContext.Videos
                .Where(v => v.Id == id)
                .FirstOrDefault();

            if(video == null)
            {
                throw new VideoNotFoundException($"The video with Id {id} was not found");
            }

            return video;
        }

        public IEnumerable<Video> GetByThemeId(string themeId)
        {
            return apiContext.Videos.Where(v => v.ThemeId == themeId);
        }
    }
}