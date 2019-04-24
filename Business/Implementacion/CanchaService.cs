﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Business.Implementacion
{
    public class CanchaService : ICanchaService
    {
        private ICanchaService objCanchaService = new CanchaService();
        private IPropietarioService objPropietarioService = new PropietarioService();
        private ICalleService objCalleService = new CalleService();
        public bool Delete(int id)
        {
            return objCanchaService.Delete(id);
        }

        public List<Cancha> FindAll()
        {
            return objCanchaService.FindAll();
        }

        public Cancha FindById(int? id)
        {
            return objCanchaService.FindById(id);
        }

        public bool Insertar(Cancha t)
        {
            Propietario propietario = objPropietarioService.FindById(t.CPropietario.CUsuario);
            t.CPropietario = propietario;
            Calle calle = objCalleService.FindById(t.CCalle.CCalle);
            t.CCalle = calle;

            return objCanchaService.Insertar(t);
        }

        public bool Update(Cancha t)
        {
            return objCanchaService.Update(t);
        }
    }
}
