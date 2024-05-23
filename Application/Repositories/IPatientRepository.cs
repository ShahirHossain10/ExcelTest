using Domain;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories;
public interface IPatientRepository
{
    List<NewPatientDto> GetAll();
    NewPatientDto Get(int id);
    Patient Add(NewPatientDto entity);
    Patient Update(NewPatientDto entity);
    bool Delete(int id);
}
