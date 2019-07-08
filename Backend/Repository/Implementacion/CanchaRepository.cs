using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;
using System.Configuration;
using Repository.ViewModel;
using Repository.dbcontext;
namespace Repository.Implementacion
{
    public class CanchaRepository : ICanchaRepository
    {
            ApplicationDbContext context;
            public CanchaRepository(ApplicationDbContext context){
                this.context=context;
            }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Cancha Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cancha> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CanchaViewModel> ListarTodos()
        {
           var cancha=new List<Cancha>();
           cancha=context.Cancha.ToList();
           var ncalle=new List<string>();
           var calles=new List<Calle>();
           foreach(var c in cancha){
               var calle=context.Calle.FirstOrDefault(x=>x.Ccalle==c.Ccalle);
               calles.Add(calle);
               var nombre=calle.Ncalle;
               ncalle.Add(nombre);
           }
           var ndistrito=new List<string>();
           foreach(var c in calles){
               var distrito=context.Distrito.FirstOrDefault(d=>d.Cdistrito==c.Cdistrito);
               var nombre=distrito.Ndistrito;
               ndistrito.Add(nombre);
           }
            List<CanchaViewModel> canchavm=new List<CanchaViewModel>();
            foreach(var c in cancha){
                canchavm.Add(new CanchaViewModel{
                    Ccancha=c.Ccancha,
                    Ncancha=c.Ncancha,
                    Cpropietario=c.Cpropietario,
                    Ccalle=c.Ccalle,
                    Tdireccion=c.Tdireccion,
                    MprecioHora=c.MprecioHora
                });
            }
            for(var i=0;i<canchavm.Count();i++){
                canchavm.ElementAt(i).Ndistrito=ndistrito.ElementAt(i);
                canchavm.ElementAt(i).Ncalle=ncalle.ElementAt(i);
            }
            return canchavm;
        }

        public bool Save(Cancha entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cancha entity)
        {
            throw new NotImplementedException();
        }
    }
}
