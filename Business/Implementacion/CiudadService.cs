using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Business.Implementacion
{
    public class CiudadService : ICiudadService
    {
        private ICiudadService objCiudadService = new CiudadService();
        private IDepartamentoService objDepartamentoService = new DepartamentoService();
        public bool Delete(int id)
        {
            return objCiudadService.Delete(id);
        }

        public List<Ciudad> FindAll()
        {
            return objCiudadService.FindAll();
        }

        public Ciudad FindById(int? id)
        {
            return objCiudadService.FindById(id);
        }

        public bool Insertar(Ciudad t)
        {
            Departamento departamento = objDepartamentoService.FindById(t.CDepartamento.CDepartamento);
            t.CDepartamento = departamento;

            return objCiudadService.Insertar(t);
        }

        public bool Update(Ciudad t)
        {
            return objCiudadService.Update(t);
        }
    }
}
