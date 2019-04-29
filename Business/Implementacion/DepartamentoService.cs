using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;
using Data.Implementacion;

namespace Business.Implementacion
{
    public class DepartamentoService : IDepartamentoService
    {
        private IDepartamentoRepository objDepartamentoService = new DepartamentoRepository();
        public bool Delete(int id)
        {
            return objDepartamentoService.Delete(id);
        }

        public List<Departamento> FindAll()
        {
            return objDepartamentoService.FindAll();
        }

        public Departamento FindById(int? id)
        {
            return objDepartamentoService.FindById(id);
        }

        public bool Insertar(Departamento t)
        {
            return objDepartamentoService.Insertar(t);
        }

        public bool Update(Departamento t)
        {
            return objDepartamentoService.Update(t);
        }
    }
}
