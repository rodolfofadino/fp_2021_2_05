using CodeHollow.FeedReader;
using fiapweb.core.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fiapweb.core.Services
{
    public class NoticiaService : INoticiaService
    {
        private IMemoryCache _cache;

        public NoticiaService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public List<Noticia> Load(int totalDeNoticias)
        {

            var cacheKey = $"noticias_{totalDeNoticias}";

            List<Noticia> noticias;// = new List<Noticia>();
            
            if (!_cache.TryGetValue<List<Noticia>>(cacheKey, out noticias))
            {
                noticias = new List<Noticia>();

                var feed = FeedReader.ReadAsync("https://g1.globo.com/rss/g1/turismo-e-viagem/").Result;

                foreach (var item in feed.Items)
                {
                    var feedItem = item.SpecificItem as CodeHollow.FeedReader.Feeds.MediaRssFeedItem;
                    var media = feedItem.Media;
                    var url = "";
                    if (media.Any())
                        url = media.FirstOrDefault().Url;
                    noticias.Add(new Noticia() { Id = 1, Titulo = item.Title, Link = item.Link, Imagem = url });
                }

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(15));
                //.SetSlidingExpiration(new TimeSpan());

                _cache.Set(cacheKey, noticias, cacheOptions);

            }

            return noticias;
        }

    }
}