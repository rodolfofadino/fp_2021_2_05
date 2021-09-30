using fiapweb.core.Models;
using System.Collections.Generic;

namespace fiapweb.core.Services
{
    public interface INoticiaService
    {
        List<Noticia> Load(int totalDeNoticias);
    }
}