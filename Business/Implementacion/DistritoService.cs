﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;
using Data.Implementacion;
namespace Business.Implementacion
{
    public class DistritoService : IDistritoService
    {
        private IDistritoRepository objDistritoRep = new DistritoRepository();
        private ICiudadRepository objCiudadRep = new CiudadRepository();
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Distrito> FindAll()
        {
            return objDistritoRep.FindAll();
        }

        public Distrito FindById(int? id)
        {    
           
            throw new NotImplementedException();
        }

        public bool Insertar(Distrito t)
        {
            return objDistritoRep.Insertar(t);
        }

        public bool Update(Distrito t)
        {
            throw new NotImplementedException();
        }
    }
}
