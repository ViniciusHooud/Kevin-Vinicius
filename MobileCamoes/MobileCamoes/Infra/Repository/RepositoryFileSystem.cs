using MobileCamoes.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MobileCamoes.Infra.Repository
{
    public class RepositoryFileSystem : ISerieRepository
    {
        StreamWriter CamoesFile;
        StreamReader CamoesFileLeitor;

        public RepositoryFileSystem()
        {
            CamoesFile = new StreamWriter(AppSettings.OfflineFileSystemPath);
            CamoesFileLeitor = new StreamReader(CamoesFile.BaseStream);
        }

        public void Add(Serie entity)
        {
            CamoesFile.WriteLine("Id = " + entity.Id  + " | Name = " + entity.Name + " | Overview" + entity.Overview);
        }

        public bool Exist(Serie entity)
        {
            return CamoesFileLeitor.ReadToEnd().Contains("Id = " + entity.Id);
        }

        public bool Exist(int id)
        {
            return CamoesFileLeitor.ReadToEnd().Contains("Id = " + id);
        }

        public IEnumerable<Serie> Get()
        {
            List<Serie> series = new List<Serie>();

           while( CamoesFileLeitor.EndOfStream)
           {
                string linha = CamoesFileLeitor.ReadLine();

                var objetos = linha.Split('|');

                Serie serie = new Serie();
                serie.Id = Convert.ToInt32(objetos[0]);
                serie.Name = objetos[1];
                serie.Overview = objetos[2];

                series.Add(null);
           }
            return series;
        }

        public Serie Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Serie entity)
        {
            throw new NotImplementedException();
        }
    }
}
